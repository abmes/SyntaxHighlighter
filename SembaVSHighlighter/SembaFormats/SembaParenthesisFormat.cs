using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SembaVSHighlighter.SembaFormats
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "SembaParenthesisFormat")]
    [Name("SembaParenthesisFormat")]
    [UserVisible(true)]
    [Order(Before = Priority.Low)]
    internal sealed class SembaParenthesisFormat : ClassificationFormatDefinition
    {
        public SembaParenthesisFormat()
        {
            this.DisplayName = "Semba C# Parenthesis";
        }
    }
}
