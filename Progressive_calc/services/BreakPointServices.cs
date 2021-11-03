using Progressive_calc.models;
using System.Collections.Generic;
using System.Linq;

namespace Progressive_calc.services
{
    internal class BreakPointServices
    {
        public static IEnumerable<ValueRowDefinition> ProcessBreakPoints(IEnumerable<ValueRowDefinition> valueData, List<BreakpointDefinition> breakpoints)
        {
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
