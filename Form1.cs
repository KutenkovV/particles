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
            // в обработчике заносим положение мыши в переменные для хранения положения мыши
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;

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
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                emitter.GravitationY = 0;
            }

            if (radioButton1.Checked)
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

        // Кол-во частиц (баганутое)
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesPerTick = trackBar1.Value;
            trackBar1.Value = trackBar1.Value;
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
    }
}
