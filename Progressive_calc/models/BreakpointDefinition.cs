using System.Collections.ObjectModel;

namespace Progressive_calc.models
{
    public class BreakpointDefinition
    {
        private decimal? breakpoint;
        private decimal? additional_price;

        public decimal? Breakpoint { get => breakpoint; set => breakpoint = value; }
        public decimal? Additional_price { get => additional_price; set => additional_price = value; }


        public BreakpointDefinition(decimal? breakpointValue, decimal? price)
        {
            this.Breakpoint = breakpointValue;
            this.Additional_price = price;
        }

        public BreakpointDefinition() { }
    }

    public class ValueRowDefinition
    {
        private decimal? rawValue;
        private decimal? resultValue;

        public decimal? RawValue { get => rawValue; set => rawValue = value; }
        public decimal? ResultValue { get => resultValue; set => resultValue = value; }

        public ValueRowDefinition(decimal? rawValue, decimal? resultValue)
        {
            this.RawValue = rawValue;
            this.ResultValue = resultValue;
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
