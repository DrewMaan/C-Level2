using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
	class Asteroid : SpaceObject
	{
		public Asteroid(Point Positionition, Point offset, Size size) : base(Positionition, offset, size)
		{ }

		public override void Draw()
		{
			Game.Buffer.Graphics.DrawEllipse(Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
		}

		public override void Update()
		{
			Position.X = Position.X + Offset.X;
			Position.Y = Position.Y + Offset.Y;

			if (Position.X < 0) Offset.X = -Offset.X;
			if (Position.X >= Game.Width) Offset.X = -Offset.X;

			if (Position.Y < 0) Offset.Y = -Offset.Y;
			if (Position.Y >= Game.Height) Offset.Y = -Offset.Y;
		}
	}
}
