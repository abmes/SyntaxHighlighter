using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace Abmes.SyntaxHighlighter.AbmesCharClassifier
{
    [Export(typeof(IClassifierProvider))]
    [ContentType("CSharp")]
    [ContentType("JScript")]
    [ContentType("JavaScript")] // VS2012
    [ContentType("TypeScript")]
    internal class AbmesCharClassifierProvider : IClassifierProvider
    {
        [Import]
        internal IClassificationTypeRegistryService ClassificationRegistry = null;

        [Import]
        internal IClassifierAggregatorService ClassifierAggregatorService = null;

        public IClassifier GetClassifier(ITextBuffer buffer)
        {
            return buffer.Properties.GetOrCreateSingletonProperty<AbmesCharClassifier>(delegate { return new AbmesCharClassifier(ClassificationRegistry, ClassifierAggregatorService); });
        }
    }
}
