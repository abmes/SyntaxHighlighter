using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SembaVSHighlighter.SembaFormats
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "SembaBraceFormat")]
    [Name("SembaBraceFormat")]
    [UserVisible(true)]
    [Order(Before = "Comment")]
    [Order(Before = "String")]
    internal sealed class SembaBraceFormat : ClassificationFormatDefinition
    {
        public SembaBraceFormat()
        {
            DisplayName = "C#/JS/TS Brace (Semba)";
        }
    }
}
