﻿using System;
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
    /// UnitedView.xaml 的交互逻辑
    /// </summary>
    [RegisterWindow(ViewKeys.UnitedView, RegisterWindowType.Page)]
    [VampirewalIoCRegister(ViewKeys.UnitedView, RegisterType.View)]
    public partial class UnitedView : AddOrEditUcViewBase
    {
        public UnitedView()
        {
            InitializeComponent();
        }
    }
}
