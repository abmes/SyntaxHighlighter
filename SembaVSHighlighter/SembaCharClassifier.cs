using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

namespace SembaVSHighlighter
{
    class SembaCharClassifier : IClassifier
    {
        Dictionary<IClassificationType, char[]> typeChars = new Dictionary<IClassificationType, char[]>();

        internal SembaCharClassifier(IClassificationTypeRegistryService registry)
        {
            typeChars.Add(registry.GetClassificationType("SembaBraceFormat"), new char[] { '{', '}' });
            typeChars.Add(registry.GetClassificationType("SembaBracketFormat"), new char[] { '[', ']' });
            typeChars.Add(registry.GetClassificationType("SembaParenthesisFormat"), new char[] { '(', ')' });
            typeChars.Add(registry.GetClassificationType("SembaDelimiterFormat"), new char[] { ':', ';', ',' });
        }

        private bool IsCharInType(char ch, IClassificationType ClassificationType)
        {
            foreach (var c in typeChars[ClassificationType])
                if (ch == c)
                    return true;

            return false;
        }

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            List<ClassificationSpan> classifications = new List<ClassificationSpan>();

            string line = span.GetText();

            for (int i = 0; i < line.Length; i++)
                foreach (var ct in typeChars.Keys)
                   if (IsCharInType(line[i], ct))
                        classifications.Add(new ClassificationSpan(new SnapshotSpan(span.Snapshot, new Span(span.Start.Position + i, 1)), ct));

            return classifications;
        }

        #pragma warning disable 67
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
        #pragma warning restore 67
    }
}
