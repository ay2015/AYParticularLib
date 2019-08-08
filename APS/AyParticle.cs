using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace WpfApplication4.APS
{
    public class AyParticle
    {
        public AyParticle(AyVector2 _position, AyVector2 _velocity, double _life, Color _color, double _size)
        {
            this.Position = _position;
            this.Velocity = _velocity;
            this.Life = _life;
            this.Color = _color;
            this.Size = _size;
        }

        private AyVector2 position;

        public AyVector2 Position
        {
            get { return position; }
            set { position = value; }
        }


        private AyVector2 velocity;

        public AyVector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        private double life;

        public double Life
        {
            get { return life; }
            set { life = value; }
        }


        private Color color;

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }


        private double size;

        public double Size
        {
            get { return size; }
            set { size = value; }
        }

        private AyVector2 acceleration = AyVector2.Zero;

        public AyVector2 Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }

        private double age = 0;

        public double Age
        {
            get { return age; }
            set { age = value; }
        }



    }
}
