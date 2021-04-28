using Game.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        static Asteroid[] _asteroids;
        static Star[] _stars;
        static Planet[] _planets;
        static Comet[] _comets;

        public static int Width { get; set; }
        public static int Height { get; set; }

        static Game() { }


        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer { Interval = 60 };
            timer.Tick += OnTick;
            timer.Start();

        }

        private static void OnTick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.DrawImage(Resources.background, new Rectangle(new Point(0, 0), new Size(800, 600)));

            foreach (var planet in _planets)
                planet.Draw();

            foreach (var asteroid in _asteroids)
                asteroid.Draw();

            foreach (var star in _stars)
                star.Draw();

            foreach (var comet in _comets)
                comet.Draw();

            Buffer.Render();
        }

        public static void Update()
        {
            foreach (var asteroid in _asteroids)
                asteroid.Update();

            foreach (var star in _stars)
                star.Update();

            foreach (var comet in _comets)
                comet.Update();
        }

        public static void Load()
        {
            var random = new Random();

            _asteroids = new Asteroid[10];
            for (int i = 0; i < _asteroids.Length; i++)
            {
                var size = random.Next(10, 40);
                _asteroids[i] = new Asteroid(new Point(600, i * 20), new Point(-i, -i), new Size(size, size), random.Next(1, 4));
            }

            _stars = new Star[10];
            for (int i = 0; i < _stars.Length; i++)
            {
                var size = random.Next(30, 40);
                _stars[i] = new Star(new Point(600, i * 40), new Point(-i, -i), new Size(size, size), random.Next(1, 3));
            }

            _comets = new Comet[10];
            for (int i = 0; i < _comets.Length; i++)
			{
                var size = random.Next(2, 10);
                _comets[i] = new Comet(new Point(600, i * 60), new Point(-i, -i), new Size(size, size));
            }

            _planets = new Planet[2]
            {
                new Planet(new Point(100, 100), new Point(0, 0), new Size(200, 200)),
                new Planet(new Point(600, 300), new Point(0, 0), new Size(100, 100))
            };
        }

    }
}
