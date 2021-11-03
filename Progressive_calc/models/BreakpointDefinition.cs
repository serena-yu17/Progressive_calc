using System.Collections.ObjectModel;

namespace Progressive_calc.models
{
    public class BreakpointDefinition
    {
        private int? breakpoint;
        private int? additional_price;

        public int? Breakpoint { get => breakpoint; set => breakpoint = value; }
        public int? Additional_price { get => additional_price; set => additional_price = value; }



        public BreakpointDefinition(int? breakpointValue, int? price)
        {
            this.Breakpoint = breakpointValue;
            this.Additional_price = price;
        }

        public BreakpointDefinition() { }
    }

    public class ValueRowDefinition
    {
        private int? rawValue;
        private int? resultValue;

        public int? RawValue { get => rawValue; set => rawValue = value; }
        public int? ResultValue { get => resultValue; set => resultValue = value; }

        public ValueRowDefinition(int? rawValue, int? resultValue)
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
