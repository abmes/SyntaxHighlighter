using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SembaVSHighlighter.Common
{
    abstract class SembaClassifier : IClassifier
    {
        private bool _isAlreadyClassifying;

        private IClassificationTypeRegistryService _classificationTypeRegistry;
        protected IClassifierAggregatorService _classifierAggregatorService;

        internal SembaClassifier(IClassificationTypeRegistryService classificationTypeRegistry, IClassifierAggregatorService classifierAggregatorService)
        {
            _classificationTypeRegistry = classificationTypeRegistry;
            _classifierAggregatorService = classifierAggregatorService;
        }

        protected abstract void AddClassifications(ICollection<ClassificationSpan> classifications, SnapshotSpan span);

        protected void AddToClassificationsIfNotInsideVerbatim(ClassificationSpan classificationSpan, ICollection<ClassificationSpan> classifications, SnapshotSpan span)
        {
            var classificationSpans = _classifierAggregatorService.GetClassifier(span.Snapshot.TextBuffer).GetClassificationSpans(span);
            var verbatimSpans = classificationSpans.Where(x => x.ClassificationType.Classification == "String(C# @ Verbatim)");
            if (verbatimSpans.All(x => !x.Span.Contains(classificationSpan.Span)))
            {
                classifications.Add(classificationSpan);
            }
        }

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            List<ClassificationSpan> classifications = new List<ClassificationSpan>();

            if (!_isAlreadyClassifying)
            {
                _isAlreadyClassifying = true;
                try
                {
                    AddClassifications(classifications, span);
                }
                finally
                {
                    _isAlreadyClassifying = false;
                }
            }

            return classifications;
        }

        #pragma warning disable 67
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
        #pragma warning restore 67
    }
}
