using OwnersSimulation.Model.Equip;
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

        }
        #endregion


        public Equipment Equip
        {
            get { return (Equipment)GetValue(EquipProperty); }
            set { SetValue(EquipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Equip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EquipProperty =
            DependencyProperty.Register("Equip", typeof(Equipment), typeof(EquipBlock), new PropertyMetadata(null,EquipChangedCallBack));

        private static void EquipChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var equip = d as EquipBlock;

            if (equip != null)
            {
                var aa=e.NewValue as Equipment;
            }
        }


        /// <summary>
        /// 是否显示装备使用者名字
        /// </summary>
        public bool IsShowOwnerDiscipleName
        {
            get { return (bool)GetValue(IsShowOwnerDiscipleNameProperty); }
            set { SetValue(IsShowOwnerDiscipleNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsShowOwnerDiscipleName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsShowOwnerDiscipleNameProperty =
            DependencyProperty.Register("IsShowOwnerDiscipleName", typeof(bool), typeof(EquipBlock), new PropertyMetadata(true));

        
    }
}
