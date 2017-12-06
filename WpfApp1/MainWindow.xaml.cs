using Reactive.Bindings;
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

namespace WpfApp1
{
    public class RxVM
    {
        public ReactiveProperty<string> Str { get; private set; } = new ReactiveProperty<string>("aa");
        public ReactiveProperty<string> Str2 { get; private set; } = new ReactiveProperty<string>("");

        public RxVM()
        {
            Str.Subscribe(value => Str2.Value = value + "!");
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
            DataContext = new RxVM();
        }
    }
}
