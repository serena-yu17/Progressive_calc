using Progressive_calc.models;
using System.Collections.Generic;
using System.Linq;

namespace Progressive_calc.services
{
    internal class BreakPointServices
    {
        public static IEnumerable<ValueRowDefinition> ProcessBreakPoints(IEnumerable<ValueRowDefinition> valueData, IEnumerable<BreakpointDefinition> breakpointDefinitions)
        {
            var breakpoints = new List<BreakpointDefinition>();
            breakpoints.AddRange(
                breakpointDefinitions.Where(item => item.Breakpoint != null && item.Additional_price != null && item.Breakpoint >= 0)
            );
            if (!breakpoints.Exists(item => item.Breakpoint == 0))
            {
                breakpoints.Add(new BreakpointDefinition(0, 0));
            }
            breakpoints.Sort((x, y) => x.Breakpoint.Value.CompareTo(y.Breakpoint.Value));

            var rawValues = valueData.ToArray();
            foreach (var rawValPair in rawValues)
            {
                if (rawValPair.RawValue == null || rawValPair.RawValue < 0)
                {
                    continue;
                }
                var breakptCollection = breakpoints.TakeWhile(item => item.Breakpoint <= rawValPair.RawValue);
                var breakpt = breakptCollection.LastOrDefault();
                if (breakpt != default)
                {
                    rawValPair.ResultValue = rawValPair.RawValue + breakpt.Additional_price;
                }
                else
                {
                    rawValPair.ResultValue = null;
                }
            }
            return rawValues;
        }
    }
}
