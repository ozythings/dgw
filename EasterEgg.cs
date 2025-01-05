using System.Media;
using dgw;

namespace EasterEgg {
    public partial class FormEE : Form {
        private int dx = 5;
        private int dy = 5;
        private bool is_dragging = false;
        private Point drag_offset;
        private bool is_bouncing = false;

        private PictureBox pictureBox1;
        private Button exit_button;

        public SoundPlayer player;

        // this could be referenced as MainForm but this allow Form argument in constructor method
        // in this way we could also use other forms
        private Form main_form; // reference to MainForm

        public FormEE(Form parent_form) {
            main_form = parent_form; // store reference to MainForm
            InitializeComponent();
            Setup();
            player = new SoundPlayer($"./easteregg/easteregg.wav");
        }

        private void Setup() {
            pictureBox1 = new PictureBox {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(168, 145),
                Location = new Point(10, 10),
                BackColor = Color.Red
            };
            Controls.Add(pictureBox1);

            pictureBox1.Image = Image.FromFile($"./easteregg/easteregg.png");

            exit_button = new Button {
                Text = "Exit",
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                // main_form is just a Form reference here, so we explicitly cast it
                Size = ((MainForm)main_form).buttonPlay.Size,
                Location = new Point(ClientSize.Width - 85, ClientSize.Height - 40),
            };

            exit_button.Click += (s, e) => {
                player.Stop();
                main_form.Location = this.Location;
                main_form.Show(); // show MainForm when exiting
                Close();
            };
            Controls.Add(exit_button);

            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;

            Resize += FormEE_Resize;

            var timer = new System.Windows.Forms.Timer {
                Interval = 5
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            if (!is_bouncing || is_dragging) return;

            pictureBox1.Left += dx;
            pictureBox1.Top += dy;

            if (pictureBox1.Right >= ClientSize.Width || pictureBox1.Left <= 0) {
                dx = -dx;
            }

            if (pictureBox1.Bottom >= ClientSize.Height || pictureBox1.Top <= 0) {
                dy = -dy;
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                is_dragging = true;
                drag_offset = new Point(e.X, e.Y);
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (is_dragging) {
                int new_x = e.X + pictureBox1.Left - drag_offset.X;
                int new_y = e.Y + pictureBox1.Top - drag_offset.Y;

                new_x = Math.Max(0, Math.Min(ClientSize.Width - pictureBox1.Width, new_x));
                new_y = Math.Max(0, Math.Min(ClientSize.Height - pictureBox1.Height, new_y));

                pictureBox1.Left = new_x;
                pictureBox1.Top = new_y;
            }
        }

        private void FormEE_Resize(object sender, EventArgs e) {
            int max_x = ClientSize.Width - pictureBox1.Width;
            int max_y = ClientSize.Height - pictureBox1.Height;

            if (pictureBox1.Left > max_x) {
                pictureBox1.Left = max_x;
            }
            if (pictureBox1.Top > max_y) {
                pictureBox1.Top = max_y;
            }

            pictureBox1.Left = Math.Max(0, pictureBox1.Left);
            pictureBox1.Top = Math.Max(0, pictureBox1.Top);

            exit_button.Location = new Point(ClientSize.Width - 85, ClientSize.Height - 40);
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                is_dragging = false;
            }
        }

        private void InitializeComponent() {
            SuspendLayout();

            this.ClientSize = main_form.ClientSize;
            this.Location = main_form.Location;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Name = "FormEE";
            Load += FormEE_Load;
            ResumeLayout(false);
        }

        private void FormEE_Load(object sender, EventArgs e) {
            pictureBox1.Visible = true;
            is_bouncing = true;
            player.Play();
            main_form.Hide(); // hide MainForm when FormEE loads
        }
    }
}

