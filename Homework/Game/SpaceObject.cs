using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
