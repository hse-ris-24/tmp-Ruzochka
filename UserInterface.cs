using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using лаба99;

namespace лаба99
{
    internal class UserInterface
    {
        public CarParking InputData()
        {
            Console.WriteLine("Введите количество мест на парковке");
            bool isConverted;
            int numSlots, numCars;
            do
            {
                isConverted = Int32.TryParse(Console.ReadLine(), out numSlots);
                if (numSlots < 0 || numSlots > 10000) isConverted = false;
                if (!isConverted) Console.WriteLine("Количество парковочных мест должно быть в диапазоне от 0 до 10000");
            } while (!isConverted);

            Console.WriteLine("Введите количество автомобилей на парковке");
            do
            {
                isConverted = Int32.TryParse(Console.ReadLine(), out numCars);
                if (numCars < 0 || numCars > numSlots) isConverted = false;
                if (!isConverted) Console.WriteLine($"Количество автомобилей на парковке должно быть в диапазоне от 0 до {numSlots}");
            } while (!isConverted);

            return new CarParking(numSlots, numCars);
        }
        public static void Show(CarParking carParking)
        {
            Console.WriteLine($"Количество мест на парковке: {carParking.NumSlots}. Количество машин на парковке: {carParking.NumCars}");
        }
        public static void WrongNumSlots()
        {
            Console.WriteLine("Количество парковочных мест не может быть меньше 0");
        }
        public static void WrongNumCars()
        {
            Console.WriteLine("Количество машин на парковке не может быть меньше 0 и больше количества парковочных мест");
        }

    }
}

