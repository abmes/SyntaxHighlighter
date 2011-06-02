using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SembaVSHighlighter.SembaFormats
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "SembaBracketFormat")]
    [Name("SembaBracketFormat")]
    [UserVisible(true)]
    [Order(Before = Priority.Low)]
    internal sealed class SembaBracketFormat : ClassificationFormatDefinition
    {
        public SembaBracketFormat()
        {
            this.DisplayName = "Semba Bracket";
        }
    }
}
