using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design23.Designs
{
    public abstract class AbstractMediator: IPurchase, ISaler, IComputerStock
    {
        protected Purchase _purchase;
        protected Saler _saler;
        protected ComputerStock _computerStock;
       
        protected AbstractMediator()
        {
            _purchase = new Purchase(this);
            _saler = new Saler(this);
            _computerStock = new ComputerStock(this);
        }
        public void BuyComputer(int number)
        {
            int saleStatus = _saler.GetSaleStatus();//已销售数量
            int buyNumber = number;
            int total = _computerStock.GetComputerNumber();
            Debug.WriteLine($"*获得当前销售状态，销售量为：{saleStatus}*");
            _computerStock.Decrease(saleStatus);
            if (saleStatus <= (total * 80/100))
            {
                buyNumber = number / 2;
                Debug.WriteLine($"*销售状态较差,现销售量小于现存量的百分之80，按原计划进货量的一半进货*");
                Debug.WriteLine($"*原计划购买{number}台，现购买{buyNumber}*");
            }
            else
            {
                Debug.WriteLine($"*销售状态良好,销售量已大于现存量的百分之80，按原计划进货*");
            }
           
            _computerStock.Increase(buyNumber);
        }
        public void SellComputer(int number)
        {
                if (_computerStock.GetComputerNumber() < number)
                {
                    Debug.WriteLine($"*库存不够，需要先购买*");
                    _purchase.BuyComputer(number);
                }
                _computerStock.Decrease(number);
        }

        public bool GetIsSale()
        {
            return this._saler.GetIsSale();
        }
        public void SetIsSale(bool isSale)
        {
            this._saler.SetIsSale(isSale);
        }
        public void ClearStock()
        {
            _saler.SellComputer(_computerStock.GetComputerNumber()); 
            _purchase.RefuseComputer();
        }

        public int GetComputerNumber()
        {
            return _computerStock.GetComputerNumber();
        }
    }
    public interface IPurchase
    {
        void BuyComputer(int number);
    }
    public interface ISaler
    {
        void SellComputer(int number);
        bool GetIsSale();
        void SetIsSale(bool isSale);
    }
    public interface IComputerStock
    {
        void ClearStock();
        int GetComputerNumber();
    }
    public class Mediator : AbstractMediator
    {
    }

    /// <summary>
    /// 库，销售，购买类之间的关系就是同事类
    /// </summary>
    public abstract class AbstractColleague
    {
        protected AbstractMediator _mediator;

        protected AbstractColleague(AbstractMediator mediator)
        {
            this._mediator = mediator;
        }
    }
    public class ComputerStock : AbstractColleague, IComputerStock
    {
        private static int COMPUTER_NUMBER ;
        public ComputerStock(AbstractMediator mediator) : base(mediator)
        {
        }
        public void Increase(int number)
        {
            COMPUTER_NUMBER += number;
            Debug.WriteLine($"-已增加{number}台-");
            ShowComputerNumber();

            base._mediator.SetIsSale(true);
        }
        public void Decrease(int number)
        {
            COMPUTER_NUMBER -= number;
            Debug.WriteLine($"-已减少{number}台-");
            ShowComputerNumber();
        }
        public void ClearStock()
        {
            Debug.WriteLine($"---正在清仓---");
            base._mediator.ClearStock();
            Debug.WriteLine($"---ENG 清仓成功 ENG--" );
        }

        private void ShowComputerNumber()
        {
            Debug.WriteLine($"---现库存数量为： {GetComputerNumber()}---");
        }  
    
        public int GetComputerNumber()
        {
            return COMPUTER_NUMBER;
        }

        public void SetComputerNumber(int number)
        {
            Debug.WriteLine($"--正在设置库存初始值为： {number}--");
            COMPUTER_NUMBER = number;
            ShowComputerNumber();
            base._mediator.SetIsSale(true);
            Debug.WriteLine($"---ENG 设置库存初始值成功 ENG--");
        }
    }
    public class Saler : AbstractColleague, ISaler
    {
        private bool IsSale { get; set; }

        public Saler(AbstractMediator mediator) : base(mediator)
        {
        }

        public int GetSaleStatus()
        {
            Random random = new Random(System.DateTime.Now.Millisecond);
            int saleStatus = random.Next(base._mediator.GetComputerNumber());
            Debug.WriteLine($"--正在获得当前销售情况为： {saleStatus}--");
            return saleStatus;
        }
        public void SellComputer(int number)
        {
            if (base._mediator.GetIsSale())
            {
                Debug.WriteLine($"--正在销售 {number} 台--");
                base._mediator.SellComputer(number);
            }
            else
            {
                Debug.WriteLine($"*当前销售状态为 否，不可以进行销售*");
            }
        }

        public bool GetIsSale()
        {
           return this.IsSale;
        }

        public void SetIsSale(bool isSale)
        {
            this.IsSale = isSale;
        }
    }
    public class Purchase : AbstractColleague, IPurchase
    {
        
        public Purchase(AbstractMediator mediator) : base(mediator)
        {
        }
        public void BuyComputer(int number)
        {
            Debug.WriteLine($"--正在采购{number}台--");
            base._mediator.BuyComputer(number);
        }
        public void RefuseComputer()
        {
            base._mediator.SetIsSale(false);
            Debug.WriteLine("--当前状态为：不再采购--");
        }
    }
}
