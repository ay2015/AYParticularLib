using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication4.APS
{
    public class AyVector2
    {
        public AyVector2()
        {

        }
        public AyVector2(double _x, double _y)
        {
            this.X = _x;
            this.Y = _y;
        }
        private double x;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        private double y;


        public static AyVector2 Zero = new AyVector2(0, 0);
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        #region AY 拓展向量计算
        public AyVector2 Copy()
        {
            return new AyVector2(this.X, this.Y);
        }
        /// <summary>
        /// x的平方+y的平方
        /// 作者AY
        /// 时间：2016-6-30 16:20:46
        /// </summary>
        /// <returns></returns>
        public double Length()
        {
            return Math.Sqrt(this.X * this.X + this.Y * this.Y);
        }

        public double SqrLength()
        {
            return this.X * this.X + this.Y * this.Y;
        }
        /// <summary>
        /// 单位化向量
        /// 为了实现物体朝某个点移动，这里需要进行一个向量的计算
        /// 获取单位向量，因为向量是有方向的，所以点也就知道移动的方向
        /// 作者AY
        /// 时间2016-6-30 16:41:17
        /// </summary>
        /// <returns></returns>
        public AyVector2 Normalize()
        {
            var inv = 1 / this.Length();
            return new AyVector2(this.X * inv, this.Y * inv);
        }
        /// <summary>，反向量
        /// </summary>
        /// <returns></returns>
        public AyVector2 Negate()
        {
            return new AyVector2(-this.X, -this.Y);
        }

        /// <summary>
        /// 向量相加
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public AyVector2 Add(AyVector2 v)
        {
            return new AyVector2(this.X + v.X, this.Y + v.Y);
        }
        /// <summary>
        /// 向量相减
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public AyVector2 Subtract(AyVector2 v)
        {
            return new AyVector2(this.X - v.X, this.Y - v.Y);
        }

        /// <summary>
        /// 向量相乘
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public AyVector2 Multiply(double f)
        {
            return new AyVector2(this.X * f, this.Y * f);
        }

        /// <summary>
        /// 向量相除
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public AyVector2 Divide(double f)
        {
            var invf = 1 / f;
            return new AyVector2(this.X * invf, this.Y * invf);
        }

        /// <summary>
        /// 向量 点积运算
        /// 作者AY
        /// </summary>
        /// <returns></returns>
        public double Dot(AyVector2 v)
        {
            return this.X * v.X + this.Y * v.Y;
        }



        #endregion
    }





}
