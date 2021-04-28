using Game.Properties;
using System;
using System.Drawing;

namespace Asteroids
{
	public class Bullet : BaseObject
	{
		public Bullet(Point position, Point offset, Size size) : base(position, offset, size) { }

		public override void Draw()
		{
			Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.laserRed011, new Size(Size.Width, Size.Height)), Position.X, Position.Y);
		}

		public override void Update()
		{
			Position.X += 3;
		}

		public void Destroyed()
		{
			Random random = new Random();
			Position.X = 0;
			Position.Y = random.Next(100, 500);
		}
	}
}
