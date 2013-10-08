using Microsoft.VisualStudio.Text;
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
    [Export(typeof(IClassifierProvider))]
    [ContentType("CSharp")]
    internal class SembaNamespaceClassifierProvider : IClassifierProvider
    {
        [Import]
        internal IClassificationTypeRegistryService ClassificationRegistry = null;

        [Import]
        internal IClassifierAggregatorService ClassifierAggregatorService = null;

        public IClassifier GetClassifier(ITextBuffer buffer)
        {
            return buffer.Properties.GetOrCreateSingletonProperty<SembaNamespaceClassifier>(delegate { return new SembaNamespaceClassifier(ClassificationRegistry, ClassifierAggregatorService); });
        }
    }
}
