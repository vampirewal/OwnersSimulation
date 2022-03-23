using NPOI.POIFS.Properties;
using OwnersSimulation.Model.Equip;
using OwnersSimulation.Model.Self;
using OwnersSimulation.ViewModel.MainPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vampirewal.Core.SimpleMVVM;

namespace OwnersSimulation.View.CustomControls
{
    /// <summary>
    /// EquipBlock.xaml 的交互逻辑
    /// </summary>
    public partial class EquipBlock : UserControl
    {
        public EquipBlock()
        {
            InitializeComponent();
        }

        #region 事件
        /// <summary>
        /// 鼠标右键点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //var DiscipleVM = (sender as EquipBlock)?.DataContext as DiscipleInfoViewModel;

            //if (DiscipleVM!=null&&Equip!=null&&Equip.IsEquip)
            //{

            //    DiscipleVM.DtlEntity.TakeOffTheEquip(this.Equip);
            //}

            if (Equip != null)
            {
                MouseRightButtonDownCommand?.Execute(Equip);
            }
            
        }
        #endregion


        public Equipment Equip
        {
            get { return (Equipment)GetValue(EquipProperty); }
            set { SetValue(EquipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Equip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EquipProperty =
            DependencyProperty.Register("Equip", typeof(Equipment), typeof(EquipBlock), new PropertyMetadata(null, EquipChangedCallBack));

        private static void EquipChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var equip = d as EquipBlock;

            if (equip != null)
            {
                var aa = e.NewValue as Equipment;

                if (aa != null)
                {
                    //equip.tooltip.Visibility = Visibility.Visible;
                }
                else
                {
                    //equip.tooltip.Visibility = Visibility.Hidden;
                }
            }
        }


        public ICommand MouseRightButtonDownCommand
        {
            get { return (ICommand)GetValue(MouseRightButtonDownCommandProperty); }
            set { SetValue(MouseRightButtonDownCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MouseRightButtonDownCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MouseRightButtonDownCommandProperty =
            DependencyProperty.Register("MouseRightButtonDownCommand", typeof(ICommand), typeof(EquipBlock), new PropertyMetadata(null));






        public Brush EquipMetarialColor
        {
            get { return (Brush)GetValue(EquipMetarialColorProperty); }
            set { SetValue(EquipMetarialColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EquipMetarialColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EquipMetarialColorProperty =
            DependencyProperty.Register("EquipMetarialColor", typeof(Brush), typeof(EquipBlock), new PropertyMetadata(Brushes.Gray));


    }
}
