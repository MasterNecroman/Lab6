using System;
using System.Collections.Generic;
using task1;

namespace task_1
{
    public class Route
    {
        public string StartLocation { get; }
        public string EndLocation { get; }
        public List<string> Stops { get; } = new List<string>();
        public Dictionary<string, int> Passengers { get; } = new Dictionary<string, int>();

        public Route(string startLocation, string endLocation)
        {
            StartLocation = startLocation;
            EndLocation = endLocation;
        }

        public void AddStop(string stop)
        {
            Stops.Add(stop);
        }

        public void AddPassenger(string stop, int count)
        {
            if (Passengers.ContainsKey(stop))
            {
                Passengers[stop] += count;
            }
            else
            {
                Passengers[stop] = count;
            }
        }

        public void PrintRouteInfo()
        {
            Console.WriteLine($"Route from {StartLocation} to {EndLocation} with stops:");
            foreach (var stop in Stops)
            {
                Console.WriteLine($"- {stop}");
            }

            Console.WriteLine("Passenger counts at each stop:");
            foreach (var kvp in Passengers)
            {
                Console.WriteLine($"- {kvp.Key}: {kvp.Value} passengers");
            }
        }

        public string OptimizeRoute(Vehicle vehicle)
        {
           
            if (vehicle is Car)
            {
               
                return "Optimized route for a car: ...";
            }
            else if (vehicle is Bus)
            {
               
                return "Optimized route for a bus: ...";
            }
            else if (vehicle is Train)
            {
               
                return "Optimized route for a train: ...";
            }
            else
            {
                return "Optimized route not calculated. Unknown type of vehicle.";
            }
        }
    }
}