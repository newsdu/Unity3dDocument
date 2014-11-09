using System;
using System.IO;
using System.Windows.Forms;

namespace newsdu.Unity3dDocument
{
    public partial class OptionForm : Form
    {
        public OptionForm()
        {
            InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
        }

        public string Unity3dPath
        {
            get { return txtbox_unity3dPath.Text; }
            set { txtbox_unity3dPath.Text = value; }
        }

        public string WebBrowserPath
        {
            get { return txtbox_webBrowserPath.Text; }
            set { txtbox_webBrowserPath.Text = value; }
        }

        public string GooglePrefix
        {
            get { return txtbox_googlePrefix.Text; }
            set { txtbox_googlePrefix.Text = value; }
        }

		public string NaverPrefix
		{
			get { return txtbox_naverPrefix.Text; }
			set { txtbox_naverPrefix.Text = value; }
		}

        private void btn_unity3dPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Choose Unity3d Installed Directory.";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            var result = fbd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            Unity3dPath = fbd.SelectedPath;
        }

        private void btn_webBrowserPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose Web Browser Executable.";
            ofd.Multiselect = false;
            ofd.DefaultExt = "exe";
            ofd.Filter = "Executable Files(*.exe)|*.exe";
            ofd.FilterIndex = 0;
			ofd.InitialDirectory = Path.GetDirectoryName(WebBrowserPath);
            ofd.FileName = Path.GetFileNameWithoutExtension(WebBrowserPath);

            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            WebBrowserPath = ofd.FileName;
        }
    }
}
