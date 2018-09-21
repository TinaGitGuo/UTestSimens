using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Designs.Bases
{
    /// <summary>
    /// 迪米特法则
    /// </summary>
    public class Teacher
    {
        [Description("下达命令")]
        public void Commond(GroupLeader groupLeader)
        {
            groupLeader.CountGirls();
        }
    }
    /// <summary>
    /// 班长
    /// </summary>
    public class GroupLeader
    {
        private List<string> _girls;
        public GroupLeader(List<string> girls)
        {
            this._girls = girls;
        }

        public void CountGirls()
        {
            Debug.WriteLine("共有"+ _girls .Count()+"个女生");
        }
    }
}
