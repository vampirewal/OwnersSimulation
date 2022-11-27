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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OwnersSimulation.Model;

namespace OwnersSimulation.View.CustomControls.Map
{
    /// <summary>
    /// MapManager.xaml 的交互逻辑
    /// </summary>
    public partial class MapManager : UserControl
    {
        public MapManager()
        {
            InitializeComponent();

            //MapTools.Draw(Map);

            //SizeChanged += MapManager_SizeChanged;

            Map.SizeChanged += MapManager_SizeChanged;
        }

        private void MapManager_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //Map.Children.Clear();
            MapTools.FixedSizeDraw(Map);

            //foreach (var item in MapBlocks)
            //{
            //    DrawRectangle(Map, item);
            //}
        }

        ToolTip abc;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            abc = FindResource("aaa") as ToolTip;
        }

        #region 依赖属性

        #region 地图宽高

        /// <summary>
        /// 地图宽
        /// </summary>
        public double MapWidth
        {
            get { return (double)GetValue(MapWidthProperty); }
            set { SetValue(MapWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MapWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MapWidthProperty =
            DependencyProperty.Register("MapWidth", typeof(double), typeof(MapManager), new PropertyMetadata(1000d));



        /// <summary>
        /// 地图高
        /// </summary>
        public double MapHeight
        {
            get { return (double)GetValue(MapHeightProperty); }
            set { SetValue(MapHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MapHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MapHeightProperty =
            DependencyProperty.Register("MapHeight", typeof(double), typeof(MapManager), new PropertyMetadata(1000d));


        #endregion

        #region 地图点
        [Bindable(true)]
        public ObservableCollection<MapBlock> MapBlocks
        {
            get { return (ObservableCollection<MapBlock>)GetValue(MapBlocksProperty); }
            set { SetValue(MapBlocksProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MapBlocks.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MapBlocksProperty =
            DependencyProperty.Register("MapBlocks", typeof(ObservableCollection<MapBlock>), typeof(MapManager), new PropertyMetadata(null, OnMapBlocksChangedCallBack));

        private static void OnMapBlocksChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MapManager panel = d as MapManager;

            panel.MapControlCollectionChanged();
        }

        public void MapControlCollectionChanged()
        {
            if (MapBlocks is INotifyCollectionChanged)
            {
                (MapBlocks as INotifyCollectionChanged).CollectionChanged -= MapManager_CollectionChanged;
                (MapBlocks as INotifyCollectionChanged).CollectionChanged += MapManager_CollectionChanged; 
            }
        }

        private void MapManager_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        {
                            foreach (var item in e.NewItems)
                            {
                                var block = item as MapBlock;

                                DrawRectangle(Map, block);
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
        #endregion


        #endregion

        private void DrawRectangle(Panel panel,MapBlock mb)
        {
            double currentSize = 20d;

            //var Rectangle = new Rectangle()
            //{
            //    Width = currentSize,
            //    Height = currentSize,
            //    StrokeThickness=0.1,
            //    Cursor = Cursors.Hand,
            //    Stroke=Brushes.Black,
                
            //};

            //var button = new Button()
            //{
            //    Width = currentSize,
            //    Height = currentSize,
            //    BorderThickness=new Thickness(0.1),
            //    BorderBrush = Brushes.Black,
            //    Cursor=Cursors.Hand,
            //    Command=mb.ClickCommand,
            //    CommandParameter=mb
            //};

            var button = new MapControl()
            {
                Width = currentSize,
                Height = currentSize,
                BorderThickness = new Thickness(0.1),
                BorderBrush = Brushes.Black,
                Cursor = Cursors.Hand,
                Command = mb.ClickCommand,
                CommandParameter = mb,
                
            };

            Binding BlockBinding = new Binding();
            BlockBinding.Source = mb;
            BlockBinding.Path = new PropertyPath("Block");
            button.SetBinding(MapControl.BlockProperty, BlockBinding);
            //button.CommandParameter = button;

            switch (mb.MapType)
            {
                case MapType.Wild:
                    //Rectangle.Fill = Brushes.Gray;
                    button.Background = Brushes.Gray;
                    break;
                case MapType.Home:
                    //Rectangle.Fill = Brushes.Green;
                    button.Background = Brushes.Green;
                    break;
            }

            var translateTransform = new TranslateTransform(mb.PosX, mb.PosY);
            //Rectangle.RenderTransform = translateTransform;
            button.RenderTransform = translateTransform;

            //panel.Children.Add(Rectangle);
            panel.Children.Add(button);
        }

        private ToolTip CreateToolTip()
        {
            
            
            var toolTip = new ToolTip()
            {
                
            };


            return toolTip;
        }
    }
}
