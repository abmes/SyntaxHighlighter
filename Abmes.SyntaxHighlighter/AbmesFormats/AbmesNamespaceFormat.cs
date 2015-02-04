using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abmes.SyntaxHighlighter.AbmesFormats
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "AbmesNamespaceFormat")]
    [Name("AbmesNamespaceFormat")]
    [UserVisible(true)]
    [Order(Before = "Comment")]
    [Order(Before = "String")]
    [Order(After = "User Types")]
    internal sealed class AbmesNamespaceFormat : ClassificationFormatDefinition
    {
        public AbmesNamespaceFormat()
        {
            DisplayName = "C# Namespace (Abmes)";
        }
    }
}
