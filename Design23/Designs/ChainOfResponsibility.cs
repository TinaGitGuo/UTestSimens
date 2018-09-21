using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design23.Designs
{
     public interface IWomen
     {
         WomenLevelEnum GetLevel();
         string GetRequest();
     }
    public enum HandleLevelEnum
    {
        Father=1,
        Husband=2,
        Son=3
    }

    public enum WomenLevelEnum
    {
        Alone=0,
        Daughter=1,
        Wife=2,
        Mother=3
    }
    public abstract class AbstractHandler
    {
        private readonly HandleLevelEnum _levelEnum;
    
        public void HandleMessage(IWomen women ,int max=10)
        {
            if (max <= 0)
            {
                throw new Exception("Error：超过责任链的阀值，会影响性能");
            }
            if ((int)women.GetLevel() == (int)this._levelEnum)
            {
                this.Response(women);
            }
            else
            {
                if (this._nextHandler == null)
                    Debug.WriteLine($"-- {Enum.GetName(typeof( WomenLevelEnum), women.GetLevel()) } 没有地方请示，按不同意处理 --");
                else
                    this._nextHandler.HandleMessage(women, --max);
            }
        }

        protected AbstractHandler(HandleLevelEnum levelEnum)
        {
            this._levelEnum = levelEnum;
        }

        private AbstractHandler _nextHandler;
        public   void SetNext(AbstractHandler handler)
        {
            this._nextHandler = handler;
        }
        public  void Response(IWomen women)
        {
            Debug.WriteLine($"{Enum.GetName(typeof(HandleLevelEnum) , this._levelEnum)} 同意  {Enum.GetName(typeof(WomenLevelEnum), women.GetLevel())} {women.GetRequest()} 的请求 ");
        }
    }

    public class Father : AbstractHandler
    {
        public Father() : base(HandleLevelEnum.Father)
        {
            
        }
    }
    public class Husband : AbstractHandler
    {
        public Husband() : base(HandleLevelEnum.Husband)
        {

        }
    }
    public class Son : AbstractHandler
    {
        public Son() : base(HandleLevelEnum.Son)
        {

        }
    }

    public class Women : IWomen
    {
        private WomenLevelEnum LevelEnum { get; }
        private   string Request { get; }

        public Women(WomenLevelEnum levelEnum,string request)
        {
            this.LevelEnum = levelEnum;
            this.Request=request   ;
        }

        /// <inheritdoc />
        public WomenLevelEnum GetLevel()
        {
            return this.LevelEnum;
        }

        public string GetRequest()
        {
            return this.Request;
        }
    }
}
