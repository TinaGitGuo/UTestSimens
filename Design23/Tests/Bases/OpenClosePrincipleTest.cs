using System;
using System.Diagnostics;
using Design23.Designs.Bases;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests.Bases
{
    [TestClass]
    public class OpenClosePrincipleTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            foreach (NovelBook book in BookStore.BookList)
            {
                NovelBook novelBook = book;
                Debug.WriteLine("书名: " + novelBook.GetName());
                Debug.WriteLine("作者: " + novelBook.GetAuthor());
                Debug.WriteLine("原价: " + novelBook.GetPrice());
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            foreach (OffNovelBook book in BookStore2.BookList)
            {
                NovelBook novelBook = book;
                Debug.WriteLine("书名: " + novelBook.GetName());
                Debug.WriteLine("作者: " + novelBook.GetAuthor());
                Debug.WriteLine("原价: " + novelBook.GetPrice());

                OffNovelBook offNovelBook = book;
                Debug.WriteLine("打折价: " + offNovelBook.GetPrice());
            }
            //运行结果：
            //书名: 书1
            //作者: 作者
            //原价: 24
            //打折价: 19.2
            //书名: 书2
            //作者: 作者2
            //原价: 60
            //打折价: 54
            //书名: 书3
            //作者: 作者3
            //原价: 99
            //打折价: 89.1
        }
    }
}
