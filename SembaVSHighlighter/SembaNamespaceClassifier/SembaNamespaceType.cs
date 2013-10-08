using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SembaVSHighlighter.SembaNamespaceClassifier
{
    internal static class SembaNamespaceTypes
    {
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("SembaNamespaceFormat")]
        internal static ClassificationTypeDefinition SembaNamespaceType = null;
    }
}
