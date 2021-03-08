namespace EasyConsoleSnake.Model
{
    class Food
    {
        public GameObject food { get; }
        public string Name { get; }
        public int Calories { get; }
        public Food(string name, int cal, GameObject food)
        {
            Name = name;
            Calories = cal;
            this.food = food;
        }
    }
}
