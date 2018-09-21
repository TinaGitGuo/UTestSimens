using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design23.Designs
{
    public interface ISchoolReport
    {
       void Report();
       void Sign(string name);
    }

    public class OringalSchoolReport : ISchoolReport
    {
        public void Report()
        {
           Debug.WriteLine("您的儿子的分数为65分");
        }

        public void Sign(string name)
        {
            Debug.WriteLine($"家长签名为 ： {name}");
        }
    }
    public abstract class AbstractDecorator : ISchoolReport
    {
        private ISchoolReport _schoolReport;

        protected AbstractDecorator(ISchoolReport schoolReport)
        {
            this._schoolReport = schoolReport;
        }

        public void Report()
        {
            this._schoolReport.Report();
        }

        public void Sign(string name)
        {
            this._schoolReport.Sign(name);
        }
    }

    public class HighScoreDecorator : AbstractDecorator
    {
        public HighScoreDecorator(ISchoolReport schoolReport) : base(schoolReport)
        {
        }

        private void ReportHighScore()
        {
            Debug.WriteLine("最高分");
        }

        public new void Report()
        {
            this.ReportHighScore();
            base.Report();
        }
    }

    public class SortDecorator : AbstractDecorator
    {
        public SortDecorator(ISchoolReport schoolReport) : base(schoolReport)
        {
        }

        private void ReportSort()
        {
            Debug.WriteLine("排名");
        }

        public new void Report()
        {
            base.Report();
            this.ReportSort();
        }
    }
    public abstract class  AbstractSchoolReport
    {
       public abstract void Report();
       public abstract void Sign(string name);
    }

    public class OringalSchoolReport2 : AbstractSchoolReport
    {
        public override void Report()
        {
            Debug.WriteLine("您的儿子的分数为65分");
        }

        public override void Sign(string name)
        {
            Debug.WriteLine($"家长签名为 ： {name}");
        }
    }
    public abstract class AbstractDecorator2 : AbstractSchoolReport
    {
        private readonly AbstractSchoolReport _schoolReport;

        protected AbstractDecorator2(AbstractSchoolReport schoolReport)
        {
            this._schoolReport = schoolReport;
        }

        public override void Report()
        {
            this._schoolReport.Report();
        }

        public override void Sign(string name)
        {
            this._schoolReport.Sign(name);
        }
    }

    public class HighScoreDecorator2 : AbstractDecorator2
    {
        public HighScoreDecorator2(AbstractSchoolReport schoolReport) : base(schoolReport)
        {
        }

        private void ReportHighScore()
        {
            Debug.WriteLine("最高分");
        }

        public override void Report()
        {
            this.ReportHighScore();
            base.Report();
        }
    }

    public class SortDecorator2 : AbstractDecorator2
    {
        public SortDecorator2(AbstractSchoolReport schoolReport) : base(schoolReport)
        {
        }

        private void ReportSort()
        {
            Debug.WriteLine("排名");
        }

        public override void Report()
        {
            base.Report();
            this.ReportSort();
        }
    }
}
