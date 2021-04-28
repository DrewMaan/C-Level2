using Game.Properties;
using System.Drawing;

namespace Asteroids
{
	class Star : SpaceObject
	{
        int typeId;    // 1-3
        public Star(Point position, Point offset, Size size, int typeId) : base(position, offset, size)
		{
            this.typeId = typeId;
        }

        public override void Draw()
        {
			switch (typeId)
			{
				case 1:
					Game.Buffer.Graphics.DrawImage(Resources.star1, new Rectangle(Position, Size));
					break;
				case 2:
					Game.Buffer.Graphics.DrawImage(Resources.star2, new Rectangle(Position, Size));
					break;
				case 3:
					Game.Buffer.Graphics.DrawImage(Resources.star3, new Rectangle(Position, Size));
					break;
				default:
					Game.Buffer.Graphics.DrawLine(Pens.White, Position.X, Position.Y, Position.X + Size.Width, Position.Y + Size.Height);
					Game.Buffer.Graphics.DrawLine(Pens.White, Position.X + Size.Width, Position.Y, Position.X, Position.Y + Size.Height);
					Game.Buffer.Graphics.DrawLine(Pens.White, Position.X + Size.Width / 2, Position.Y, Position.X + Size.Width / 2, Position.Y + Size.Height);
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
    }
}
