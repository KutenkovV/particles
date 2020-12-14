using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace particles
{
    public partial class Form1 : Form
    {
        Emitter emitter; //эммитер без явного создания

        List<Emitter> emitters = new List<Emitter>();
        List<Particle> particles = new List<Particle>(); // в душе не чаю гдеикак юзается (пока что)


        RadarPoint point2; // добавил поле под вторую точку (Радар)
        GravityPoint gravyPoint; 

        public Form1()
        {
            InitializeComponent();

            picDisplay.MouseWheel += picDisplay_MouseWheel;

            // привязали к пикчбоку изображения, чтоб можно было рисовать
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 1,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter); // добавляем эммитер в список эммитеров

            point2 = new RadarPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2,
            };

            // привязываем поля к эмиттеру
            emitter.impactPoints.Add(point2);
        }

        public bool start = true;

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState2();

            if (start == true)
            {
                emitter.UpdateState(); // обновляем систему каждый тик 
            }

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }

            foreach (var p in emitter.particles)
            {
                if (p.X > picDisplay.Width || p.Y > picDisplay.Height || p.X < 0 || p.Y < 0)
                {
                    p.Life = 0;
                }
            }

            picDisplay.Invalidate(); //очень важный момент - обновляем picDisplay
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;

            // в обработчике заносим положение мыши в переменные для хранения положения мыши
            point2.X = e.X;
            point2.Y = e.Y;
        }

        // направление струи
        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°"; // вывод значения
        }

        // разброс струи
        private void tbSpreading_Scroll(object sender, EventArgs e)
        {
            emitter.Spreading = tbSpreading.Value;

            // ниже просто плюшка не смотри на нее
            lblSpreading.Text = $"{tbSpreading.Value}°"; // вывод значения
        }

        // радиобаттоны работы гравитации
        private void GravyButton_CheckedChanged(object sender, EventArgs e)
        {
            if (buttonOFF.Checked)
            {
                emitter.GravitationY = 0;
            }

            if (buttonON.Checked)
            {
                emitter.GravitationY = 1;
            }
        }

        // наш скролл радара мышкой
        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if(point2.Power < 359)
                {
                    point2.Power += 15;
                }
            }
            else if (e.Delta < 0)
            {
                if (point2.Power > 10)
                {
                    point2.Power -= 15;
                }
            }
        }

        // Позунок кол-ва частиц
        private void PerTickCount_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesPerTick = tbPointsCount.Value;
            tbPointsCount.Value = tbPointsCount.Value;

            label7.Text = $"{tbPointsCount.Value}";
        }

        // кнопочка паузы
        private void button1_Click(object sender, EventArgs e)
        {
            start = false;
        }

        // кнопочка старта
        public void button2_Click(object sender, EventArgs e)
        {
            start = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            emitter.UpdateState(); // обновляем систему каждый тик 
        }

        private void picDisplay_Click(object sender, EventArgs e)
        {

        }

        private void picDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                emitter.impactPoints.Add(new GravityPoint
                {
                    X = e.X,
                    Y = e.Y,

                    Power = tbPowerGravity.Value,
                });
            }
            else
            {
                if (e.Button == MouseButtons.Right)
                {
                    foreach (var p in emitter.impactPoints)
                    {
                        if (p is GravityPoint)
                        {
                            var a = p as GravityPoint;
                            var x = a.X - e.X;
                            var y = a.Y - e.Y;

                            double r = Math.Sqrt(x * x + y * y);
                            if (r <= a.Power / 2)
                            {
                                emitter.impactPoints.Remove(p as GravityPoint);
                                break;
                            }
                        }
                    }
                }
            }
        }

        // ползунок грави точек
        private void GravyPointsPower_Scroll(object sender, EventArgs e)
        {
            tbPowerGravity.Value = tbPowerGravity.Value;

            foreach (var R in emitter.impactPoints)
            {
                if (R is GravityPoint)
                {
                    (R as GravityPoint).Power = tbPowerGravity.Value;
                }
            }

            label5.Text = $"{tbPowerGravity.Value}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
