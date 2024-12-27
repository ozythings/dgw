using System.Diagnostics;

namespace RainDroplets {
    public partial class RainSimulationControl : UserControl {
        private const int MAX_RAINDROPS = 300;
        private const float BASE_GRAVITY = 500f;
        private const float RAINDROP_BASE_SPEED = 5f;
        private const int POINTER_RADIUS = 10;

        private readonly Random random;
        private readonly System.Windows.Forms.Timer rainTimer;
        private readonly List<Raindrop> raindrops;
        private readonly Stopwatch stopwatch;
        private Point cursorPosition;

        public RainSimulationControl() {
            random = new Random();
            this.DoubleBuffered = true;
            this.Size = new Size(800, 600);  // Default size, can be customized
            raindrops = new List<Raindrop>();
            stopwatch = new Stopwatch();
            stopwatch.Start();

            rainTimer = new System.Windows.Forms.Timer();
            rainTimer.Interval = 1;
            rainTimer.Tick += RainTimer_Tick;
            rainTimer.Start();

            this.Paint += RainSimulationControl_Paint;
            this.MouseMove += RainSimulationControl_MouseMove;
        }

        private void RainTimer_Tick(object sender, EventArgs e) {
            float deltaTime = (float)stopwatch.ElapsedMilliseconds / 1000f;
            stopwatch.Restart();

            if (raindrops.Count < MAX_RAINDROPS) {
                float angle = (float)(random.NextDouble() * Math.PI / 4);
                float horizontalSpeed = (float)Math.Cos(angle) * RAINDROP_BASE_SPEED;
                float verticalSpeed = (float)Math.Sin(angle) * RAINDROP_BASE_SPEED;

                raindrops.Add(new Raindrop {
                    Position = new PointF(random.Next(0, this.ClientSize.Width), -10),
                    Velocity = new PointF(horizontalSpeed, verticalSpeed)
                });
            }

            for (int i = 0; i < raindrops.Count; i++) {
                var drop = raindrops[i];
                drop.Velocity = new PointF(drop.Velocity.X, drop.Velocity.Y + BASE_GRAVITY * deltaTime);
                drop.Position = new PointF(
                    drop.Position.X + drop.Velocity.X * deltaTime,
                    drop.Position.Y + drop.Velocity.Y * deltaTime
                );

                float dx = drop.Position.X - cursorPosition.X;
                float dy = drop.Position.Y - cursorPosition.Y;
                if (Math.Sqrt(dx * dx + dy * dy) < POINTER_RADIUS) {
                    // Normalize the direction vector
                    float distance = (float)Math.Sqrt(dx * dx + dy * dy);
                    float nx = dx / distance;
                    float ny = dy / distance;

                    // Add some randomness to make it more interesting
                    float speed = 50;
                    float randomAngle = (float)(random.NextDouble() * Math.PI / 4 - Math.PI / 8);
                    float cos = (float)Math.Cos(randomAngle);
                    float sin = (float)Math.Sin(randomAngle);

                    drop.Velocity = new PointF(
                        (nx * cos - ny * sin) * speed,
                        (nx * sin + ny * cos) * speed
                    );
                }

                if (drop.Position.Y > this.ClientSize.Height) {
                    raindrops.RemoveAt(i);
                    i--;
                }
            }
            this.Invalidate();
        }

        private void RainSimulationControl_MouseMove(object sender, MouseEventArgs e) {
            cursorPosition = e.Location;
        }

        private void RainSimulationControl_Paint(object sender, PaintEventArgs e) {
            foreach (var drop in raindrops) {
                e.Graphics.FillEllipse(Brushes.Blue, drop.Position.X, drop.Position.Y, 5, 5);
            }
            e.Graphics.FillEllipse(Brushes.Red, cursorPosition.X - POINTER_RADIUS,
                cursorPosition.Y - POINTER_RADIUS, POINTER_RADIUS * 2, POINTER_RADIUS * 2);
        }

        public class Raindrop {
            public PointF Position { get; set; }
            public PointF Velocity { get; set; }
        }
    }
}
