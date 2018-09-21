using System;
using System.Diagnostics;
using Design23.Designs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Design23.Tests 
{
    [TestClass]
    public class MediatorTest
    {
        [TestMethod]
        public void  TestMethod1()
        {
            AbstractMediator mediator=new Mediator();
            
            Purchase purchase=new Purchase(mediator);
            Saler saler = new Saler(mediator);
            ComputerStock computerStock = new ComputerStock(mediator);
            Debug.WriteLine($"设置库存初始值为： {100}");
            computerStock.SetComputerNumber(100);
             
            Debug.WriteLine($"计划购买 {20} 台");
            purchase.BuyComputer (20);

            Debug.WriteLine($"需要卖 {7} 台");
            saler.SellComputer(7);

            Debug.WriteLine($"清仓");
            computerStock.ClearStock();

            Debug.WriteLine($"需要卖 {1} 台");
            saler.SellComputer(1);

            Debug.WriteLine($"计划购买 {50} 台");
            purchase.BuyComputer(50);

            Debug.WriteLine($"需要卖 {10} 台");
            saler.SellComputer(10);


            Debug.WriteLine($"需要卖 {20} 台");
            saler.SellComputer(20);

            Debug.WriteLine($"计划购买 {30} 台");
            purchase.BuyComputer(30);

            //Debug Trace:
            //设置库存初始值为： 100
            //    --正在设置库存初始值为： 100--
            //    -- - 现库存数量为： 100-- -
            //    ---ENG 设置库存初始值成功 ENG--
            //    计划购买 20 台
            //    --正在采购20台--
            //    --正在获得当前销售情况为： 80--
            //    * 获得当前销售状态，销售量为：80 *
            //    -已减少80台 -
            //    ---现库存数量为： 20-- -
            //    *销售状态较差,现销售量小于现存量的百分之80，按原计划进货量的一半进货*
            //    * 原计划购买20台，现购买10 *
            //    -已增加10台 -
            //    ---现库存数量为： 30-- -
            //    需要卖 7 台
            //    --正在销售 7 台--
            //    - 已减少7台 -
            //    ---现库存数量为： 23-- -
            //    清仓
            //        -- - 正在清仓-- -
            //    --正在销售 23 台--
            //    - 已减少23台 -
            //    ---现库存数量为： 0-- -
            //    --当前状态为：不再采购--
            //    -- - ENG 清仓成功 ENG--
            //    需要卖 1 台
            //    * 当前销售状态为 否，不可以进行销售*
            //    计划购买 50 台
            //    --正在采购50台--
            //    --正在获得当前销售情况为： 0--
            //    * 获得当前销售状态，销售量为：0 *
            //    -已减少0台 -
            //    ---现库存数量为： 0-- -
            //    *销售状态较差,现销售量小于现存量的百分之80，按原计划进货量的一半进货*
            //    * 原计划购买50台，现购买25 *
            //    -已增加25台 -
            //    ---现库存数量为： 25-- -
            //    需要卖 10 台
            //    --正在销售 10 台--
            //    - 已减少10台 -
            //    ---现库存数量为： 15-- -
            //    需要卖 20 台
            //    --正在销售 20 台--
            //    * 库存不够，需要先购买 *
            //    --正在采购20台--
            //        --正在获得当前销售情况为： 4--
            //    * 获得当前销售状态，销售量为：4 *
            //    -已减少4台 -
            //    ---现库存数量为： 11-- -
            //    *销售状态较差,现销售量小于现存量的百分之80，按原计划进货量的一半进货*
            //    * 原计划购买20台，现购买10 *
            //    -已增加10台 -
            //    ---现库存数量为： 21-- -
            //    -已减少20台 -
            //    ---现库存数量为： 1-- -
            //    计划购买 30 台
            //    --正在采购30台--
            //    --正在获得当前销售情况为： 0--
            //    * 获得当前销售状态，销售量为：0 *
            //    -已减少0台 -
            //    ---现库存数量为： 1-- -
            //    *销售状态较差,现销售量小于现存量的百分之80，按原计划进货量的一半进货*
            //    * 原计划购买30台，现购买15 *
            //    -已增加15台 -
            //    ---现库存数量为： 16-- -
        }
    }
}
