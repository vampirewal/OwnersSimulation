#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：EquipMaterial2ColorConverter
// 创 建 者：杨程
// 创建时间：2022/3/22 19:52:32
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using OwnersSimulation.Model.Equip;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace OwnersSimulation.View.CustomConverter
{
    public class EquipMaterial2ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
            {
                var material = (EquipMaterial)value;

                switch (material)
                {
                    case EquipMaterial.Inferior:
                        return Brushes.DarkGray;
                    case EquipMaterial.General:
                        return Brushes.Gray;
                    case EquipMaterial.Good:
                        return Brushes.Green;
                    case EquipMaterial.Superior:
                        return Brushes.BlueViolet;
                    case EquipMaterial.Legend:
                        return Brushes.Purple;
                    case EquipMaterial.Artifact:
                        return Brushes.Orange;
                        
                }
            }
            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
