using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abmes.SyntaxHighlighter.AbmesNamespaceClassifier
{
    internal static class AbmesNamespaceTypes
    {
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("AbmesNamespaceFormat")]
        internal static ClassificationTypeDefinition AbmesNamespaceType = null;
    }
}
