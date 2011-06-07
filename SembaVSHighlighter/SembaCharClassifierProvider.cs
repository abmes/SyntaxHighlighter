using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace SembaVSHighlighter
{
    [Export(typeof(IClassifierProvider))]
    [ContentType("CSharp")]
    internal class SembaCharClassifierProvider : IClassifierProvider
    {
        [Import]
        internal IClassificationTypeRegistryService ClassificationRegistry = null;

        public IClassifier GetClassifier(ITextBuffer buffer)
        {
            return buffer.Properties.GetOrCreateSingletonProperty<SembaCharClassifier>(delegate { return new SembaCharClassifier(ClassificationRegistry); });
        }
    }
}
