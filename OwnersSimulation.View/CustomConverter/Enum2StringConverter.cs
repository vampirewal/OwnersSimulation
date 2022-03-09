#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：Enum2StringConverter
// 创 建 者：杨程
// 创建时间：2022/3/8 15:49:31
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OwnersSimulation.View.CustomConverter
{
    public class Enum2StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value!=null)
            {
                Type type = value.GetType();
                FieldInfo field = type.GetField(value.ToString());
                DisplayAttribute displayAttribute = (DisplayAttribute)field.GetCustomAttribute(typeof(DisplayAttribute));
                return displayAttribute.Name ?? value.ToString();
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
