using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
	class Planet : SpaceObject
	{
		public Planet(Point position, Point offset, Size size) : base(position, offset, size)
		{ }

		public override void Draw()
		{
			Game.Buffer.Graphics.FillEllipse(Brushes.Red, Position.X, Position.Y, Size.Width, Size.Height);
		}
	}
}
