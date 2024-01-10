using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace lab6_2
{
    public partial class Form1 : Form
    {
        private List<Planet> planets;
        private Timer timer;
        private Button centralButton;

        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
            InitializePlanets();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 40;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateCentralButtonPosition();
            foreach (var planet in planets)
            {
                UpdatePlanetPosition(planet);
            }

        }

        private void InitializePlanets()
        {
            planets = new List<Planet>
            {
                new Planet("Mercury", 50, 2, button1),
                new Planet("Venus", 80, 1.5, button2),
                new Planet("Earth", 110, 1, button3),
                new Planet("Mars", 150, 0.8, button4),
                new Planet("Jupiter", 220, 0.4, button5),
                new Planet("Saturn", 300, 0.3, button6),
                new Planet("Uranus", 400, 0.2, button7),
                new Planet("Neptune", 500, 0.15, button8),
                new Planet("Sun", 0, 0, button10)
            };

            centralButton = button10;
        }

        private void UpdatePlanetPosition(Planet planet)
        {
            double rotationSpeed = 0.1;
            double distanceMultiplier = 1.5;

            if (planet.Name != "Sun")
            {
                double angle = planet.CurrentAngle + planet.Speed * rotationSpeed;
                int x = (int)(planet.OrbitRadius * distanceMultiplier * Math.Cos(angle)) + centralButton.Location.X + centralButton.Width / 2;
                int y = (int)(planet.OrbitRadius * distanceMultiplier * Math.Sin(angle)) + centralButton.Location.Y + centralButton.Height / 2;

                planet.Button.Location = new Point(x - planet.Button.Width / 2, y - planet.Button.Height / 2);
                planet.CurrentAngle = angle;
            }
        }

        private void UpdateCentralButtonPosition()
        {
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            centralButton.Location = new Point(centerX - centralButton.Width / 2, centerY - centralButton.Height / 2);
        }
    }

    public class Planet
    {
        public string Name { get; }
        public double OrbitRadius { get; }
        public double Speed { get; }
        public Button Button { get; }
        public double CurrentAngle { get; set; }

        public Planet(string name, double orbitRadius, double speed, Button button)
        {
            Name = name;
            OrbitRadius = orbitRadius;
            Speed = speed;
            Button = button;
            CurrentAngle = 0;

            Button.FlatStyle = FlatStyle.Flat;
            Button.FlatAppearance.BorderSize = 0;

            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            buttonPath.AddEllipse(0, 0, button.Width, button.Height);
            button.Region = new Region(buttonPath);
        }
    }
}
