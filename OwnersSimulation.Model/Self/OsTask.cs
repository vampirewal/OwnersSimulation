#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：OsTask
// 创 建 者：杨程
// 创建时间：2022/3/2 15:54:30
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vampirewal.Core.Models;

namespace OwnersSimulation.Model.Self
{
    /// <summary>
    /// 针对每张地图会出现的任务配置
    /// <para><paramref name="BillId"/>是地图的BillId</para>
    /// </summary>
    [SugarTable("Task")]
    public class OsTask:DetailBaseModel
    {
        private string _TaskName;
        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName
        {
            get { return _TaskName; }
            set { _TaskName = value;DoNotify(); }
        }

        private string _TaskDes;
        /// <summary>
        /// 任务描述
        /// </summary>
        public string TaskDes
        {
            get { return _TaskDes; }
            set { _TaskDes = value; DoNotify(); }
        }

        private TaskState _taskState= TaskState.WaitChoose;
        /// <summary>
        /// 任务状态
        /// </summary>
        public TaskState taskState
        {
            get { return _taskState; }
            set { _taskState = value; DoNotify(); }
        }


        private DateTime? _TaskStartTime;
        /// <summary>
        /// 任务开始时间
        /// </summary>
        public DateTime? TaskStartTime
        {
            get { return _TaskStartTime; }
            set { _TaskStartTime = value; DoNotify(); }
        }

        private DateTime? _TaskFinishedTime;
        /// <summary>
        /// 任务结束时间
        /// </summary>
        public DateTime? TaskFinishedTime
        {
            get { return _TaskFinishedTime; }
            set { _TaskFinishedTime = value; DoNotify(); }
        }


        private double _TaskCompleteTime;
        /// <summary>
        /// 任务经历时间(秒)
        /// </summary>
        public double TaskCompleteTime
        {
            get { return _TaskCompleteTime; }
            set { _TaskCompleteTime = value; DoNotify(); }
        }

        private int _TaskCompleteDifficulty;
        /// <summary>
        /// 任务完成难度
        /// </summary>
        public int TaskCompleteDifficulty
        {
            get { return _TaskCompleteDifficulty; }
            set { _TaskCompleteDifficulty = value; DoNotify(); }
        }

        private float _TaskRefreshTheProbability;
        /// <summary>
        /// 任务刷新概率
        /// </summary>
        public float TaskRefreshTheProbability
        {
            get { return _TaskRefreshTheProbability; }
            set { _TaskRefreshTheProbability = value; DoNotify(); }
        }

        private int _RewardDiamond;
        /// <summary>
        /// 灵石奖励
        /// </summary>
        public int RewardDiamond
        {
            get { return _RewardDiamond; }
            set { _RewardDiamond = value; DoNotify(); }
        }

        private int _RewardExp;
        /// <summary>
        /// 奖励经验值
        /// </summary>
        public int RewardExp
        {
            get { return _RewardExp; }
            set { _RewardExp = value; DoNotify(); }
        }

        private string _TaskCompletedPersonId;
        /// <summary>
        /// 任务完成人ID
        /// <para>对应弟子的<paramref name="DtlId"/></para>
        /// </summary>
        public string TaskCompletedPersonId
        {
            get { return _TaskCompletedPersonId; }
            set { _TaskCompletedPersonId = value; DoNotify(); }
        }

        
    }

    /// <summary>
    /// 任务状态
    /// </summary>
    public enum TaskState
    {
        /// <summary>
        /// 放弃
        /// </summary>
        [Display(Name ="放弃")]
        GiveUp=-1,
        /// <summary>
        /// 待选
        /// </summary>
        [Display(Name = "待选")]
        WaitChoose =0,
        /// <summary>
        /// 执行中
        /// </summary>
        [Display(Name = "执行中")]
        Doing =1,
        /// <summary>
        /// 完成
        /// </summary>
        [Display(Name = "完成")]
        Done =2
    }
}
