using System;
using System.Collections;

namespace Design23.Designs
{
    //public interface IEnumerator
    //{
    //    object Current
    //    {
    //        get;
    //    }
    //    bool MoveNext();
    //    void Reset();
    //}
    //public interface IEnumerable
    //{
    //    IEnumerator GetEnumerator();
    //}
    // public class ArrayList : IList, ICollection, IEnumerable, ICloneable
    //{
    //    ...
    //}
    public interface IProjectEnumerable : IEnumerable
    {
        //增加项目
        void Add(string name, int num, int cost);
        //从老板这里看到的就是项目信息
        string GetProjectInfo();
    }
    public class ProjectIEnumerator : IEnumerator
    {
        //所有的项目都放在ArrayList中
        private readonly ArrayList _projectList;
        private int _currentItem = -1;
        //构造函数传入projectList
        public ProjectIEnumerator(ArrayList projectList)
        {
            _projectList = projectList;
        }
        //取得下一个值
        //判断是否还有元素，必须实现
        public bool MoveNext()
        {
            _currentItem++;
            return !(_currentItem >= _projectList.Count || _projectList[_currentItem] == null);
        }
        public void Reset()
        {
            _currentItem = 0;
        }

        public object Current => _projectList[_currentItem];
    }
    public class ProjectEnumerable : IProjectEnumerable
    {
        //定义一个项目列表，说有的项目都放在这里
        private readonly ArrayList _projectList = new ArrayList();
        //项目名称
        private readonly string _name = "";
        //项目成员数量
        private readonly int _num;
        //项目费用
        private readonly int _cost;
        public ProjectEnumerable() { }
        //定义一个构造函数，把所有老板需要看到的信息存储起来
        public ProjectEnumerable(string name, int num, int cost)
        {
            //赋值到类的成员变量中
            _name = name;
            _num = num;
            _cost = cost;
        }
        //增加项目
        public void Add(string name, int num, int cost)
        {
            _projectList.Add(new ProjectEnumerable(name, num, cost));
        }
        //得到项目的信息
        public string GetProjectInfo()
        {
            string info = "";
            //获得项目的名称
            info = info + "项目名称是：" + _name;
            //获得项目人数
            info = info + "\t项目人数: " + _num;
            //项目费用
            info = info + "\t 项目费用：" + _cost;
            return info;
        }
        //获得一个可以被遍历的对象
        public IEnumerator GetEnumerator()
        {
            return new ProjectIEnumerator(_projectList);
        }
    }
    public class MyIteratorYield : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return 2;
            yield return 56;
            yield return 34;
        }
    }
}
