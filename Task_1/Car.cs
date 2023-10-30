using System;
using System.Collections.Generic;
using task1;

namespace task_1
{
    public class Car : Vehicle
    {
        public int PassengerCapacity { get; set; }
        public List<Human> Passengers { get; } = new List<Human>();

        public Car(double speed, int capacity, int passengerCapacity) : base(speed, capacity)
        {
            PassengerCapacity = passengerCapacity;
        }

        public void BoardPassenger(Human passenger)
        {
            if (Passengers.Count < PassengerCapacity)
            {
                Passengers.Add(passenger);
                Console.WriteLine($"Passenger boarded the car. Current passenger count: {Passengers.Count}");
            }
            else
            {
                Console.WriteLine("Car is already full. Passenger cannot board.");
            }
        }

        public void DisembarkPassenger(Human passenger)
        {
            if (Passengers.Contains(passenger))
            {
                Passengers.Remove(passenger);
                Console.WriteLine($"Passenger disembarked from the car. Current passenger count: {Passengers.Count}");
            }
            else
            {
                Console.WriteLine("Passenger is not in the car. Cannot disembark.");
            }
        }

        public override void Move()
        {
            
            Console.WriteLine("Car is moving.");
        }
    }
}