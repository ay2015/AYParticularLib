using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication4.APS
{
    public class AyChamberBox
    {
        public AyChamberBox(double _x1, double _y1, double _x2, double _y2)
        {
            this.x1 = _x1;
            this.x2 = _x2;
            this.y1 = _y1;
            this.y2 = _y2;
        }
        public double x1 { get; set; }

        public double x2 { get; set; }

        public double y1 { get; set; }

        public double y2 { get; set; }


        public void Apply(AyParticle particle)
        {
            if (particle.Position.X - particle.Size < x1 || particle.Position.X + particle.Size > x2)
                particle.Velocity.X = -particle.Velocity.X;

            if (particle.Position.Y - particle.Size < y1 || particle.Position.Y + particle.Size > y2)
                particle.Velocity.Y = -particle.Velocity.Y;
        }


    }
}
