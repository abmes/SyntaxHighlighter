using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SembaVSHighlighter.SembaFormats
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "SembaNamespaceFormat")]
    [Name("SembaNamespaceFormat")]
    [UserVisible(true)]
    [Order(Before = "Comment")]
    [Order(Before = "String")]
    [Order(After = "User Types")]
    internal sealed class SembaNamespaceFormat : ClassificationFormatDefinition
    {
        public SembaNamespaceFormat()
        {
            DisplayName = "C# Namespace (Semba)";
        }
    }
}
