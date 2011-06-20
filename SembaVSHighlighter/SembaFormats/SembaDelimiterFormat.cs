﻿using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SembaVSHighlighter.SembaFormats
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "SembaDelimiterFormat")]
    [Name("SembaDelimiterFormat")]
    [UserVisible(true)]
    [Order(Before = "Comment")]
    [Order(Before = "String")]
    internal sealed class SembaDelimiterFormat : ClassificationFormatDefinition
    {
        public SembaDelimiterFormat()
        {
            this.DisplayName = "Semba C# Delimiter";
        }
    }
}
