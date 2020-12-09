using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace particles
{
    public class Particle
    {
        public float Life; // наша хпшка частицы

        public int Radius; // радиус ака размер нашей частицы
        public float X; // X и Y положение частицы в пространстве 
        public float Y;

        public float SpeedX; // скорость по оси X
        public float SpeedY; // скорость по оси Y

        public static Random rand = new Random();

        // конструктор по умолчанию
        public Particle()
        {
            var direction = (double)rand.Next(360);
            var speed = 1 + rand.Next(10);

            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            Radius = rand.Next(10);
            Life = 20 + rand.Next(100);
        }

        public virtual void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);
            int alpha = (int)(k * 255);


            var color = Color.FromArgb(alpha, Color.Black);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
    }

    public class RadarPoint : IImpactPoint
    {
        public HashSet<Particle> rad = new HashSet<Particle>();
        public HashSet<Particle> big = new HashSet<Particle>();
        public HashSet<Particle> small = new HashSet<Particle>();

        public int Power = 100; // размер кружка        

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + particle.Radius < Power / 2) // если частица оказалось внутри окружности
            {
                var color = particle as ParticleColorful;

                color.FromColor = (Color.Green);
                color.ToColor = (Color.Green);
                rad.Add(particle);

                if(particle.Radius > 5)
                {
                    big.Add(particle);
                } else if(particle.Radius < 5)
                {
                    small.Add(particle);
                }
            }
            else
            {
                // чистим наши хэш-листы
                rad.Remove(particle);
                big.Remove(particle);
                small.Remove(particle);

                var color = particle as ParticleColorful;

                color.FromColor = (Color.Gold);
                color.ToColor = Color.FromArgb(0, Color.Red);
            }
        }

        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                   new Pen(Color.Green),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );

            g.DrawString(
            $"\n{rad.Count} \nБольшие {big.Count} \nМаленькие {small.Count}",
            new Font("Verdana", 14),
            new SolidBrush(Color.White),
            X,
            Y
        );
        }
    }

    public class ParticleColorful : Particle
    {
        public Color FromColor;
        public Color ToColor;

        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }

        // переопределение нашей отрисовки
        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);

            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
    }
}
