using System;
using System.Collections.Generic;

namespace task_1
{
    public class TransportNetwork
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public void MoveAllVehicles()
        {
            foreach (var vehicle in vehicles)
            {
                vehicle.Move();
            }
        }
    }
}