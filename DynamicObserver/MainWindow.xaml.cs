using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DynamicObserverSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        dynamic ObservableEmployee = null;

        public MainWindow()
        {
            InitializeComponent();

            var employee = new Employee();
            ObservableEmployee = new DynamicObservable(employee);
            var employeeView = new EmployeeView();

            employeeView.DataSource = ObservableEmployee;

            DataContext = employeeView;
            ObservableEmployee.Number = 100;
            ObservableEmployee.Name = "Cool!";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ObservableEmployee.Number++;
            ObservableEmployee.Name += "!";
        }
    }
}
