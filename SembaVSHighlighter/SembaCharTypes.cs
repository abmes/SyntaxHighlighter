using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace SembaVSHighlighter
{
    internal static class SembaCharTypes
    {
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("SembaBraceFormat")]
        internal static ClassificationTypeDefinition SembaBraceType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("SembaBracketFormat")]
        internal static ClassificationTypeDefinition SembaBracketType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("SembaParenthesisFormat")]
        internal static ClassificationTypeDefinition SembaParenthesisType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("SembaDelimiterFormat")]
        internal static ClassificationTypeDefinition SembaDelimiterType = null;
    }
}
