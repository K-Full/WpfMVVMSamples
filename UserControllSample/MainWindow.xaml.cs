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

namespace UserControllSample
{
    public class MainWindowViewModel
    {
        public ReactiveProperty<string> lab { get; private set; } = new ReactiveProperty<string>("tes");

        public ReactiveProperty<bool> IsChecked1 { get; private set; } = new ReactiveProperty<bool>(false);
        public ReactiveProperty<bool> IsChecked2 { get; private set; } = new ReactiveProperty<bool>(false);
        public ReactiveProperty<bool> IsChecked3 { get; private set; } = new ReactiveProperty<bool>(false);


        public MainWindowViewModel()
        {
            IsChecked1.Value = true;
        }
    }

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel VM = null;

        public MainWindow()
        {
            InitializeComponent();
            VM = new MainWindowViewModel();
            DataContext = VM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VM.lab.Value += "!";
        }
    }
}
