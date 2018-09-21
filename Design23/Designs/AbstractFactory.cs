using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design23.Designs
{
    public interface IHumanFactory
    {
        IHuman CreateWhiteHuman();
        IHuman CreateBlackHuman();
    }

    public class FemaleFactory : IHumanFactory
    {
        public IHuman CreateWhiteHuman()
        {
            return new FemaleWhiteHuman();
        }

        public IHuman CreateBlackHuman()
        {
            return new FemaleBlackHuman();
        }
    }
    public class MaleFactory : IHumanFactory
    {
        public IHuman CreateWhiteHuman()
        {
            return new MaleWhiteHuman();
        }

        public IHuman CreateBlackHuman()
        {
            return new MaleBlackHuman();
        }
    }
    public abstract class AbstractWhiteHuman : IHuman
    {
        public void Eat()
        {
            Debug.WriteLine("White Person is eatting");
        }

        public void Move()
        {
            Debug.WriteLine("White Person is Moving");
        }
        public abstract void GetSex();
    }

    public abstract class AbstractBlackHuman : IHuman
    {
        public void Eat()
        {
            Debug.WriteLine("Black Person is eatting");
        }

        public void Move()
        {
            Debug.WriteLine("Black Person is Moving");
        }

        public abstract void GetSex();
    }

    public class MaleWhiteHuman : AbstractWhiteHuman
    {
        public override void GetSex()
        {
            Debug.WriteLine("White Human, I 'am Men");
        }
    }
    public class FemaleWhiteHuman : AbstractWhiteHuman
    {
        public override void GetSex()
        {
            Debug.WriteLine("White Human, I 'am Women");
        }
    }
    public class MaleBlackHuman : AbstractBlackHuman
    {
        public override void GetSex()
        {
            Debug.WriteLine("Black Human, I 'am Men");
        }
    }
    public class FemaleBlackHuman : AbstractBlackHuman
    {
        public override void GetSex()
        {
            Debug.WriteLine("Black Human, I 'am Women");
        }
    }
    public interface IHuman
    {
        void Eat();
        void Move();
        void GetSex();
    }
}
