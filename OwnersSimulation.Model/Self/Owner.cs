#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：Owner
// 创 建 者：杨程
// 创建时间：2022/2/28 14:05:47
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vampirewal.Core.Models;

namespace OwnersSimulation.Model.Self
{
    /// <summary>
    /// 掌门人
    /// </summary>
    public class Owner :BillBaseModel
    {
        private string _UnitedId;
        /// <summary>
        /// 门派ID
        /// </summary>
        public string UnitedId
        {
            get { return _UnitedId; }
            set { _UnitedId = value; DoNotify(); }
        }


        private string _OwnerName;
        /// <summary>
        /// 掌门姓名
        /// </summary>
        public string OwnerName
        {
            get { return _OwnerName; }
            set { _OwnerName = value;DoNotify(); }
        }

        private int _Level;
        /// <summary>
        /// 掌门等级
        /// </summary>
        public int Level
        {
            get { return _Level; }
            set { _Level = value; DoNotify(); }
        }


    }
}
