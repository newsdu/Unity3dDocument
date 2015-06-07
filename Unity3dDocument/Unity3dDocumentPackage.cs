using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;

namespace newsdu.Unity3dDocument
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the information needed to show this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidUnity3dDocumentPkgString)]
    public sealed class Unity3dDocumentPackage : Package
	{
		#region Constant Values

		const string MANUAL_PATH = "Editor\\Data\\Documentation\\html\\en\\ScriptReference\\";
		const string MANUAL_INDEX_PATH = MANUAL_PATH + "index.html";
		const string MANUAL_30_SEARCH_PATH = MANUAL_PATH + "30_search.html";

		const string MANUAL_PATH_UNITY5 = "Editor\\Data\\Documentation\\en\\ScriptReference\\";
		const string MANUAL_INDEX_PATH_UNITY5 = MANUAL_PATH_UNITY5 + "index.html";
		const string MANUAL_30_SEARCH_PATH_UNITY5 = MANUAL_PATH_UNITY5 + "30_search.html";

		const string LOCAL_QUERY_PREFIX = "\"file:///{0}/Editor/Data/Documentation/html/en/ScriptReference/";
		const string LOCAL_QUERY_SEARCH_FORMAT = LOCAL_QUERY_PREFIX + "30_search.html?q={1}\"";
		const string LOCAL_QUERY_INDEX_FORMAT = LOCAL_QUERY_PREFIX + "index.html\"";
		const string LOCAL_QUERY_PREFIX_UNITY5 = "\"file:///{0}/Editor/Data/Documentation/en/ScriptReference/";
		const string LOCAL_QUERY_SEARCH_FORMAT_UNITY5 = LOCAL_QUERY_PREFIX_UNITY5 + "30_search.html?q={1}\"";
		const string LOCAL_QUERY_INDEX_FORMAT_UNITY5 = LOCAL_QUERY_PREFIX_UNITY5 + "index.html\"";

		#endregion


		#region Constructor

		/// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public Unity3dDocumentPackage()
        {
        }

		#endregion

		#region Private Members

		[Serializable]
        public class Option
        {
            public string webBrowserPath;
            public string unity3dPath;
            public string googlePrefix;
			public string naverPrefix;
        }
        Option m_option = new Option();

		string googlePrefixEncoded;
		string GooglePrefix
		{
			get { return m_option.googlePrefix; }
			set
			{
				m_option.googlePrefix = value;
				if (string.IsNullOrEmpty(m_option.googlePrefix))
					m_option.googlePrefix = "unity";
				googlePrefixEncoded = WebUtility.UrlEncode(m_option.googlePrefix);
			}
		}

		string naverPrefixEncoded;
		string NaverPrefix
		{
			get { return m_option.naverPrefix; }
			set
			{
				m_option.naverPrefix = value;
				if (string.IsNullOrEmpty(m_option.naverPrefix))
					m_option.naverPrefix = "unity";
				naverPrefixEncoded = WebUtility.UrlEncode(m_option.naverPrefix);
			}
		}

		bool isUnity5 = false;

		#endregion

		#region Private Methods

		private void LoadOption()
        {
            string optDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Unity3dDocument";
            string optPath = optDir + "\\Unity3dDocumentOption.xml";
            if(File.Exists(optPath))
            {
                using (FileStream fs = new FileStream(optPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Option));
                    m_option = (Option)xs.Deserialize(fs);
					GooglePrefix = m_option.googlePrefix;
					NaverPrefix = m_option.naverPrefix;
                }
            }
            else
            {
                InitWebBrowserPath();
                InitUnity3dPath();
				GooglePrefix = "unity";
				NaverPrefix = "unity";

                SaveOption();
            }
        }

        private void SaveOption()
        {
            string optDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Unity3dDocument";
            string optPath = optDir + "\\Unity3dDocumentOption.xml";

            if (!Directory.Exists(optDir))
                Directory.CreateDirectory(optDir);

            using(FileStream fs = new FileStream(optPath, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Option));
                xs.Serialize(fs, m_option);
            }
        }
		
		private void InitWebBrowserPath()
		{
            m_option.webBrowserPath = 
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                "Google\\Chrome\\Application\\chrome.exe");
            if (!File.Exists(m_option.webBrowserPath))
			{
                m_option.webBrowserPath = 
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                    "Internet Explorer\\iexplore.exe");
			}
		}

		private void InitUnity3dPath()
		{
            m_option.unity3dPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Unity";
            if (!CheckUnity3dPath(m_option.unity3dPath))
			{
				m_option.unity3dPath = null;
			}
		}

		private bool CheckUnity3dPath(string _path)
		{
			isUnity5 = false;
			if (CheckUnityDocument(_path))
				return true;
			if (CheckUnityDocumentUnity5(_path))
			{
				isUnity5 = true;
				return true;
			}
			return false;
		}

		private bool CheckUnityDocument(string _path)
		{
			return File.Exists(Path.Combine(_path, MANUAL_INDEX_PATH)) &&
					File.Exists(Path.Combine(_path, MANUAL_30_SEARCH_PATH));
		}

		private bool CheckUnityDocumentUnity5(string _path)
		{
			return File.Exists(Path.Combine(_path, MANUAL_INDEX_PATH_UNITY5)) &&
					File.Exists(Path.Combine(_path, MANUAL_30_SEARCH_PATH_UNITY5));
		}

		private string GetQueryString()
		{
			string queryString = null;
			var dte = (EnvDTE.DTE)GetService(typeof(EnvDTE.DTE));
			if (dte != null && dte.ActiveWindow != null)
			{
				var textSel = dte.ActiveWindow.Selection as EnvDTE.TextSelection;
				if (textSel != null)
				{
					int oriOffset = textSel.ActivePoint.AbsoluteCharOffset;
					if(string.IsNullOrEmpty(textSel.Text))
					{
						textSel.WordLeft();
						textSel.WordRight(true);
					}

					queryString = textSel.Text.Trim();
					if(string.IsNullOrEmpty(queryString))
					{
						textSel.MoveToAbsoluteOffset(oriOffset);
					}
					else if (textSel.Text.Length > queryString.Length)
					{
						textSel.CharLeft(true, textSel.Text.Length - queryString.Length);
					}
				}
			}
			return queryString;
		}

		private bool ValidateUnity3dPath()
		{
            if (!string.IsNullOrEmpty(m_option.unity3dPath) &&
				CheckUnity3dPath(m_option.unity3dPath))
				return true;

            System.Windows.Forms.MessageBox.Show(
				"Invalid Unity3d Path.\r\nCheck Unity3d Document Option.", 
				"Unity3d Document",
				System.Windows.Forms.MessageBoxButtons.OK,
				System.Windows.Forms.MessageBoxIcon.Warning);
            return false;
		}

        private bool ValidateWebBrowserPath()
        {
			if (!string.IsNullOrEmpty(m_option.webBrowserPath) &&
				File.Exists(m_option.webBrowserPath))
				return true;

			System.Windows.Forms.MessageBox.Show(
				"Invalid WebBrowser Path.\r\nCheck Unity3d Document Option.",
				"Unity3d Document",
				System.Windows.Forms.MessageBoxButtons.OK,
				System.Windows.Forms.MessageBoxIcon.Warning);
            return false;
        }

		private void QueryLocalDocument(string _queryString)
		{
            if (!ValidateUnity3dPath())
                return;

			string fullPath;
			string searchFormat = isUnity5 ? LOCAL_QUERY_SEARCH_FORMAT_UNITY5 : LOCAL_QUERY_SEARCH_FORMAT;
			string indexFormat = isUnity5 ? LOCAL_QUERY_INDEX_FORMAT_UNITY5 : LOCAL_QUERY_INDEX_FORMAT;
			if (!string.IsNullOrEmpty(_queryString))
			{
				string queryTrim = _queryString.Trim();
				fullPath = string.Format(searchFormat, m_option.unity3dPath, WebUtility.UrlEncode(queryTrim));
			}
			else
			{
                fullPath = string.Format(indexFormat, m_option.unity3dPath);
			}
            Process.Start(m_option.webBrowserPath, fullPath);
		}

		private void QueryWebDocument(string _queryString)
		{
			if (!ValidateWebBrowserPath())
				return;

			string fullPath;
			if (!string.IsNullOrEmpty(_queryString))
			{
				string queryTrim = _queryString.Trim();
				fullPath = string.Format("http://docs.unity3d.com/ScriptReference/30_search.html?q={0}",
					WebUtility.UrlEncode(queryTrim));
			}
			else
			{
				fullPath = string.Format("http://docs.unity3d.com/ScriptReference/");
			}
            Process.Start(m_option.webBrowserPath, fullPath);
		}

        private void QueryGoogle(string _queryString)
        {
			if (!ValidateWebBrowserPath())
				return;

            string fullPath;
			if (!string.IsNullOrEmpty(_queryString))
			{
				string queryTrim = _queryString.Trim();
                fullPath = string.Format("https://www.google.co.kr/search?q={0}+{1}", 
					googlePrefixEncoded,
					WebUtility.UrlEncode(queryTrim));
            }
            else
            {
                fullPath = string.Format("https://www.google.co.kr/search?q={0}",
					googlePrefixEncoded);
            }
            Process.Start(m_option.webBrowserPath, fullPath);
        }

        private void QueryNaver(string _queryString)
        {
			if (!ValidateWebBrowserPath())
				return;

            string fullPath;
			if (!string.IsNullOrEmpty(_queryString))
			{
				string queryTrim = _queryString.Trim();
                fullPath = string.Format("http://search.naver.com/search.naver?query={0}+{1}",
					naverPrefixEncoded,
					WebUtility.UrlEncode(queryTrim));
            }
            else
            {
                fullPath = string.Format("http://search.naver.com/search.naver?query={0}",
					naverPrefixEncoded);
            }
            Process.Start(m_option.webBrowserPath, fullPath);
        }

        private void ShowOption()
        {
            OptionForm optForm = new OptionForm();
            optForm.Unity3dPath = m_option.unity3dPath;
            optForm.WebBrowserPath = m_option.webBrowserPath;
            optForm.GooglePrefix = GooglePrefix;
			optForm.NaverPrefix = NaverPrefix;
            
            var result = optForm.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK)
                return;

            m_option.unity3dPath =  optForm.Unity3dPath;
            m_option.webBrowserPath = optForm.WebBrowserPath;
            var prefix = optForm.GooglePrefix;
			if (string.IsNullOrEmpty(prefix))
				GooglePrefix = "unity";
			else
				GooglePrefix = prefix.Trim();
			prefix = optForm.NaverPrefix;
			if (string.IsNullOrEmpty(prefix))
				NaverPrefix = "unity";
			else
				NaverPrefix = prefix.Trim();

            SaveOption();
        }

		#endregion

        #region Package Members

		/////////////////////////////////////////////////////////////////////////////
		// Overridden Package Implementation

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

			// Load Option
            LoadOption();

            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if ( null != mcs )
            {
                // Create the command for the menu item.
                AddToMenu(mcs, (int)PkgCmdIDList.cmdidLocalDocument, OnQueryToLocalDocument);
                AddToMenu(mcs, (int)PkgCmdIDList.cmdidWebDocument, OnQueryToWebDocument);
                AddToMenu(mcs, (int)PkgCmdIDList.cmdidGoogle, OnQueryToGoogle);
                AddToMenu(mcs, (int)PkgCmdIDList.cmdidNaver, OnQueryToNaver);
                AddToMenu(mcs, (int)PkgCmdIDList.cmdidOption, OnOption);
            }
        }

        private void AddToMenu(OleMenuCommandService _mcs, int _cmdID, EventHandler _handler)
        {
            CommandID cmdID = new CommandID(GuidList.guidUnity3dDocumentCmdSet, _cmdID);
            MenuCommand menuCmd = new MenuCommand(_handler, cmdID);
            _mcs.AddCommand(menuCmd);
        }

        #endregion

		#region Event Callback Methods

		private void OnQueryToLocalDocument(object sender, EventArgs e)
        {
			QueryLocalDocument(GetQueryString());
        }

		private void OnQueryToWebDocument(object sender, EventArgs e)
		{
			QueryWebDocument(GetQueryString());
		}

        private void OnQueryToGoogle(object sender, EventArgs e)
        {
            QueryGoogle(GetQueryString());
        }

        private void OnQueryToNaver(object sender, EventArgs e)
        {
            QueryNaver(GetQueryString());
        }

        private void OnOption(object sender, EventArgs e)
        {
            ShowOption();
		}

		#endregion
	}
}
