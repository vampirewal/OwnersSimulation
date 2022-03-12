#region << 文 件 说 明 >>
/*----------------------------------------------------------------
// 文件名称：Disciple
// 创 建 者：杨程
// 创建时间：2022/3/1 18:07:00
// 文件版本：V1.0.0
// ===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/
#endregion

using OwnersSimulation.Model.Component;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vampirewal.Core;
using Vampirewal.Core.Models;

namespace OwnersSimulation.Model.Self
{
    /// <summary>
    /// 徒弟
    /// <para>其中<paramref name="BillId"/>是<paramref name="师傅的BillId"/></para>
    /// </summary>
    public class Disciple : DetailBaseModel
    {
        public Disciple()
        {

        }

        private string _DName;
        /// <summary>
        /// 徒弟名称
        /// </summary>
        public string DName
        {
            get { return _DName; }
            set { _DName = value; DoNotify(); }
        }

        #region 升级相关
        private int _CurrentLevelMaxExp;
        /// <summary>
        /// 当前等级下升级需要的经验值
        /// </summary>
        public int CurrentLevelMaxExp
        {
            get { return _CurrentLevelMaxExp; }
            set { _CurrentLevelMaxExp = value; DoNotify(); }
        }

        private int _Exp;
        /// <summary>
        /// 当前经验值
        /// </summary>
        public int Exp
        {
            get { return _Exp; }
            set
            {
                ActionSet<int>(ref _Exp, value, (NewValue) =>
                {
                    if (NewValue >= CurrentLevelMaxExp)
                    {
                        LevelUp();
                    }
                });
            }
        }

        /// <summary>
        /// 涨经验
        /// </summary>
        /// <param name="exp">增加的经验值</param>
        public void AddExp(int exp)
        {
            int curexp = exp * (Genius / 100);

            Exp += curexp;
        }


        private int _Level;
        /// <summary>
        /// 弟子等级
        /// </summary>
        public int Level
        {
            get { return _Level; }
            set
            {

                //Set<int>(ref _Level, value, (NewValue) => 
                //{
                //    int cur=LevelUpHelper.GetInstance().GetCurrentLevelMaxExp(NewValue);
                //    if (Exp>=CurrentLevelMaxExp)
                //    {
                //        Exp = 0;
                //    }
                //    CurrentLevelMaxExp = cur;
                //});

                _Level = value;
                DoNotify();
            }
        }

        private void LevelUp()
        {
            Level++;
            CurrentLevelMaxExp = LevelUpHelper.GetInstance().GetCurrentLevelMaxExp(Level);
            Exp = 0;
        }
        #endregion

        #region 资质信息
        private int _Genius;
        /// <summary>
        /// 天赋指数（10-200）
        /// <para>经验获得的比例</para>
        /// </summary>
        public int Genius
        {
            get { return _Genius; }
            set
            {
                if (value < 10)
                    value = 10;
                if (value > 200)
                    value = 200;

                _Genius = value;
                DoNotify();
            }
        }

        private int _Power;
        /// <summary>
        /// 力量值
        /// <para>初始值在10-100之间</para>
        /// </summary>
        public int Power
        {
            get { return _Power; }
            set { _Power = value; DoNotify(); }
        }

        #endregion

        #region 徒弟类型
        [SugarColumn(IsIgnore = true, IsJson = false, NoSerialize = true)]
        public string GetDiscipleTypeDisplay
        {
            get
            {
                return discipleType.GetDisplay();
            }
        }

        private DiscipleType _discipleType;
        /// <summary>
        /// 徒弟类型
        /// </summary>
        public DiscipleType discipleType
        {
            get { return _discipleType; }
            set { _discipleType = value; DoNotify(); }
        }
        #endregion

        #region 徒弟性别
        [SugarColumn(IsIgnore = true, IsJson = false, NoSerialize = true)]
        public string GetGenderTypeDisplay
        {
            get
            {
                return genderType.GetDisplay();
            }
        }


        private GenderType _genderType;
        /// <summary>
        /// 徒弟性别
        /// </summary>
        public GenderType genderType { get => _genderType; set { _genderType = value; DoNotify(); } }
        #endregion
    }


}
