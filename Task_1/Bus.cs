using System;
using System.Collections.Generic;
using task1;

namespace task_1
{
    public class Bus : Vehicle
    {
        public int PassengerCapacity { get; set; }
        public List<Human> Passengers { get; } = new List<Human>();

        public Bus(double speed, int capacity, int passengerCapacity) : base(speed, capacity)
        {
            PassengerCapacity = passengerCapacity;
        }

        public void BoardPassenger(Human passenger)
        {
            if (Passengers.Count < PassengerCapacity)
            {
                Passengers.Add(passenger);
                Console.WriteLine($"Passenger boarded the bus. Current passenger count: {Passengers.Count}");
            }
            else
            {
                Console.WriteLine("Bus is already full. Passenger cannot board.");
            }
        }

        public void DisembarkPassenger(Human passenger)
        {
            if (Passengers.Contains(passenger))
            {
                Passengers.Remove(passenger);
                Console.WriteLine($"Passenger disembarked from the bus. Current passenger count: {Passengers.Count}");
            }
            else
            {
                Console.WriteLine("Passenger is not on the bus. Cannot disembark.");
            }
        }

        public override void Move()
        {
            
            Console.WriteLine("Bus is moving.");
        }
    }
}