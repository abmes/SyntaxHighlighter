using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SembaVSHighlighter.SembaFormats
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "SembaDelimiterFormat")]
    [Name("SembaDelimiterFormat")]
    [UserVisible(true)]
    [Order(Before = Priority.Low)]
    internal sealed class SembaDelimiterFormat : ClassificationFormatDefinition
    {
        public SembaDelimiterFormat()
        {
            this.DisplayName = "Semba Delimiter";
        }
    }
}
