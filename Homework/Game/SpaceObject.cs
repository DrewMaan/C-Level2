using System.Drawing;

namespace Asteroids
{
	class SpaceObject
	{
		protected Point Position;
		protected Point Offset;
		protected Size Size;

		public SpaceObject(Point position, Point offset, Size size)
		{
			Position = position;
			Offset = offset;
			Size = size;
		}

		public virtual void Draw()
		{
		}

		public virtual void Update()
		{
		}
	}
}
