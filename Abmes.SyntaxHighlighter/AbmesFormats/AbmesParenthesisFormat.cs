using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Abmes.SyntaxHighlighter.AbmesFormats
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "AbmesParenthesisFormat")]
    [Name("AbmesParenthesisFormat")]
    [UserVisible(true)]
    [Order(Before = "Comment")]
    [Order(Before = "String")]
    internal sealed class AbmesParenthesisFormat : ClassificationFormatDefinition
    {
        public AbmesParenthesisFormat()
        {
            DisplayName = "C#/JS/TS Parenthesis (Abmes)";
        }
    }
}
