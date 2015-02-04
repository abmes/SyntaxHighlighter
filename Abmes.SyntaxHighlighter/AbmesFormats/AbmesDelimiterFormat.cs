using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Abmes.SyntaxHighlighter.AbmesFormats
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "AbmesDelimiterFormat")]
    [Name("AbmesDelimiterFormat")]
    [UserVisible(true)]
    [Order(Before = "Comment")]
    [Order(Before = "String")]
    internal sealed class AbmesDelimiterFormat : ClassificationFormatDefinition
    {
        public AbmesDelimiterFormat()
        {
            DisplayName = "C#/JS/TS Delimiter (Abmes)";
        }
    }
}
