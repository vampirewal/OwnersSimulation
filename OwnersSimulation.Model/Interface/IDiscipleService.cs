#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：IDiscipleService
// 创 建 者：杨程
// 创建时间：2022/3/23 10:23:13
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using OwnersSimulation.Model.Self;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnersSimulation.Model.Interface
{
    /// <summary>
    /// 弟子服务接口
    /// </summary>
    public interface IDiscipleService
    {
        /// <summary>
        /// 弟子
        /// </summary>
        ObservableCollection<Disciple> Disciples { get; }

        /// <summary>
        /// 招募弟子列表
        /// </summary>
        ObservableCollection<Disciple> RecruitDisciples { get; }

        /// <summary>
        /// 创建弟子到招募列表
        /// </summary>
        /// <param name="Count">生成数量</param>
        void CreateRecruitDisciple(int Count = 1);

        /// <summary>
        /// 招募弟子
        /// </summary>
        /// <param name="entity">要招募的弟子</param>
        /// <returns></returns>
        bool RecruitDisciple(Disciple entity);

        /// <summary>
        /// 设置弟子
        /// </summary>
        /// <param name="disciples"></param>
        void SetDisciples(List<Disciple> disciples);



        /// <summary>
        /// 获取单独姓名
        /// </summary>
        /// <returns></returns>
        string GetSingleName();

        /// <summary>
        /// 输入<paramref name="count"/>数量，批量获取姓名
        /// </summary>
        /// <param name="count">生成数量</param>
        /// <returns></returns>
        List<string> GetChineseNameByCount(int count);
    }
}
