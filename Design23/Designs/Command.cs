using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design23.Designs
{
    /// <summary>
    /// 命令模式
    /// </summary>
    public abstract class AbstractGroup
    {
        public abstract void Find();
        public abstract void Add();
        public abstract void Delete();
        public abstract void Change();
        public abstract void Plan();

        public void RollBack()
        {
            Debug.WriteLine("根据日志，取消操作");
        }
    }

    public class CancelDeletePageCommand : Command
    {
        public override void Execute()
        {
             base.PageGroup.RollBack();
        }
    }
    public class CodeGroup : AbstractGroup
    {
        public override void Find()
        {
            Debug.WriteLine("Code Find");
        }

        public override void Add()
        {
            Debug.WriteLine("Code Add");
        }

        public override void Delete()
        {
            Debug.WriteLine("Code delete");
        }

        public override void Change()
        {
            Debug.WriteLine("Code Change");
        }

        public override void Plan()
        {
            Debug.WriteLine("Code Plan");
        }
    }
    public class PageGroup : AbstractGroup
    {
        public override void Find()
        {
            Debug.WriteLine("Page Find");
        }

        public override void Add()
        {
            Debug.WriteLine("Page Add");
        }

        public override void Delete()
        {
            Debug.WriteLine("Page Delete");
        }

        public override void Change()
        {
            Debug.WriteLine("Page Change");
        }

        public override void Plan()
        {
            Debug.WriteLine("Page Plan");
        }
    }
    public class RequirementGroup : AbstractGroup
    {
        public override void Find()
        {
            Debug.WriteLine("Requirement Find");
        }

        public override void Add()
        {
            Debug.WriteLine("Requirement Add");
        }

        public override void Delete()
        {
            Debug.WriteLine("Requirement Delete");
        }

        public override void Change()
        {
            Debug.WriteLine("Requirement Change");
        }

        public override void Plan()
        {
            Debug.WriteLine("Requirement Plan");
        }
    }

    public abstract class Command
    {
        protected RequirementGroup RequirementGroup = new RequirementGroup();
        protected PageGroup PageGroup = new PageGroup();
        protected CodeGroup CodeGroup = new CodeGroup();
        public abstract void Execute();
    }

    public class DeletePageCommand : Command
    {
        public override void Execute()
        {
            base.RequirementGroup.Find();
            base.PageGroup.Delete();
            base.CodeGroup.Plan();
        }
    }

    public class AddRequirementCommand : Command
    {
        //三个执行者共合作
        public override void Execute()
        {
            base.RequirementGroup.Find();
            base.CodeGroup.Find();
            base.RequirementGroup.Add();
            base.CodeGroup.Delete();
            base.RequirementGroup.Plan();
        }
    }

    public class Invoker
    {
        private Command _command;
        public void SetCommand(Command command)
        {
            this._command = command;
        }

        public void Action()
        {
            this._command.Execute();
        }
    }
}
