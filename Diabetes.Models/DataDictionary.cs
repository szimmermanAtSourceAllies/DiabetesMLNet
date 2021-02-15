using FileHelpers;

namespace Diabetes.Models
{
    [IgnoreFirst(1)]
    [DelimitedRecord(",")]
    public class DataDictionary
    {
        [FieldTrim(TrimMode.Both)]
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForBoth)]
        public string Category;

        [FieldTrim(TrimMode.Both)]
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForBoth)]
        public string VariableName;

        [FieldTrim(TrimMode.Both)]
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForBoth)]
        public string UnitOfMeasure;

        [FieldTrim(TrimMode.Both)]
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForBoth)]
        public string DataType;

        [FieldTrim(TrimMode.Both)]
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForBoth)]
        public string Description;

        [FieldTrim(TrimMode.Both)]
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForBoth)]
        public string Example;
    }
}