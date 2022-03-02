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

using OwnersSimulation.Model.Map;
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
    public class MapControl : Canvas
    {
        static MapControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MapControl), new FrameworkPropertyMetadata(typeof(MapControl)));
        }


        

        [Bindable(true)]
        public ObservableCollection<MapBlock> MapBlocks
        {
            get { return (ObservableCollection<MapBlock>)GetValue(MapBlocksProperty); }
            set { SetValue(MapBlocksProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MapBlocks.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MapBlocksProperty =
            DependencyProperty.Register("MapBlocks", typeof(ObservableCollection<MapBlock>), typeof(MapControl), new PropertyMetadata(default, OnMapBlocksChangedCallBack));
        //上面是实现依赖属性

        //响应数据源的变化，只有在界面初始化的时候会进来一次，所以进来的时候，就要给这个控件添加数据源变化的事件监听
        private static void OnMapBlocksChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MapControl panel = d as MapControl;

            panel.MapControlCollectionChanged();
        }

        //监听就在这里
        public void MapControlCollectionChanged()
        {
            if (MapBlocks is INotifyCollectionChanged)
            {
                (MapBlocks as INotifyCollectionChanged).CollectionChanged -= MapControl_CollectionChanged;
                (MapBlocks as INotifyCollectionChanged).CollectionChanged += MapControl_CollectionChanged;
            }
        }

        private void MapControl_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        {
                            foreach (var item in e.NewItems)
                            {
                                var mapblock = item as MapBlock;
                                if (mapblock == null)
                                    return;

                                MapBlockControl map = new MapBlockControl()
                                {
                                    PosX = mapblock.PosX,
                                    PosY = mapblock.PosY,
                                    IsSelected = mapblock.IsSelected,
                                    //Width=20,
                                    //Height=20
                                };

                                //map.BorderThickness = new Thickness(0.2);
                                //map.BorderBrush = new SolidColorBrush(Colors.BlueViolet);
                                //map.Background=new SolidColorBrush(Colors.White);
                                map.DragStarted += Map_DragStarted;
                                map.DragDelta += Map_DragDelta;
                                map.DragCompleted += Map_DragCompleted;
                                

                                //Border border = new Border()
                                //{
                                //    Width= map.PosX,
                                //    Height= mapblock.PosY,
                                //};
                                //border.Background = new SolidColorBrush(Colors.BlueViolet);

                                Canvas.SetLeft(map, map.PosX*1);
                                Canvas.SetTop(map, map.PosY*1);
                                Canvas.SetZIndex(map, 1);

                                this.Children.Add(map);
                            }
                        }
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        {

                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Map_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            
        }

        private void Map_DragDelta(object sender, DragDeltaEventArgs e)
        {
            //MapBlockControl curThumb = (MapBlockControl)sender;

            //double nTop = Canvas.GetTop(curThumb) + e.VerticalChange;
            //double nLeft = Canvas.GetLeft(curThumb) + e.HorizontalChange;
            //Canvas.SetTop(curThumb, nTop);
            //Canvas.SetLeft(curThumb, nLeft);
        }

        private void Map_DragStarted(object sender, DragStartedEventArgs e)
        {
            MapBlockControl curThumb = (MapBlockControl)sender;



        }

        public MapControl()
        {
            //构造函数
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            
        }
    }

    public class MapBlockControl:Thumb
    {
        static MapBlockControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MapBlockControl), new FrameworkPropertyMetadata(typeof(MapBlockControl)));
        }


        private ResourceDictionary res
        {
            get
            {
                return new ResourceDictionary() { Source = new Uri("pack://application:,,,/OwnersSimulation.View;component/CustomControls/Map/MapStyles.xaml", UriKind.RelativeOrAbsolute) };
            }
        }

        public MapBlockControl()
        {
            var BaseStyle = res["MapBlockControl"] as Style;

            this.Style = BaseStyle;
        }


        public int PosX { get; set; }

        public int PosY { get; set; }

        public bool IsSelected { get; set; } = false;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

        }

        #region 地图属性
        /// <summary>
        /// 地图块宽
        /// </summary>
        public int MapWidth
        {
            get { return (int)GetValue(MapWidthProperty); }
            set { SetValue(MapWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MapWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MapWidthProperty =
            DependencyProperty.Register("MapWidth", typeof(int), typeof(MapBlockControl), new PropertyMetadata(10));



        /// <summary>
        /// 地图块高
        /// </summary>
        public int MapHeight
        {
            get { return (int)GetValue(MapHeightProperty); }
            set { SetValue(MapHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MapHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MapHeightProperty =
            DependencyProperty.Register("MapHeight", typeof(int), typeof(MapBlockControl), new PropertyMetadata(10));
        #endregion
    }
}
