namespace EasyConsoleSnake.Model
{
   public class Food
    {
        public string Name { get; }
        public GameObject gamObj { get; }
        public int Calories { get; }
        public Food(string name, GameObject gamObj, int cal)
        {
            Name = name;
            this.gamObj = gamObj;
            Calories = cal;
        }
        public Food(GameObject gamObj, int cal)//:base("Default food",gamObj,cal)
        {
            Name = "Default Food";
            this.gamObj = gamObj;
            Calories = cal;
        }
    }
}
