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
using Vampirewal.Core.WpfTheme.UcView;

namespace OwnersSimulation.View
{
    /// <summary>
    /// DiscipleEquipTableView.xaml 的交互逻辑
    /// </summary>
    [RegisterWindow(ViewKeys.DiscipleEquipTableView, RegisterWindowType.Page)]
    [VampirewalIoCRegister(ViewKeys.DiscipleEquipTableView, RegisterType.View)]
    public partial class DiscipleEquipTableView : AddOrEditUcViewBase
    {
        public DiscipleEquipTableView()
        {
            InitializeComponent();
        }
    }
}
