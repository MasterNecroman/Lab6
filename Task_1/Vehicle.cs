namespace task_1
{
    public abstract class Vehicle
    {
        public double Speed { get; private set; }
        public int Capacity { get; private set; }

        public Vehicle(double speed, int capacity)
        {
            Speed = speed;
            Capacity = capacity;
        }

        public abstract void Move();
    }
}