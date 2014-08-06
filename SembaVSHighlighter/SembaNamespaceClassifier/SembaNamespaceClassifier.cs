﻿using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;
using SembaVSHighlighter.Common;

namespace SembaVSHighlighter.SembaNamespaceClassifier
{
    class SembaNamespaceClassifier : SembaClassifier
    {
        private readonly IClassificationType SembaNamespaceClassificationType;
        private readonly char[] DelimiterChars;

        internal SembaNamespaceClassifier(IClassificationTypeRegistryService classificationTypeRegistryService, IClassifierAggregatorService classifierAggregatorService)
            : base (classificationTypeRegistryService, classifierAggregatorService)
        {
            SembaNamespaceClassificationType = classificationTypeRegistryService.GetClassificationType("SembaNamespaceFormat");
            DelimiterChars = GetDelimiterChars();
        }

        private char[] GetDelimiterChars()
        {
            var result = new List<char>();
            for (int i = char.MinValue; i <= char.MaxValue; i++)
            {
                char c = Convert.ToChar(i);
                if ((!(char.IsLetterOrDigit(c) || (c == '_'))) && (!char.IsControl(c)))
                    result.Add(c);
            }

            return result.ToArray();
        }

        private ClassificationSpan GetClassificationSpan(SnapshotSpan span, int startIndex, int length, IClassificationType classificationType)
        {
            return new ClassificationSpan(new SnapshotSpan(span.Snapshot, new Span(span.Start + startIndex, length)), classificationType);
        }

        private int GetNextIndexWhile(string line, int startIndex, Func<char, bool> whileFunc)
        {
            int index = startIndex;

            while ((index < line.Length) && (whileFunc(line[index])))
                index++;

            return index;
        }

        private bool IsIdentifierChar(char x)
        {
            return char.IsLetterOrDigit(x) || (x == '_');
        }

        private int GetNextIdentifierIndex(string line, int startIndex)
        {
            return GetNextIndexWhile(line, startIndex, x => !IsIdentifierChar(x));
        }

        private int GetNextDelimiterIndex(string line, int startIndex)
        {
            return GetNextIndexWhile(line, startIndex, x => IsIdentifierChar(x));
        }

        private void AddNamespaceAfterKeywordClassificationSpans(ICollection<ClassificationSpan> classifications, SnapshotSpan span, string keyword, Func<string, bool> acceptLineFunc)
        {
            string line = span.GetText();

            if (line.Trim().StartsWith(keyword) && acceptLineFunc(line))
            {
                int keywordStartIndex = line.IndexOf(keyword);
                int keywordEndIndex = GetNextDelimiterIndex(line, keywordStartIndex);

                if ((keywordEndIndex >= 0) && (keywordEndIndex - keywordStartIndex == keyword.Length))
                {
                    int namespaceStartIndex = GetNextIdentifierIndex(line, keywordEndIndex);

                    while (namespaceStartIndex < line.Length)
                    {
                        int namespaceEndIndex = GetNextDelimiterIndex(line, namespaceStartIndex);
                        var classificationSpan = GetClassificationSpan(span, namespaceStartIndex, namespaceEndIndex - namespaceStartIndex, SembaNamespaceClassificationType); 
                        AddToClassificationsIfNotInsideVerbatim(classificationSpan, classifications, span);
                        namespaceStartIndex = GetNextIdentifierIndex(line, namespaceEndIndex);
                    }
                }
            }
        }
        
        private void AddNamespaceBeforeTypeClassificationSpans(ICollection<ClassificationSpan> classifications, SnapshotSpan span)
        {
            string line = span.GetText();

            var classifier = _classifierAggregatorService.GetClassifier(span.Snapshot.TextBuffer);
            foreach (var classificationSpan in classifier.GetClassificationSpans(span))
            {
                if (classificationSpan.ClassificationType.IsOfType("User Types") ||
                    classificationSpan.ClassificationType.IsOfType("User Types(Delegates)") ||
                    classificationSpan.ClassificationType.IsOfType("User Types(Enums)") ||
                    classificationSpan.ClassificationType.IsOfType("User Types(Interfaces)") ||
                    classificationSpan.ClassificationType.IsOfType("User Types(Type parameters)") ||
                    classificationSpan.ClassificationType.IsOfType("User Types(Value types)")
                   )
                {
                    int userTypeStart = classificationSpan.Span.Start - span.Start;

                    int prevDelimiterIndex = userTypeStart - 1;

                    while ((prevDelimiterIndex >= 0) && (line[prevDelimiterIndex] == '.'))
                    {
                        int nextDelimiterIndex = line.LastIndexOfAny(DelimiterChars, prevDelimiterIndex - 1);
                        var namespaceClassificationSpan = GetClassificationSpan(span, nextDelimiterIndex + 1, prevDelimiterIndex - nextDelimiterIndex - 1, SembaNamespaceClassificationType);
                        AddToClassificationsIfNotInsideVerbatim(namespaceClassificationSpan, classifications, span);
                        prevDelimiterIndex = nextDelimiterIndex;
                    }
                }
            }
        }

        protected override void AddClassifications(ICollection<ClassificationSpan> classifications, SnapshotSpan span)
        {
            AddNamespaceAfterKeywordClassificationSpans(classifications, span, "using", line => !line.Contains('('));
            AddNamespaceAfterKeywordClassificationSpans(classifications, span, "namespace", line => true);
            AddNamespaceBeforeTypeClassificationSpans(classifications, span);
        }
    }
}
