using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design23.Designs.Bases
{
    public interface IBook
    {
        string GetName();
        decimal GetPrice();
        string GetAuthor();
    }

    public class NovelBook : IBook
    {
        private string _name;
        private decimal _price;
        private string _author;

        public NovelBook(string name, decimal price, string author)
        {
            this._name = name;
            this._author = author;
            this._price = price;
        }
        public string GetName()
        {
            return this._name;
        }

        public decimal GetPrice()
        {
            return this._price;
        }

        public string GetAuthor()
        {
            return this._author;
        }
    }
    /// <summary>
    /// 需求变化，添加打折价功能
    /// </summary>
    public class OffNovelBook : NovelBook
    {
        public OffNovelBook(string name, decimal price, string author) : base(name, price, author)
        {
        }

        public new decimal GetPrice()
        {
            //原价
            decimal origialPrice= base.GetPrice();
            decimal offPrice = 0;
            if (origialPrice > 50)
            {
                offPrice = origialPrice * 90/100;
            }
            else
            {
                offPrice = origialPrice * 80 / 100;
            }
            return offPrice;
        }
    }
    public class BookStore
    {
        public static ArrayList BookList = new ArrayList
        {
            new NovelBook("书1",24,"作者"),
            new NovelBook("书2",60,"作者2"),
            new NovelBook("书3",99,"作者3"),
        };
    }
    public class BookStore2
    {
        public static ArrayList BookList = new ArrayList
        {
            new OffNovelBook("书1",24,"作者"),
            new OffNovelBook("书2",60,"作者2"),
            new OffNovelBook("书3",99,"作者3"),
        };
    }
}
