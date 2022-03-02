using OwnersSimulation.Model;
using OwnersSimulation.Model.Self;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : VampirewalApplication
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SetAssembly(Assembly.GetExecutingAssembly());

            base.OnStartup(e);

            OpenWinodw(ViewKeys.LoginView);

        }
    }
}
