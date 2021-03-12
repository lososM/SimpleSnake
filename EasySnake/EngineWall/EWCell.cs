using EasyConsoleSnake.Model;
using EasySnake.Model;

namespace EasySnake.EngineWall
{
    public class EWCell:BaseEngineWall
    {
        public override void GetMapWalls(GameController gamController)
        {
            base.GetMapWalls(gamController);

            Vector2 dir = new Vector2(1, 0);
            Vector2 startPos = new Vector2(0, Game.HEIGHT/2);
            CreateWall(dir, startPos, Game.WIDTH);

            dir = new Vector2(0, 1);
            startPos = new Vector2(Game.WIDTH / 2, 0);
            CreateWall(dir, startPos, Game.HEIGHT);
        }
    }
}
