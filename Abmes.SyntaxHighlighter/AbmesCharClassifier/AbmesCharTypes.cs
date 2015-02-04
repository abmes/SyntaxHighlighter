using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace Abmes.SyntaxHighlighter.AbmesCharClassifier
{
    internal static class AbmesCharTypes
    {
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("AbmesBraceFormat")]
        internal static ClassificationTypeDefinition AbmesBraceType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("AbmesBracketFormat")]
        internal static ClassificationTypeDefinition AbmesBracketType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("AbmesParenthesisFormat")]
        internal static ClassificationTypeDefinition AbmesParenthesisType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("AbmesDelimiterFormat")]
        internal static ClassificationTypeDefinition AbmesDelimiterType = null;
    }
}
