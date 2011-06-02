using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SembaVSHighlighter.SembaFormats
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "SembaBraceFormat")]
    [Name("SembaBraceFormat")]
    [UserVisible(true)]
    [Order(Before = Priority.Low)]
    internal sealed class SembaBraceFormat : ClassificationFormatDefinition
    {
        public SembaBraceFormat()
        {
            this.DisplayName = "Semba Brace";
        }
    }
}
