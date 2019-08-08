using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApplication4.APS
{
    public class AyParticleSystem
    {
        public List<AyParticle> particles = new List<AyParticle>();

        public List<AyChamberBox> effectors = new List<AyChamberBox>();

        private AyVector2 gravity = new AyVector2(0, 100);

        public AyVector2 Gravity
        {
            get { return gravity; }
            set { gravity = value; }
        }


        public void emit(AyParticle particle)
        {
            particles.Add(particle);
        }


        public void simulate(double dt)
        {
            aging(dt);
            applyGravity();
            applyEffectors();
            kinematics(dt);
        }
        public void CreateEllipse(double x1, double y1, double size, Color fillColor, Color Stroke, Canvas ctx)
        {
            Ellipse e = new Ellipse();

            e.Width = size * 2;
            e.Height = size * 2;
            e.Stroke = new SolidColorBrush(Stroke);
            e.StrokeThickness = 1;
            e.Fill = new SolidColorBrush(fillColor);
            Canvas.SetLeft(e, (x1 - size));
            Canvas.SetTop(e, (y1 - size));
            ctx.Children.Add(e);
        }
        public void render(Canvas ctx)
        {
            int i = 0;
            foreach (var item in particles)
            {
                var p = particles[i];
                var alpha = 1 - p.Age / p.Life;
                byte R = (byte)Math.Floor((double)p.Color.R * 255);
                byte G = (byte)Math.Floor((double)p.Color.G * 255);
                byte B = (byte)Math.Floor((double)p.Color.B * 255);
                byte A = (byte)(alpha * 255);
                CreateEllipse(p.Position.X, p.Position.Y, p.Size, Color.FromArgb(A, R, G, B), Colors.Transparent, ctx);

                i++;
            }
        }

        private void kinematics(double dt)
        {
            for (int i = 0; i < particles.Count; i++)
            {
                var p = particles[i];
                p.Position = p.Position.Add(p.Velocity.Multiply(dt));
                p.Velocity = p.Velocity.Add(p.Acceleration.Multiply(dt));
            }
        }


        private void applyEffectors()
        {
            for (int i = 0; i < effectors.Count; i++)
            {
                var eft = effectors[i];
                for (int j = 0; j < particles.Count; j++)
                {
                    eft.Apply(particles[j]);
                }
            }
        }

        private void applyGravity()
        {
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Acceleration = this.gravity;
            }

        }

        private void aging(double dt)
        {
            for (var i = 0; i < particles.Count; )
            {
                var p = particles[i];
                p.Age += dt;
                if (p.Age >= p.Life)
                {
                    kill(i);
                }

                else
                    i++;
            }
        }
        public void kill(int index)
        {
            var sd = particles.Count - 1;

            if (particles.Count > 1)
                particles[index] = particles[sd];
            particles.RemoveAt(sd);
        }




    }


}
