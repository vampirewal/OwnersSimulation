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
using OwnersSimulation.Model;
using Vampirewal.Core.IoC;
using Vampirewal.Core.SimpleMVVM;
using Vampirewal.Core.WpfTheme.WindowStyle;

namespace OwnersSimulation.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [RegisterWindow(ViewKeys.MainView, RegisterWindowType.Window)]
    [VampirewalIoCRegister(ViewKeys.MainView, RegisterType.View)]
    public partial class MainWindow : MainWindowBase
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        [VampirewalIoCGetInstance(ViewModelKeys.MainViewModel)]
        public override ViewModelBase DataSource { get => base.DataSource; set => base.DataSource = value; }
    }
}
