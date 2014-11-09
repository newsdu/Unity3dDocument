// Guids.cs
// MUST match guids.h
using System;

namespace newsdu.Unity3dDocument
{
    static class GuidList
    {
        public const string guidUnity3dDocumentPkgString = "e75a4970-528d-4c8e-9658-5f8e915c5127";
        public const string guidUnity3dDocumentCmdSetString = "3cc844fc-d3cb-4176-a4c2-485b68fefae2";

        public static readonly Guid guidUnity3dDocumentCmdSet = new Guid(guidUnity3dDocumentCmdSetString);
    };
}