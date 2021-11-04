using System.Collections.ObjectModel;

namespace Progressive_calc.models
{
    public class BreakpointDefinition
    {
        public decimal? Breakpoint { get; set; }
        public decimal? Additional_price { get; set; }


        public BreakpointDefinition(decimal? breakpointValue, decimal? price)
        {
            Breakpoint = breakpointValue;
            Additional_price = price;
        }

        public BreakpointDefinition() { }
    }

    public class ValueRowDefinition
    {
        public decimal? RawValue { get; set; }
        public decimal? ResultValue { get; set; }

        public ValueRowDefinition(decimal? rawValue, decimal? resultValue)
        {
            RawValue = rawValue;
            ResultValue = resultValue;
        }

        public ValueRowDefinition() { }
    }

    public class AppDataContext
    {
        public AppDataContext(ObservableCollection<BreakpointDefinition> breakpointDefinition, ObservableCollection<ValueRowDefinition> valueRowDefinition)
        {
            BreakpointDefinition = breakpointDefinition;
            ValueRowDefinition = valueRowDefinition;
        }

        public AppDataContext() { }

        public ObservableCollection<BreakpointDefinition> BreakpointDefinition { get; set; }
        public ObservableCollection<ValueRowDefinition> ValueRowDefinition { get; set; }
    }

    public class ColumnNameAttribute : System.Attribute
    {
        public ColumnNameAttribute(string Name) { this.Name = Name; }
        public string Name { get; set; }
    }
}
