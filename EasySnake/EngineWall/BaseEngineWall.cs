using EasyConsoleSnake.Model;
using EasySnake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySnake
{
    public class BaseEngineWall
    {
		//есть штуки, которые можно унаследовать и переопределить
		GameObject[,] Walls = new GameObject[Game.WIDTH, Game.HEIGHT];
		GameController gamController;

		public virtual void GetMapWalls(GameController gamController)
        {
			this.gamController = gamController;
		}

		public void CreateWall(Vector2 dir, Vector2 StartPos, int mlong)
		{
			for (int i = 0; i < mlong; i++)
			{
				GameObject block = null;
				if (dir.y == 0)
					block = new GameObject(Game.VIEW_WALL, new Vector2((i + StartPos.x) * dir.x, StartPos.y));

				if (dir.x == 0)
					block = new GameObject(Game.VIEW_WALL, new Vector2(StartPos.x, (i + StartPos.y) * dir.y));
				gamController.Walls[block.position.x, block.position.y] = block;
				gamController.viewController.View(block);
			}
		}
	}
}
