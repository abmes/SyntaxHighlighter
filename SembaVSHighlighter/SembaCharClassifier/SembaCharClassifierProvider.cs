using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace SembaVSHighlighter.SembaCharClassifier
{
    [Export(typeof(IClassifierProvider))]
    [ContentType("CSharp")]
    [ContentType("JScript")]
    [ContentType("JavaScript")] // VS2012
    [ContentType("TypeScript")]
    internal class SembaCharClassifierProvider : IClassifierProvider
    {
        [Import]
        internal IClassificationTypeRegistryService ClassificationRegistry = null;

        [Import]
        internal IClassifierAggregatorService ClassifierAggregatorService = null;

        public IClassifier GetClassifier(ITextBuffer buffer)
        {
            return buffer.Properties.GetOrCreateSingletonProperty<SembaCharClassifier>(delegate { return new SembaCharClassifier(ClassificationRegistry, ClassifierAggregatorService); });
        }
    }
}
