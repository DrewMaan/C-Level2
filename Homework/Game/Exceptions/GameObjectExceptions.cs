using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
	class GameObjectException : Exception
	{
		Type typeObject;
		public GameObjectException(string message, Type type) : base(message)
		{
			typeObject = type;
		}

		public override string Message => base.Message;
		public override string Source { get => base.Source; set => base.Source = value; }
	}
}
