using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication4.APS;

namespace WpfApplication4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= MainWindow_Loaded;
            AyFramework.canvas = ctx;
            ctx.MouseMove += ctx_MouseMove;
            ctx.MouseLeftButtonUp += ctx_MouseLeftButtonUp;
        }

        void ctx_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AyFramework.clearCanvas();
            var point = e.GetPosition(ctx);

            var dt = 0.015;

            var ddd = Color.FromRgb(Convert.ToByte(rd.Next(0, 255)), Convert.ToByte(rd.Next(0, 255)), Convert.ToByte(rd.Next(0, 255)));

            AyFramework.stop();
            AyFramework.Start(() =>
            {
                ps.emit(new AyParticle(new AyVector2(point.X, point.Y), sampleDirection().Multiply(100), 1, ddd, 5));
                ps.simulate(dt);
                AyFramework.clearCanvas();
                ps.render(ctx);
            });


        }

        void ctx_MouseMove(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition(ctx);
            newMousePosition.X = point.X;
            newMousePosition.Y = point.Y;
            msgPoint.Text = point.ToString();
        }

        AyParticleSystem ps = new AyParticleSystem();
        AyVector2 newMousePosition = new AyVector2(0, 0);

        private void demo1_Click(object sender, RoutedEventArgs e)
        {
            AyFramework.clearCanvas();
            var position = new AyVector2(10, 200);
            var velocity = new AyVector2(50, -50);
            var acceleration = new AyVector2(0, 10);
            var dt = 0.1;

            AyFramework.Start(() =>
            {
                position = position.Add(velocity.Multiply(dt));
                velocity = velocity.Add(acceleration.Multiply(dt));
                ps.CreateEllipse(position.X, position.Y, 5, Colors.Green, Colors.Yellow, ctx);
            });

        }
        Random rd = new Random();

        /// <summary>
        /// 每帧会发射一个粒子，其位置在画布中间(200,200)，发射方向是360度，速率为100，生命为1秒，红色、半径为5象素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void demo2_Click(object sender, RoutedEventArgs e)
        {

            var dt = 0.01;
            AyFramework.Start(() =>
            {
                ps.emit(new AyParticle(new AyVector2(200, 200), sampleDirection().Multiply(100), 1, Colors.Green, 5));
                ps.simulate(dt);
                AyFramework.clearCanvas();
                ps.render(ctx);
            });

        }

        public AyVector2 sampleDirection()
        {
            var theta = rd.NextDouble() * 2 * Math.PI;
            return new AyVector2(Math.Cos(theta), Math.Sin(theta));
        }


        public AyVector2 sampleDirection2(double angle1, double angle2)
        {
            var t = rd.NextDouble();
            var theta = angle1 * t + angle2 * (1 - t);
            return new AyVector2(Math.Cos(theta), Math.Sin(theta));
        }

        public Color sampleColor(Color color1, Color color2)
        {
            var t = (float)rd.NextDouble();
            return color1.Multiply(t).Add(color2.Multiply(1 - t));
        }


        private void demo3_Click(object sender, RoutedEventArgs e)
        {
            ps.effectors.Add(new AyChamberBox(0, 0, 600, 400));
            var dt = 0.01;

            AyFramework.Start(() =>
            {
                ps.emit(new AyParticle(new AyVector2(100, 200),
                    sampleDirection2(Math.PI * 1.75, Math.PI * 2).Multiply(400),
                    6, sampleColor(Colors.Green, Colors.Yellow), 6));

                ps.simulate(dt);
                ps.render(ctx);

                var cnt = AyFramework.canvas.Children;
                if (cnt.Count > ps.particles.Count())
                {
                    int d = cnt.Count - ps.particles.Count();
                    AyFramework.canvas.Children.RemoveRange(0, d);
                }
            });
        }

        /// <summary>
        /// 第四个demo使用
        /// AY
        /// 时间：2016-7-1 16:50:44
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public double sampleNumber(double value1, double value2)
        {
            var t = rd.NextDouble();
            return value1 * t + value2 * (1 - t);
        }



        private void demo4_Click(object sender, RoutedEventArgs e)
        {
            ps.effectors.Add(new AyChamberBox(0, 0, 600, 400));
            var dt = 0.01;
            var oldMousePosition = AyVector2.Zero;

            AyFramework.Start(() =>
            {
                var velocity = newMousePosition.Subtract(oldMousePosition).Multiply(10);
                velocity = velocity.Add(sampleDirection2(0, Math.PI * 2).Multiply(20));
                var color = sampleColor(Colors.Red, Colors.Pink);
                var life = sampleNumber(2, 4);
                var size = sampleNumber(4, 8);
                ps.emit(new AyParticle(newMousePosition, velocity, life, color, size));
                oldMousePosition = newMousePosition;
                ps.simulate(dt);
                ps.render(ctx);

                var cnt = AyFramework.canvas.Children;
                if (cnt.Count > ps.particles.Count())
                {
                    int d = cnt.Count - ps.particles.Count();
                    AyFramework.canvas.Children.RemoveRange(0, d);
                }
             
            });
        }

        private void demo5_Click(object sender, RoutedEventArgs e)
        {

        }










    }
}
