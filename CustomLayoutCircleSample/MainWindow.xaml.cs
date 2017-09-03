using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CustomLayoutCircleSample
{
    public class VM
    {
        public ObservableCollection<int> Hours { get; set; } = new ObservableCollection<int>() { 24 }; // important this initialize.

        public VM()
        {
            Enumerable.Range(1, 23).ToList().ForEach((x) => Hours.Add(x));
        }
    }

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new VM();
        }
    }
}
