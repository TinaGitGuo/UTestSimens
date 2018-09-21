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
    /// 好的气质类
    /// </summary>
    public interface IGreatTemperament
    {
        [Description("气质好")]
        void GreatTemperament();
    }
    /// <summary>
    /// 好的身体
    /// </summary>
    public interface IGoodBody
    {
        [Description("姣好的面孔")]
        void GoodLooking();
        [Description("好的身材")]
        void GoodFigue();
    }

    public interface IPettyAGirl: IGreatTemperament, IGoodBody
    {

    }
    public interface IPettyBGirl : IGreatTemperament 
    {

    }
    public class PettyAGirl : IPettyAGirl
    {
        private readonly string _name;

        public PettyAGirl(string name)
        {
            this._name = name;
        }
        public void GreatTemperament()
        {
             Debug.WriteLine("A类型美女" + _name + "：气质好");
        }

        public void GoodLooking()
        {
            Debug.WriteLine("A类型美女" + _name + "：脸蛋好");
        }

        public void GoodFigue()
        {
            Debug.WriteLine("A类型美女" + _name + "：身材好");
        }
    }
    public class PettyBGirl : IPettyBGirl
    {
        private readonly string _name;

        public PettyBGirl(string name)
        {
            this._name = name;
        }
        public void GreatTemperament()
        {
            Debug.WriteLine("B类型美女"+ _name + "：气质特别好");
        }
    }

    public interface ISearcher
    {
         void Show();
    }
    public  class  SearcherA: ISearcher
    {
        private readonly IPettyAGirl _pettyA ;

        public  SearcherA(IPettyAGirl pettyA)
        {
            this._pettyA = pettyA;
        }

        public void Show()
        {
            Debug.WriteLine("---信息如下---");
            _pettyA.GoodFigue();
            _pettyA.GoodLooking();
            _pettyA.GreatTemperament();
        }
    }
    public class SearcherB : ISearcher
    {
        private readonly IPettyBGirl _pettyB;

        public SearcherB(IPettyBGirl pettyB)
        {
            this._pettyB = pettyB;
        }
        public void Show()
        {
            Debug.WriteLine("---信息如下---");
            _pettyB.GreatTemperament(); 
        }
    }

}
