#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：MapControl
// 创 建 者：杨程
// 创建时间：2022/2/28 18:37:44
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using OwnersSimulation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace OwnersSimulation.View.CustomControls.Map
{
    /// <summary>
    /// 地图控件
    /// </summary>
    public class MapControl : Button
    {
        static MapControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MapControl), new FrameworkPropertyMetadata(typeof(MapControl)));
        }

        private ResourceDictionary res => new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/OwnersSimulation.View;component/CustomControls/Map/MapStyles.xaml", UriKind.RelativeOrAbsolute)
        };

        public MapControl()
        {
            //构造函数
            this.Style = res["MapControl"] as Style;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            
        }


        /// <summary>
        /// 地图快
        /// </summary>
        public MapBlock Block
        {
            get { return (MapBlock)GetValue(BlockProperty); }
            set { SetValue(BlockProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Block.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BlockProperty =
            DependencyProperty.Register("Block", typeof(MapBlock), typeof(MapControl), new PropertyMetadata(null));


        
    }
}
