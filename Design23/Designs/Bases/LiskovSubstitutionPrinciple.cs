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
    /// 里氏转换
    /// </summary>
    public abstract class AbstractGun
    {
        public abstract void Shoot();
    }
    public class HandGun : AbstractGun
    {
        public override void Shoot()
        {
             Debug.WriteLine("手枪射击");
        }
    }
    /// <summary>
    /// 狙击枪
    /// </summary>
    public class RifleGun : AbstractGun
    {
        public override void Shoot()
        {
            Debug.WriteLine("狙击枪射击");
        }
    }

    public class AUGRifleGun : RifleGun
    {
        public void ZoomOut()
        {
            Debug.WriteLine("通过望远镜查看敌人");
        }
        public override void Shoot()
        {
            Debug.WriteLine("AUG 狙击枪 射击");
        }
    }

    /// <summary>
    /// 玩具枪
    /// </summary>
    public abstract class AbstractToyGun
    {

    }
    public class ToyGun: AbstractToyGun
    {
     
    }
    /// <summary>
    /// 狙击手
    /// </summary>
    public class Snipper
    {
        //在类中调用其他类时务必要使用父类或接口，如果不能使用父类或接口，则说明类的设计已经违背了里氏转换（简称LSP）原则
        //这边不能传入 父类：RifleGun 替换 AUGRifleGun，因为 ZoomOut 是子类特有的方法
        public void KillEnemy(AUGRifleGun augRifleGun)
        {
            augRifleGun.ZoomOut();
            augRifleGun.Shoot();
        }
    }
    public class Soldier
    {
        private AbstractGun _gun;

        public void SetGun(AbstractGun gun)
        {
            this._gun = gun;
        }
        public void KillEnemy()
        {
            Debug.WriteLine("士兵开始杀敌人");
            _gun.Shoot();
        }
    }

    public class Father
    {
        public void Walking(int a,int b)
        {
            Debug.WriteLine("a+b="+(a+b));
        }
    }
    public class Son:Father
    {
        public void Walking(string str)
        {
            Debug.WriteLine("I 'am " + str);
        }
    }
}
