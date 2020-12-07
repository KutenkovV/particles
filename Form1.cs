using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace particles
{
    public partial class Form1 : Form
    {
        Emitter emitter; //эммитер без явного создания

        List<Emitter> emitters = new List<Emitter>();
        List<Particle> particles = new List<Particle>();

        GravityPoint point1; // добавил поле под первую точку
        RadarPoint point2; // добавил поле под вторую точку

        public Form1()
        {
            InitializeComponent();

            picDisplay.MouseWheel += picDisplay_MouseWheel;

            // привязали к пикчбоку изображения, чтоб можно было рисовать
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
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

            emitters.Add(this.emitter); // все равно добавляю в список emitters, чтобы он рендерился и обновлялся

            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };

            point2 = new RadarPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2,
            };


            // привязываем поля к эмиттеру
            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);

            /*
            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };

            // гравитон
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.25),
                Y = picDisplay.Height / 2
            });

            // в центре антигравитон
            emitter.impactPoints.Add(new AntiGravityPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2
            });

            // снова гравитон
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.75),
                Y = picDisplay.Height / 2
            }); */
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // обновляем систему каждый тик 

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black); // здесь задаем цвет фона
                emitter.Render(g); // Рендерим нашу кучу частицы
            }

            picDisplay.Invalidate(); //очень важный момент - обновляем picDisplay
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // в обработчике заносим положение мыши в переменные для хранения положения мыши
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;

            //!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!! а тут передаем положение мыши, в положение ПЕРВОГО гравитона
            //!!!!!!!!!!!!!!!!!!!!!!!
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
            lblSpreading.Text = $"{tbSpreading.Value}°"; // вывод значения
        }

        private void tbGraviton1_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton1.Value;
            lblGraviton1.Text = $"{tbGraviton1.Value}°"; // вывод значения
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            point2.Power = tbGraviton2.Value;
            lblGraviton2.Text = $"{tbGraviton2.Value}°"; // вывод значения
        }

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

        // наш скролл радара мышкой (косячный т.к. вылетает при выходе из диапозона)
        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                point2.Power = tbGraviton2.Value;
                tbGraviton2.Value = tbGraviton2.Value + 15;
            }
            else if (e.Delta < 0)
            {
                point2.Power = tbGraviton2.Value;
                tbGraviton2.Value = tbGraviton2.Value - 15;
            }
        }
    }
}
