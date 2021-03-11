namespace EasyConsoleSnake.Model
{
    public class GameObject
    {
        public Vector2 position { get; set; }
        public char obj { get; }
        public GameObject(char obj)
        {
            this.obj = obj;
            position = new Vector2();
        }
        public GameObject(char obj,int x,int y)
        {
            this.obj = obj;
            position = new Vector2(x, y);
        }
        public GameObject(char obj, Vector2 pos)
        {
            this.obj = obj;
            position = pos;
        }
        public bool isHit(GameObject gamObj)
        {
            return isHit(gamObj.position);
        }
        public bool isHit(Vector2 vec)
        {
            if (position == vec) return true;
            return false;
        }
        public override int GetHashCode()
        {
            return position.GetHashCode();
        }
    }
}
