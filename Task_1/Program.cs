using System;
using task1;
using task_1;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Car car = new Car(60, 4, 4);
            Bus bus = new Bus(40, 30, 30);
            Train train = new Train(100, 1000, 1000);

            
            Route route = new Route("City A", "City B");
            route.AddStop("Stop 1");
            route.AddStop("Stop 2");
            route.AddStop("Stop 3");

            route.AddPassenger("Stop 1", 10);
            route.AddPassenger("Stop 2", 20);
            route.AddPassenger("Stop 3", 30);

            
            route.PrintRouteInfo();

            
            TransportNetwork network = new TransportNetwork();
            network.AddVehicle(car);
            network.AddVehicle(bus);
            network.AddVehicle(train);

          
            network.MoveAllVehicles();

            
            string carOptimizedRoute = route.OptimizeRoute(car);
            string busOptimizedRoute = route.OptimizeRoute(bus);
            string trainOptimizedRoute = route.OptimizeRoute(train);

            Console.WriteLine("Optimized Routes:");
            Console.WriteLine($"Car: {carOptimizedRoute}");
            Console.WriteLine($"Bus: {busOptimizedRoute}");
            Console.WriteLine($"Train: {trainOptimizedRoute}");
        }
    }
}