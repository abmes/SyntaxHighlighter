using Microsoft.VisualStudio.Text;
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
    [Export(typeof(IClassifierProvider))]
    [ContentType("CSharp")]
    internal class AbmesNamespaceClassifierProvider : IClassifierProvider
    {
        [Import]
        internal IClassificationTypeRegistryService ClassificationRegistry = null;

        [Import]
        internal IClassifierAggregatorService ClassifierAggregatorService = null;

        public IClassifier GetClassifier(ITextBuffer buffer)
        {
            return buffer.Properties.GetOrCreateSingletonProperty<AbmesNamespaceClassifier>(delegate { return new AbmesNamespaceClassifier(ClassificationRegistry, ClassifierAggregatorService); });
        }
    }
}
