using System.Collections;
using System.ComponentModel;

namespace Design23.Designs
{
    /// <summary>
    /// 组合模式, 以公司人员为例
    /// Corp 是公司的意思
    /// </summary>
    public abstract class AbstractCorp
    {
        //公司每个人都有名称
        private readonly string _name;
        //公司每个人都职位
        private readonly string _position;
        //公司每个人都有薪水
        private readonly int _salary;
        //父节点是谁
        private AbstractCorp _parent;
        protected AbstractCorp(string name, string position, int salary)
        {
            _name = name;
            _position = position;
            _salary = salary;
        }
        //获得员工信息
        public string GetInfo()
        {
            string info= "姓名：" + _name;
            info = info + "\t职位：" + _position;
            info = info + "\t薪水：" + _salary;
            return info;
        }
        //设置父节点
        public void SetParent(AbstractCorp _parent)
        {
            this._parent = _parent;
        }
        //增加一个叶子构件或树枝构件
        public abstract void Add(AbstractCorp component);
        //删除一个叶子构件或树枝构件
        public abstract void Remove(AbstractCorp component);
        //得到父节点
        public AbstractCorp GetParent()
        {
            return this._parent;
        }
    }
    public class CorpLeaf : AbstractCorp
    {
        //就写一个构造函数，这个是必需的
        public CorpLeaf(string name, string position, int salary) : base(name, position, salary)
        {
        }

        public override void Add(AbstractCorp component)
        {
            throw new System.NotImplementedException();
        }

        public override void Remove(AbstractCorp component)
        {
            throw new System.NotImplementedException();
        }
    }
    public class CorpBranch : AbstractCorp
    {
        //领导下边有哪些下级领导和小兵
        private readonly ArrayList _subordinateList = new ArrayList();
        //构造函数是必需的
        public CorpBranch(string name, string position, int salary) : base(name, position, salary)
        {

        }
        //我有哪些下属
        public ArrayList GetSubordinate()
        {
            return _subordinateList;
        }
        //增加一个下属，可能是小头目，也可能是个小兵
        public override void Add(AbstractCorp component)
        {
            component.SetParent(this); //设置父节点
            _subordinateList.Add(component);
        }

        public override void Remove(AbstractCorp component)
        {
            _subordinateList.Remove(component);
        }
    }

    public class CorpRoot
    {
        public static string GetTreeInfo(CorpBranch root)
        {
            ArrayList subordinateList = root.GetSubordinate();
            string info = "";
            foreach (AbstractCorp s in subordinateList)
            {
                info += $"{s.GetInfo()}\n\t";
                if (s is CorpBranch branch)
                { //是个小头目
                    info += $"{GetTreeInfo(branch)}";
                }
            }
            return info;
        }
        public static string GetParentTreeInfo(AbstractCorp sub)
        {
            string info = $"{sub.GetInfo() }  的领导 \n\t";
            if (sub.GetParent() is AbstractCorp parent )
            {  
                    info += GetParentTreeInfo(parent);
            }
            return info;
        }
    }
     
}
