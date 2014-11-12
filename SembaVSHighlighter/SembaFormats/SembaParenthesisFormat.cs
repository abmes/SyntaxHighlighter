using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SembaVSHighlighter.SembaFormats
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "SembaParenthesisFormat")]
    [Name("SembaParenthesisFormat")]
    [UserVisible(true)]
    [Order(Before = "Comment")]
    [Order(Before = "String")]
    internal sealed class SembaParenthesisFormat : ClassificationFormatDefinition
    {
        public SembaParenthesisFormat()
        {
            DisplayName = "C#/JS/TS Parenthesis (Semba)";
        }
    }
}
