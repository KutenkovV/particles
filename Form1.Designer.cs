namespace particles
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.lblDirection = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSpreading = new System.Windows.Forms.Label();
            this.tbSpreading = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblGraviton2 = new System.Windows.Forms.Label();
            this.tbGraviton1 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGraviton1 = new System.Windows.Forms.Label();
            this.tbGraviton2 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton2)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(9, 12);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(1023, 583);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(9, 616);
            this.tbDirection.Maximum = 359;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(142, 45);
            this.tbDirection.TabIndex = 1;
            this.tbDirection.Scroll += new System.EventHandler(this.tbDirection_Scroll);
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(151, 616);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(0, 13);
            this.lblDirection.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 598);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Направление";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 598);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Разброс";
            // 
            // lblSpreading
            // 
            this.lblSpreading.AutoSize = true;
            this.lblSpreading.Location = new System.Drawing.Point(315, 616);
            this.lblSpreading.Name = "lblSpreading";
            this.lblSpreading.Size = new System.Drawing.Size(0, 13);
            this.lblSpreading.TabIndex = 5;
            // 
            // tbSpreading
            // 
            this.tbSpreading.Location = new System.Drawing.Point(173, 616);
            this.tbSpreading.Maximum = 359;
            this.tbSpreading.Name = "tbSpreading";
            this.tbSpreading.Size = new System.Drawing.Size(142, 45);
            this.tbSpreading.TabIndex = 4;
            this.tbSpreading.Scroll += new System.EventHandler(this.tbSpreading_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 598);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Размер певого гравитона";
            // 
            // lblGraviton2
            // 
            this.lblGraviton2.AutoSize = true;
            this.lblGraviton2.Location = new System.Drawing.Point(486, 616);
            this.lblGraviton2.Name = "lblGraviton2";
            this.lblGraviton2.Size = new System.Drawing.Size(0, 13);
            this.lblGraviton2.TabIndex = 8;
            // 
            // tbGraviton1
            // 
            this.tbGraviton1.Location = new System.Drawing.Point(510, 616);
            this.tbGraviton1.Maximum = 359;
            this.tbGraviton1.Name = "tbGraviton1";
            this.tbGraviton1.Size = new System.Drawing.Size(142, 45);
            this.tbGraviton1.TabIndex = 7;
            this.tbGraviton1.Scroll += new System.EventHandler(this.tbGraviton1_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(522, 598);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Размер второго гравитона";
            // 
            // lblGraviton1
            // 
            this.lblGraviton1.AutoSize = true;
            this.lblGraviton1.Location = new System.Drawing.Point(652, 616);
            this.lblGraviton1.Name = "lblGraviton1";
            this.lblGraviton1.Size = new System.Drawing.Size(0, 13);
            this.lblGraviton1.TabIndex = 11;
            // 
            // tbGraviton2
            // 
            this.tbGraviton2.LargeChange = 15;
            this.tbGraviton2.Location = new System.Drawing.Point(344, 616);
            this.tbGraviton2.Maximum = 359;
            this.tbGraviton2.Name = "tbGraviton2";
            this.tbGraviton2.Size = new System.Drawing.Size(142, 45);
            this.tbGraviton2.TabIndex = 10;
            this.tbGraviton2.Scroll += new System.EventHandler(this.tbGraviton2_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(681, 598);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Вкл\\Выкл гравитацию";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(684, 616);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(105, 17);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Гравитация вкл";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(684, 639);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(113, 17);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.Text = "Гравитация выкл";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 745);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblGraviton1);
            this.Controls.Add(this.tbGraviton2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblGraviton2);
            this.Controls.Add(this.tbGraviton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSpreading);
            this.Controls.Add(this.tbSpreading);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.picDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar tbDirection;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSpreading;
        private System.Windows.Forms.TrackBar tbSpreading;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblGraviton2;
        private System.Windows.Forms.TrackBar tbGraviton1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblGraviton1;
        private System.Windows.Forms.TrackBar tbGraviton2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

