#region << 文 件 说 明 >>
/******************************************************************************************************
*机器名称: DESKTOP-6RM95GA
*命名空间: OwnersSimulation.View.CustomControls.Map
*文 件 名: MapTools
*创 建 人: 杨程
*电子邮箱: 235160615@qq.com
*创建时间: 2022/5/5 13:53:19

*描述:
*
*******************************************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OwnersSimulation.View.CustomControls.Map
{
    /// <summary>
    /// 地图绘制助手
    /// </summary>
    public static class MapTools
    {
        /// <summary>
        /// 绘制网格线
        /// </summary>
        /// <param name="canvas">画布</param>
        /// <param name="GridScale">格子尺寸</param>
        public static void Draw(Canvas canvas, double GridScale=20)
        {
            var gridBrush = new SolidColorBrush { Color = Colors.White };

            double scaleX = GridScale;
            double currentPosY = 0;
            currentPosY += scaleX;
            while (currentPosY < canvas.ActualHeight)
            {
                Line line = new Line
                {
                    X1 = 0,
                    Y1 = currentPosY,
                    X2 = canvas.ActualWidth,
                    Y2 = currentPosY,
                    Stroke = gridBrush,
                    StrokeThickness = 0.1
                };
                canvas.Children.Add(line);

                currentPosY += scaleX;
            }

            double scaleY = GridScale;
            double currentPosX = 0;
            currentPosX += scaleY;
            while (currentPosX < canvas.ActualWidth)
            {
                Line line = new Line
                {
                    X1 = currentPosX,
                    Y1 = 0,
                    X2 = currentPosX,
                    Y2 = canvas.ActualHeight,
                    Stroke = gridBrush,
                    StrokeThickness = 0.1
                };
                canvas.Children.Add(line);

                currentPosX += scaleY;
            }
        }

        public static void FixedSizeDraw(Canvas canvas, double GridScale = 20)
        {
            var gridBrush = new SolidColorBrush { Color = Colors.White };

            double scaleX = GridScale;
            double currentPosY = 0;
            currentPosY += scaleX;
            while (currentPosY < canvas.Height)
            {
                Line line = new Line
                {
                    X1 = 0,
                    Y1 = currentPosY,
                    X2 = canvas.ActualWidth,
                    Y2 = currentPosY,
                    Stroke = gridBrush,
                    StrokeThickness = 0.1
                };
                canvas.Children.Add(line);

                currentPosY += scaleX;
            }

            double scaleY = GridScale;
            double currentPosX = 0;
            currentPosX += scaleY;
            while (currentPosX < canvas.Width)
            {
                Line line = new Line
                {
                    X1 = currentPosX,
                    Y1 = 0,
                    X2 = currentPosX,
                    Y2 = canvas.ActualHeight,
                    Stroke = gridBrush,
                    StrokeThickness = 0.1
                };
                canvas.Children.Add(line);

                currentPosX += scaleY;
            }
        }
    }
}
