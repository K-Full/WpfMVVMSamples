using Reactive.Bindings;
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

namespace UserControllSample
{
    public class MainWindowViewModel
    {
        public ReactiveProperty<string> lab { get; private set; } = new ReactiveProperty<string>("tes");

        public ReactiveProperty<bool> IsChecked1 { get; private set; } = new ReactiveProperty<bool>(false);
        public ReactiveProperty<bool> IsChecked2 { get; private set; } = new ReactiveProperty<bool>(false);
        public ReactiveProperty<bool> IsChecked3 { get; private set; } = new ReactiveProperty<bool>(false);

        public ReactiveCommand LabPlus { get; private set; } = new ReactiveCommand();

        public MainWindowViewModel()
        {
            IsChecked2.Value = true;
            LabPlus.Subscribe(_ => lab.Value += "!");
        }
        
    }

    public class ViewModel2
    {
        public ReactiveProperty<string> Mystr { get; private set; } = new ReactiveProperty<string>("55");

    }

    public class ConbineViewModel
    {
        public MainWindowViewModel VM { get; set; } = new MainWindowViewModel();
        public ViewModel2 VM2 { get; set; } = new ViewModel2();
    }

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        //public MainWindowViewModel VM { get; set; } = null;
        //public ViewModel2 VM2 { get; set; } = null;

        public MainWindow()
        {
            InitializeComponent();

            // メンバ変数にVMを持ってthisを突っ込む方法
            //VM = new MainWindowViewModel();
            //VM2 = new ViewModel2();
            //DataContext = this;

            // VMをまとめたVMを作ってそれを突っ込む方法
            DataContext = new ConbineViewModel();

            // どちらにしてもxamlにはVM.IsChecked1.Valueのように書く
        }
        
    }
}
