using Game.Properties;
using System;
using System.Drawing;

namespace Asteroids
{
	class Asteroid : BaseObject
	{
		int typeId;		//1-4
		public Asteroid(Point position, Point offset, Size size, int typeId) : base(position, offset, size)
		{
			this.typeId = typeId;
		}

		public override void Draw()
		{
			switch (typeId)
			{
				case 1:
					Game.Buffer.Graphics.DrawImage(Resources.meteorBrown_big1, new Rectangle(Position, Size));
					break;
				case 2:
					Game.Buffer.Graphics.DrawImage(Resources.meteorBrown_big2, new Rectangle(Position, Size));
					break;
				case 3:
					Game.Buffer.Graphics.DrawImage(Resources.meteorBrown_big3, new Rectangle(Position, Size));
					break;
				case 4:
					Game.Buffer.Graphics.DrawImage(Resources.meteorBrown_big4, new Rectangle(Position, Size));
					break;
				default:
					Game.Buffer.Graphics.DrawEllipse(Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
					break;
			}
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

		public void Destroyed(int x)
		{
			Random random = new Random();

			Position.X = x;
			Position.Y = random.Next(100, 500);
		}
	}
}
