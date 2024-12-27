using System.Runtime.CompilerServices;

namespace dgw
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            label1 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            label19 = new Label();
            tabControl1 = new TabControl();
            tabPageTemp = new TabPage();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            tabPagePrec = new TabPage();
            tabControl2 = new TabControl();
            tabPageRain = new TabPage();
            cartesianChart4 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            tabPageSnow = new TabPage();
            cartesianChart5 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            tabPageWindS = new TabPage();
            cartesianChart2 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            tabPageWindD = new TabPage();
            cartesianChart3 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            tableLayoutPanel2 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            label15 = new Label();
            label_day4 = new Label();
            label14 = new Label();
            pictureBox7 = new PictureBox();
            label13 = new Label();
            label_day2 = new Label();
            label12 = new Label();
            label_day7 = new Label();
            label11 = new Label();
            label_day3 = new Label();
            label10 = new Label();
            label_day1 = new Label();
            label9 = new Label();
            label_day6 = new Label();
            label_day5 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label17 = new Label();
            label16 = new Label();
            pictureBox8 = new PictureBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            label8 = new Label();
            richTextBox1 = new RichTextBox();
            get_data_button = new Button();
            comboBoxOTime = new ComboBox();
            comboBoxOCity = new ComboBox();
            comboBoxODate = new ComboBox();
            comboBox1 = new ComboBox();
            refresh_button = new Button();
            progressBar2 = new ProgressBar();
            errorProvider1 = new ErrorProvider(components);
            old_refresh_button = new Button();
            panel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageTemp.SuspendLayout();
            tabPagePrec.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPageRain.SuspendLayout();
            tabPageSnow.SuspendLayout();
            tabPageWindS.SuspendLayout();
            tabPageWindD.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(tableLayoutPanel3);
            panel1.Controls.Add(tabControl1);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(pictureBox8);
            panel1.Font = new Font("Arial", 12F);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(802, 532);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 91);
            label1.Name = "label1";
            label1.Size = new Size(20, 18);
            label1.TabIndex = 47;
            label1.Text = "...";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.4545441F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.5454559F));
            tableLayoutPanel3.Controls.Add(label20, 0, 2);
            tableLayoutPanel3.Controls.Add(label21, 1, 0);
            tableLayoutPanel3.Controls.Add(label22, 1, 1);
            tableLayoutPanel3.Controls.Add(label23, 0, 0);
            tableLayoutPanel3.Controls.Add(label19, 1, 2);
            tableLayoutPanel3.Location = new Point(322, 9);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Size = new Size(473, 100);
            tableLayoutPanel3.TabIndex = 44;
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.Left;
            label20.AutoSize = true;
            label20.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label20.Location = new Point(3, 75);
            label20.Margin = new Padding(3, 3, 3, 0);
            label20.Name = "label20";
            label20.Size = new Size(48, 18);
            label20.TabIndex = 34;
            label20.Text = "Wind:";
            label20.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            label21.Anchor = AnchorStyles.Left;
            label21.AutoSize = true;
            label21.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label21.Location = new Point(218, 9);
            label21.Margin = new Padding(3, 3, 3, 0);
            label21.Name = "label21";
            label21.Size = new Size(48, 18);
            label21.TabIndex = 36;
            label21.Text = "Wind:";
            label21.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            label22.Anchor = AnchorStyles.Left;
            label22.AutoSize = true;
            label22.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.Location = new Point(218, 42);
            label22.Margin = new Padding(3, 3, 3, 0);
            label22.Name = "label22";
            label22.Size = new Size(105, 18);
            label22.TabIndex = 37;
            label22.Text = "Wind Degree:";
            label22.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            label23.Anchor = AnchorStyles.Left;
            label23.AutoSize = true;
            label23.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label23.Location = new Point(3, 9);
            label23.Margin = new Padding(3, 3, 3, 0);
            label23.Name = "label23";
            label23.Size = new Size(75, 18);
            label23.TabIndex = 38;
            label23.Text = "Pressure:";
            label23.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Left;
            label19.AutoSize = true;
            label19.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.Location = new Point(218, 75);
            label19.Margin = new Padding(3, 3, 3, 0);
            label19.Name = "label19";
            label19.Size = new Size(72, 18);
            label19.TabIndex = 35;
            label19.Text = "Humidity:";
            label19.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageTemp);
            tabControl1.Controls.Add(tabPagePrec);
            tabControl1.Controls.Add(tabPageWindS);
            tabControl1.Controls.Add(tabPageWindD);
            tabControl1.ItemSize = new Size(412, 24);
            tabControl1.Location = new Point(22, 118);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(777, 258);
            tabControl1.TabIndex = 43;
            // 
            // tabPageTemp
            // 
            tabPageTemp.Controls.Add(cartesianChart1);
            tabPageTemp.Location = new Point(4, 28);
            tabPageTemp.Name = "tabPageTemp";
            tabPageTemp.Size = new Size(769, 226);
            tabPageTemp.TabIndex = 0;
            tabPageTemp.Text = "Temperature";
            tabPageTemp.UseVisualStyleBackColor = true;
            // 
            // cartesianChart1
            // 
            cartesianChart1.BackColor = Color.White;
            cartesianChart1.Dock = DockStyle.Fill;
            cartesianChart1.Location = new Point(0, 0);
            cartesianChart1.Margin = new Padding(8, 7, 8, 7);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(769, 226);
            cartesianChart1.TabIndex = 39;
            // 
            // tabPagePrec
            // 
            tabPagePrec.Controls.Add(tabControl2);
            tabPagePrec.Location = new Point(4, 28);
            tabPagePrec.Name = "tabPagePrec";
            tabPagePrec.Size = new Size(755, 226);
            tabPagePrec.TabIndex = 4;
            tabPagePrec.Text = "Precipitation";
            tabPagePrec.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPageRain);
            tabControl2.Controls.Add(tabPageSnow);
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl2.Location = new Point(0, 0);
            tabControl2.Multiline = true;
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(755, 226);
            tabControl2.TabIndex = 0;
            // 
            // tabPageRain
            // 
            tabPageRain.Controls.Add(cartesianChart4);
            tabPageRain.Location = new Point(4, 25);
            tabPageRain.Name = "tabPageRain";
            tabPageRain.Size = new Size(747, 197);
            tabPageRain.TabIndex = 0;
            tabPageRain.Text = "Rain";
            tabPageRain.UseVisualStyleBackColor = true;
            // 
            // cartesianChart4
            // 
            cartesianChart4.BackColor = Color.White;
            cartesianChart4.Dock = DockStyle.Fill;
            cartesianChart4.Location = new Point(0, 0);
            cartesianChart4.Margin = new Padding(8, 7, 8, 7);
            cartesianChart4.Name = "cartesianChart4";
            cartesianChart4.Size = new Size(747, 197);
            cartesianChart4.TabIndex = 39;
            // 
            // tabPageSnow
            // 
            tabPageSnow.Controls.Add(cartesianChart5);
            tabPageSnow.Location = new Point(4, 25);
            tabPageSnow.Name = "tabPageSnow";
            tabPageSnow.Size = new Size(761, 197);
            tabPageSnow.TabIndex = 1;
            tabPageSnow.Text = "Snow";
            tabPageSnow.UseVisualStyleBackColor = true;
            // 
            // cartesianChart5
            // 
            cartesianChart5.BackColor = Color.White;
            cartesianChart5.Dock = DockStyle.Fill;
            cartesianChart5.Location = new Point(0, 0);
            cartesianChart5.Margin = new Padding(8, 7, 8, 7);
            cartesianChart5.Name = "cartesianChart5";
            cartesianChart5.Size = new Size(761, 197);
            cartesianChart5.TabIndex = 40;
            // 
            // tabPageWindS
            // 
            tabPageWindS.Controls.Add(cartesianChart2);
            tabPageWindS.Location = new Point(4, 28);
            tabPageWindS.Name = "tabPageWindS";
            tabPageWindS.Size = new Size(755, 226);
            tabPageWindS.TabIndex = 2;
            tabPageWindS.Text = "Wind Speed";
            tabPageWindS.UseVisualStyleBackColor = true;
            // 
            // cartesianChart2
            // 
            cartesianChart2.BackColor = Color.White;
            cartesianChart2.Dock = DockStyle.Fill;
            cartesianChart2.Location = new Point(0, 0);
            cartesianChart2.Margin = new Padding(4);
            cartesianChart2.Name = "cartesianChart2";
            cartesianChart2.Size = new Size(755, 226);
            cartesianChart2.TabIndex = 0;
            // 
            // tabPageWindD
            // 
            tabPageWindD.Controls.Add(cartesianChart3);
            tabPageWindD.Location = new Point(4, 28);
            tabPageWindD.Name = "tabPageWindD";
            tabPageWindD.Size = new Size(755, 226);
            tabPageWindD.TabIndex = 3;
            tabPageWindD.Text = "Wind Degree";
            tabPageWindD.UseVisualStyleBackColor = true;
            // 
            // cartesianChart3
            // 
            cartesianChart3.BackColor = Color.White;
            cartesianChart3.Dock = DockStyle.Fill;
            cartesianChart3.Location = new Point(0, 0);
            cartesianChart3.Margin = new Padding(3, 2, 3, 2);
            cartesianChart3.Name = "cartesianChart3";
            cartesianChart3.Size = new Size(755, 226);
            cartesianChart3.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 7;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857113F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.Controls.Add(pictureBox1, 0, 1);
            tableLayoutPanel2.Controls.Add(pictureBox2, 1, 1);
            tableLayoutPanel2.Controls.Add(pictureBox3, 2, 1);
            tableLayoutPanel2.Controls.Add(pictureBox4, 3, 1);
            tableLayoutPanel2.Controls.Add(pictureBox5, 4, 1);
            tableLayoutPanel2.Controls.Add(pictureBox6, 5, 1);
            tableLayoutPanel2.Controls.Add(label15, 6, 2);
            tableLayoutPanel2.Controls.Add(label_day4, 3, 0);
            tableLayoutPanel2.Controls.Add(label14, 5, 2);
            tableLayoutPanel2.Controls.Add(pictureBox7, 6, 1);
            tableLayoutPanel2.Controls.Add(label13, 4, 2);
            tableLayoutPanel2.Controls.Add(label_day2, 1, 0);
            tableLayoutPanel2.Controls.Add(label12, 3, 2);
            tableLayoutPanel2.Controls.Add(label_day7, 6, 0);
            tableLayoutPanel2.Controls.Add(label11, 2, 2);
            tableLayoutPanel2.Controls.Add(label_day3, 2, 0);
            tableLayoutPanel2.Controls.Add(label10, 1, 2);
            tableLayoutPanel2.Controls.Add(label_day1, 0, 0);
            tableLayoutPanel2.Controls.Add(label9, 0, 2);
            tableLayoutPanel2.Controls.Add(label_day6, 5, 0);
            tableLayoutPanel2.Controls.Add(label_day5, 4, 0);
            tableLayoutPanel2.Location = new Point(22, 382);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 18.75F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 62.5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 18.75F));
            tableLayoutPanel2.Size = new Size(780, 147);
            tableLayoutPanel2.TabIndex = 41;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.BackColor = Color.SkyBlue;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(16, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(80, 78);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top;
            pictureBox2.BackColor = Color.SkyBlue;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(127, 31);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(80, 78);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top;
            pictureBox3.BackColor = Color.SkyBlue;
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Location = new Point(238, 31);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(80, 78);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Top;
            pictureBox4.BackColor = Color.SkyBlue;
            pictureBox4.BorderStyle = BorderStyle.FixedSingle;
            pictureBox4.Location = new Point(349, 31);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(80, 78);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 18;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.Top;
            pictureBox5.BackColor = Color.SkyBlue;
            pictureBox5.BorderStyle = BorderStyle.FixedSingle;
            pictureBox5.Location = new Point(460, 31);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(80, 78);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 19;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Anchor = AnchorStyles.Top;
            pictureBox6.BackColor = Color.SkyBlue;
            pictureBox6.BorderStyle = BorderStyle.FixedSingle;
            pictureBox6.Location = new Point(571, 31);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(80, 78);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 20;
            pictureBox6.TabStop = false;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top;
            label15.AutoSize = true;
            label15.Location = new Point(682, 121);
            label15.Margin = new Padding(3, 3, 3, 0);
            label15.Name = "label15";
            label15.Size = new Size(82, 18);
            label15.TabIndex = 29;
            label15.Text = "0 °C / 0 °C";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_day4
            // 
            label_day4.Anchor = AnchorStyles.Top;
            label_day4.AutoSize = true;
            label_day4.Font = new Font("Arial", 12F);
            label_day4.Location = new Point(353, 4);
            label_day4.Margin = new Padding(3, 3, 3, 0);
            label_day4.Name = "label_day4";
            label_day4.Size = new Size(71, 18);
            label_day4.TabIndex = 3;
            label_day4.Text = "Thursday";
            label_day4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top;
            label14.AutoSize = true;
            label14.Location = new Point(570, 121);
            label14.Margin = new Padding(3, 3, 3, 0);
            label14.Name = "label14";
            label14.Size = new Size(82, 18);
            label14.TabIndex = 28;
            label14.Text = "0 °C / 0 °C";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox7
            // 
            pictureBox7.Anchor = AnchorStyles.Top;
            pictureBox7.BackColor = Color.SkyBlue;
            pictureBox7.BorderStyle = BorderStyle.FixedSingle;
            pictureBox7.Location = new Point(683, 31);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(80, 78);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 21;
            pictureBox7.TabStop = false;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top;
            label13.AutoSize = true;
            label13.Location = new Point(459, 121);
            label13.Margin = new Padding(3, 3, 3, 0);
            label13.Name = "label13";
            label13.Size = new Size(82, 18);
            label13.TabIndex = 27;
            label13.Text = "0 °C / 0 °C";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_day2
            // 
            label_day2.Anchor = AnchorStyles.Top;
            label_day2.AutoSize = true;
            label_day2.Font = new Font("Arial", 12F);
            label_day2.Location = new Point(134, 4);
            label_day2.Margin = new Padding(3, 3, 3, 0);
            label_day2.Name = "label_day2";
            label_day2.Size = new Size(66, 18);
            label_day2.TabIndex = 1;
            label_day2.Text = "Tuesday";
            label_day2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top;
            label12.AutoSize = true;
            label12.Location = new Point(348, 121);
            label12.Margin = new Padding(3, 3, 3, 0);
            label12.Name = "label12";
            label12.Size = new Size(82, 18);
            label12.TabIndex = 26;
            label12.Text = "0 °C / 0 °C";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_day7
            // 
            label_day7.Anchor = AnchorStyles.Top;
            label_day7.AutoSize = true;
            label_day7.Font = new Font("Arial", 12F);
            label_day7.Location = new Point(693, 4);
            label_day7.Margin = new Padding(3, 3, 3, 0);
            label_day7.Name = "label_day7";
            label_day7.Size = new Size(60, 18);
            label_day7.TabIndex = 4;
            label_day7.Text = "Sunday";
            label_day7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top;
            label11.AutoSize = true;
            label11.Location = new Point(237, 121);
            label11.Margin = new Padding(3, 3, 3, 0);
            label11.Name = "label11";
            label11.Size = new Size(82, 18);
            label11.TabIndex = 25;
            label11.Text = "0 °C / 0 °C";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_day3
            // 
            label_day3.Anchor = AnchorStyles.Top;
            label_day3.AutoSize = true;
            label_day3.Font = new Font("Arial", 12F);
            label_day3.Location = new Point(232, 4);
            label_day3.Margin = new Padding(3, 3, 3, 0);
            label_day3.Name = "label_day3";
            label_day3.Size = new Size(91, 18);
            label_day3.TabIndex = 0;
            label_day3.Text = "Wednesday";
            label_day3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top;
            label10.AutoSize = true;
            label10.Location = new Point(126, 121);
            label10.Margin = new Padding(3, 3, 3, 0);
            label10.Name = "label10";
            label10.Size = new Size(82, 18);
            label10.TabIndex = 24;
            label10.Text = "0 °C / 0 °C";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_day1
            // 
            label_day1.Anchor = AnchorStyles.Top;
            label_day1.AutoSize = true;
            label_day1.Font = new Font("Arial", 12F);
            label_day1.Location = new Point(24, 4);
            label_day1.Margin = new Padding(3, 3, 3, 0);
            label_day1.Name = "label_day1";
            label_day1.Size = new Size(63, 18);
            label_day1.TabIndex = 2;
            label_day1.Text = "Monday";
            label_day1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.AutoSize = true;
            label9.Location = new Point(15, 121);
            label9.Margin = new Padding(3, 3, 3, 0);
            label9.Name = "label9";
            label9.Size = new Size(82, 18);
            label9.TabIndex = 23;
            label9.Text = "0 °C / 0 °C";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_day6
            // 
            label_day6.Anchor = AnchorStyles.Top;
            label_day6.AutoSize = true;
            label_day6.Font = new Font("Arial", 12F);
            label_day6.Location = new Point(576, 4);
            label_day6.Margin = new Padding(3, 3, 3, 0);
            label_day6.Name = "label_day6";
            label_day6.Size = new Size(70, 18);
            label_day6.TabIndex = 5;
            label_day6.Text = "Saturday";
            label_day6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_day5
            // 
            label_day5.Anchor = AnchorStyles.Top;
            label_day5.AutoSize = true;
            label_day5.Font = new Font("Arial", 12F);
            label_day5.Location = new Point(474, 4);
            label_day5.Margin = new Padding(3, 3, 3, 0);
            label_day5.Name = "label_day5";
            label_day5.Size = new Size(52, 18);
            label_day5.TabIndex = 6;
            label_day5.Text = "Friday";
            label_day5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label17, 1, 0);
            tableLayoutPanel1.Controls.Add(label16, 0, 0);
            tableLayoutPanel1.Location = new Point(108, 16);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(153, 67);
            tableLayoutPanel1.TabIndex = 40;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Arial", 15F);
            label17.ImageAlign = ContentAlignment.TopLeft;
            label17.Location = new Point(71, 3);
            label17.Margin = new Padding(3, 3, 3, 0);
            label17.Name = "label17";
            label17.Size = new Size(32, 23);
            label17.TabIndex = 32;
            label17.Text = "°C";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Dock = DockStyle.Top;
            label16.Font = new Font("Arial", 45F);
            label16.Location = new Point(3, 3);
            label16.Margin = new Padding(3, 3, 3, 0);
            label16.Name = "label16";
            label16.Size = new Size(62, 64);
            label16.TabIndex = 31;
            label16.Text = "0";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.White;
            pictureBox8.Location = new Point(22, 9);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(80, 80);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 30;
            pictureBox8.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(label8, 0, 0);
            tableLayoutPanel4.Controls.Add(richTextBox1, 0, 1);
            tableLayoutPanel4.Location = new Point(831, 158);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(137, 298);
            tableLayoutPanel4.TabIndex = 48;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Location = new Point(42, 3);
            label8.Margin = new Padding(3, 3, 3, 0);
            label8.Name = "label8";
            label8.Size = new Size(53, 15);
            label8.TabIndex = 15;
            label8.Text = "Location";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(3, 21);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(131, 274);
            richTextBox1.TabIndex = 12;
            richTextBox1.Text = "";
            // 
            // get_data_button
            // 
            get_data_button.Location = new Point(831, 100);
            get_data_button.Name = "get_data_button";
            get_data_button.Size = new Size(137, 23);
            get_data_button.TabIndex = 42;
            get_data_button.Text = "Get Old Data";
            get_data_button.UseVisualStyleBackColor = true;
            get_data_button.Click += get_data_button_Click;
            // 
            // comboBoxOTime
            // 
            comboBoxOTime.FormattingEnabled = true;
            comboBoxOTime.Location = new Point(831, 71);
            comboBoxOTime.Name = "comboBoxOTime";
            comboBoxOTime.Size = new Size(137, 23);
            comboBoxOTime.TabIndex = 4;
            // 
            // comboBoxOCity
            // 
            comboBoxOCity.FormattingEnabled = true;
            comboBoxOCity.Location = new Point(831, 14);
            comboBoxOCity.Name = "comboBoxOCity";
            comboBoxOCity.Size = new Size(137, 23);
            comboBoxOCity.TabIndex = 22;
            // 
            // comboBoxODate
            // 
            comboBoxODate.FormattingEnabled = true;
            comboBoxODate.Location = new Point(831, 43);
            comboBoxODate.Name = "comboBoxODate";
            comboBoxODate.Size = new Size(137, 23);
            comboBoxODate.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(831, 491);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(137, 23);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "City";
            comboBox1.Click += comboBox1_Click;
            // 
            // refresh_button
            // 
            refresh_button.Location = new Point(831, 520);
            refresh_button.Name = "refresh_button";
            refresh_button.Size = new Size(137, 23);
            refresh_button.TabIndex = 0;
            refresh_button.Text = "Refresh";
            refresh_button.UseVisualStyleBackColor = true;
            refresh_button.Click += refresh_button_Click;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(831, 462);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(137, 23);
            progressBar2.TabIndex = 5;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // old_refresh_button
            // 
            old_refresh_button.Location = new Point(831, 129);
            old_refresh_button.Name = "old_refresh_button";
            old_refresh_button.Size = new Size(137, 23);
            old_refresh_button.TabIndex = 43;
            old_refresh_button.Text = "Load Old Data";
            old_refresh_button.UseVisualStyleBackColor = true;
            old_refresh_button.Click += old_refresh_button_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(980, 556);
            Controls.Add(tableLayoutPanel4);
            Controls.Add(old_refresh_button);
            Controls.Add(get_data_button);
            Controls.Add(progressBar2);
            Controls.Add(comboBoxOTime);
            Controls.Add(panel1);
            Controls.Add(comboBox1);
            Controls.Add(refresh_button);
            Controls.Add(comboBoxOCity);
            Controls.Add(comboBoxODate);
            Name = "MainForm";
            Text = "dgw";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPageTemp.ResumeLayout(false);
            tabPagePrec.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPageRain.ResumeLayout(false);
            tabPageSnow.ResumeLayout(false);
            tabPageWindS.ResumeLayout(false);
            tabPageWindD.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button refresh_button;
        private ComboBox comboBox1;
        private ComboBox comboBoxOTime;
        private RichTextBox richTextBox1;
        private Label label_day3;
        private Label label_day5;
        private Label label_day6;
        private Label label_day7;
        private Label label_day4;
        private Label label_day1;
        private Label label_day2;
        private PictureBox pictureBox1;
        private Label label8;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private ComboBox comboBoxOCity;
        private ComboBox comboBoxODate;
        private Label label9;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label16;
        private PictureBox pictureBox8;
        private Label label19;
        private Label label20;
        private Label label23;
        private Label label22;
        private Label label21;
        private ProgressBar progressBar2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label17;
        private TableLayoutPanel tableLayoutPanel2;
        private Button get_data_button;
        private TabControl tabControl1;
        private TabPage tabPageTemp;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private TabPage tabPageWindS;
        private TabPage tabPageWindD;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart2;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart3;
        private TableLayoutPanel tableLayoutPanel3;
        private ErrorProvider errorProvider1;
        private Button old_refresh_button;
        private TabPage tabPagePrec;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart4;
        private Label label1;
        private TabControl tabControl2;
        private TabPage tabPageRain;
        private TabPage tabPageSnow;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart5;
        private TableLayoutPanel tableLayoutPanel4;
    }
}
