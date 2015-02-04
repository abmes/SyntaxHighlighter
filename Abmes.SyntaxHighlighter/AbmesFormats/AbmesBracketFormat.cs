using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Abmes.SyntaxHighlighter.AbmesFormats
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "AbmesBracketFormat")]
    [Name("AbmesBracketFormat")]
    [UserVisible(true)]
    [Order(Before = "Comment")]
    [Order(Before = "String")]
    internal sealed class AbmesBracketFormat : ClassificationFormatDefinition
    {
        public AbmesBracketFormat()
        {
            DisplayName = "C#/JS/TS Bracket (Abmes)";
        }
    }
}
