using Progressive_calc.models;
using Progressive_calc.services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace Progressive_calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppDataContext appDataContext = new AppDataContext(
            new ObservableCollection<BreakpointDefinition>(),
            new ObservableCollection<ValueRowDefinition>()
        );

        public MainWindow()
        {
            List<BreakpointDefinition> initialBreakpoints = new List<BreakpointDefinition> {
                new BreakpointDefinition(0,0),
                new BreakpointDefinition(100, 10),
                new BreakpointDefinition(500, 20),
                new BreakpointDefinition(1000, 50)
            };
            initialBreakpoints.AddRange(Enumerable.Repeat(new BreakpointDefinition(null, null), 1000));
            appDataContext.BreakpointDefinition = new ObservableCollection<BreakpointDefinition>(initialBreakpoints);

            InitializeComponent();
            this.DataContext = appDataContext;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            

            var newRowDefs = BreakPointServices.ProcessBreakPoints(appDataContext.ValueRowDefinition, appDataContext.BreakpointDefinition);
            appDataContext.ValueRowDefinition = new ObservableCollection<ValueRowDefinition>(newRowDefs);
            DGValues.ItemsSource = newRowDefs;
        }


        private void DataGrid_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor desc = e.PropertyDescriptor as PropertyDescriptor;
            if (desc.Attributes[typeof(ColumnNameAttribute)] is ColumnNameAttribute att)
            {
                e.Column.Header = att.Name;
            }
        }
    }
}
