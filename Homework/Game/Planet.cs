using Game.Properties;
using System.Drawing;

namespace Asteroids
{
	class Planet : SpaceObject
	{
		public Planet(Point position, Point offset, Size size) : base(position, offset, size)
		{ }

		public override void Draw()
		{
			Game.Buffer.Graphics.DrawImage(Resources.planet, new Rectangle(Position, Size));
		}
	}
}
