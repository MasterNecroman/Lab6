using System;
using System.Collections.Generic;
using task1;

namespace task_1
{
    public class Train : Vehicle
    {
        public int PassengerCapacity { get; set; }
        public List<Human> Passengers { get; } = new List<Human>();

        public Train(double speed, int capacity, int passengerCapacity) : base(speed, capacity)
        {
            PassengerCapacity = passengerCapacity;
        }

        public void BoardPassenger(Human passenger)
        {
            if (Passengers.Count < PassengerCapacity)
            {
                Passengers.Add(passenger);
                Console.WriteLine($"Passenger boarded the train. Current passenger count: {Passengers.Count}");
            }
            else
            {
                Console.WriteLine("Train is already full. Passenger cannot board.");
            }
        }

        public void DisembarkPassenger(Human passenger)
        {
            if (Passengers.Contains(passenger))
            {
                Passengers.Remove(passenger);
                Console.WriteLine($"Passenger disembarked from the train. Current passenger count: {Passengers.Count}");
            }
            else
            {
                Console.WriteLine("Passenger is not on the train. Cannot disembark.");
            }
        }

        public override void Move()
        {
          
            Console.WriteLine("Train is moving.");
        }
    }
}