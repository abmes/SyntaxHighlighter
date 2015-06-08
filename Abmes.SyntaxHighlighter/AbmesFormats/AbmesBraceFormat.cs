using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Abmes.SyntaxHighlighter.AbmesFormats
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "AbmesBraceFormat")]
    [Name("AbmesBraceFormat")]
    [UserVisible(true)]
    [Order(Before = "Comment")]
    [Order(Before = "String")]
    [Order(After = "Punctuation")]
    internal sealed class AbmesBraceFormat : ClassificationFormatDefinition
    {
        public AbmesBraceFormat()
        {
            DisplayName = "C#/JS/TS Brace (Abmes)";
        }
    }
}
