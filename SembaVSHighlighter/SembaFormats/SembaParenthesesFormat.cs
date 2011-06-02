using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SembaVSHighlighter.SembaFormats
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "SembaParenthesesFormat")]
    [Name("SembaParenthesesFormat")]
    [UserVisible(true)]
    [Order(Before = Priority.Low)]
    internal sealed class SembaParenthesesFormat : ClassificationFormatDefinition
    {
        public SembaParenthesesFormat()
        {
            this.DisplayName = "Semba Parentheses";
        }
    }
}
