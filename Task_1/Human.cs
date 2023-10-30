namespace task1
{
    public class Human
    {
        public double Speed { get; private set; }

        public Human(double speed)
        {
            Speed = speed;
        }

        public void Move()
        {
            Console.WriteLine("Human is moving.");
        }
    }
}