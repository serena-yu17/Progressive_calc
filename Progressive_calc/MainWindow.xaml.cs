﻿using Progressive_calc.models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Progressive_calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly AppDataContext appDataContext = new AppDataContext(
            new ObservableCollection<BreakpointDefinition> {
                new BreakpointDefinition(0,0),
                new BreakpointDefinition(100, 10),
                new BreakpointDefinition(500, 20),
                new BreakpointDefinition(1000, 50)
            }, new ObservableCollection<ValueRowDefinition>()
        );

        public MainWindow()
        {
            for (int i = 0; i < 100; i++)
            {
                appDataContext.BreakpointDefinition.Add(new BreakpointDefinition(null, null));
                appDataContext.ValueRowDefinition.Add(new ValueRowDefinition(null, null));
            }

            InitializeComponent();
            this.DataContext = appDataContext;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var breakPoints = new List<BreakpointDefinition> { new BreakpointDefinition(0, 0) };
            breakPoints.AddRange(
                appDataContext.BreakpointDefinition
                .Where(item => item.Breakpoint != null && item.Additional_price != null && item.Breakpoint > 0 )
                .OrderBy(item => item.Breakpoint)               
            );

            var newRowDefs = processAsync(appDataContext.ValueRowDefinition, breakPoints);
            appDataContext.ValueRowDefinition = newRowDefs;
            DGValues.ItemsSource = newRowDefs;
        }


        private ObservableCollection<ValueRowDefinition> processAsync(IEnumerable<ValueRowDefinition> valueData, List<BreakpointDefinition> breakpoints)
        {
            var rawValues = valueData.ToArray();
            foreach (var rawValPair in rawValues)
            {              
                if (rawValPair.RawValue == null || rawValPair.RawValue < 0)
                {
                    continue;
                }
                var breakptCollection = breakpoints.TakeWhile(item => item.Breakpoint < rawValPair.RawValue);
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
            return new ObservableCollection<ValueRowDefinition>(rawValues);            
        }
    }
}