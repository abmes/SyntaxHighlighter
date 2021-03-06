﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Abmes.SyntaxHighlighter.Common;

namespace Abmes.SyntaxHighlighter.AbmesCharClassifier
{
    class AbmesCharClassifier : AbmesClassifier
    {
        Dictionary<IClassificationType, char[]> typeChars = new Dictionary<IClassificationType, char[]>();

        internal AbmesCharClassifier(IClassificationTypeRegistryService classificationTypeRegistryService, IClassifierAggregatorService classifierAggregatorService)
            : base(classificationTypeRegistryService, classifierAggregatorService)
        {
            typeChars.Add(classificationTypeRegistryService.GetClassificationType("AbmesBraceFormat"), new char[] { '{', '}' });
            typeChars.Add(classificationTypeRegistryService.GetClassificationType("AbmesBracketFormat"), new char[] { '[', ']' });
            typeChars.Add(classificationTypeRegistryService.GetClassificationType("AbmesParenthesisFormat"), new char[] { '(', ')' });
            typeChars.Add(classificationTypeRegistryService.GetClassificationType("AbmesDelimiterFormat"), new char[] { ':', ';', ',' });
        }

        private bool IsCharInType(char ch, IClassificationType ClassificationType)
        {
            foreach (var c in typeChars[ClassificationType])
                if (ch == c)
                    return true;

            return false;
        }

        protected override void AddClassifications(ICollection<ClassificationSpan> classifications, SnapshotSpan span)
        {
            string line = span.GetText();

            for (int i = 0; i < line.Length; i++)
                foreach (var ct in typeChars.Keys)
                    if (IsCharInType(line[i], ct))
                    {
                        var classificationSpan = new ClassificationSpan(new SnapshotSpan(span.Snapshot, new Span(span.Start.Position + i, 1)), ct);
                        AddToClassificationsIfNotInsideVerbatim(classificationSpan, classifications, span);
                    }
        }
    }
}
