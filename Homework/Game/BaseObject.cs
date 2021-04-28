using System.Drawing;

namespace Asteroids
{
	public abstract class BaseObject : ICollision
	{
		protected Point Position;
		protected Point Offset;
		protected Size Size;

		public BaseObject(Point position, Point offset, Size size)
		{
			if ((position.X < 0 || position.X > Game.Width) || (position.Y < 0 || position.Y > Game.Height))
				throw new GameObjectException($"Не правильно заданы начальные координаты объека {GetType()}: " +
					$"Postion (X = {position.X}, Y = {position.Y}).", GetType());
			Position = position;

			if (offset.X > 40 || offset.Y > 40)
				throw new GameObjectException($"Задана слишком большая скорость для объекта {GetType()}: " +
					$"Offset (X = {offset.X}, Y = {offset.Y}).", GetType());
			Offset = offset;

			if (size.Width < 0 || size.Height < 0)
				throw new GameObjectException($"Заданы не правильные размеры для объекта {GetType()}: " +
					$"Size (Width = {size.Width}, Height = {size.Height}).", GetType());
			Size = size;
		}

		public Rectangle Rect => new Rectangle(Position, Size);

		public bool Collision(ICollision obj)
		{
			return obj.Rect.IntersectsWith(Rect);
		}

		public virtual void Draw()
		{
		}

		public abstract void Update();
	}
}
