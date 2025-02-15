using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class MyClass
    {
        public double TankVolume { get; private set; }
        public double GasolineAmount { get; private set; }
        public double GasolineConsumption100 { get; private set; }
        public double Mileage { get; private set; }
        public MyClass(double gasolineAmount, double mileage, double tankVolume = 50, double gasolineConsumption100 = 8.4) { GasolineAmount = gasolineAmount; Mileage = mileage; TankVolume = tankVolume; GasolineConsumption100 = gasolineConsumption100; }
        public (bool needRefuel, double distanceСovered) Drive(double distance)
        {
            bool needRefuel = false;
            double distanceСovered = 0;//преодолено расстояние
            for (double i = 0; i < distance; i += 0.1)//едем циклами по 100 метров
            {
                if ((GasolineAmount / TankVolume) * 100 < 10)
                {
                    needRefuel = true;
                    break;
                }
                var spentGasoline = (GasolineConsumption100 / 100) * 0.1;
                Mileage += i;
                GasolineAmount -= spentGasoline;
                distanceСovered += 0.1;
            }
            return (needRefuel, distanceСovered);
        }
    }
}
