using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using лаба99;

namespace ConsoleApp18
{
    internal class CarParkingArray
    {
        private CarParking[] arr; //Массив объектов
        public int Length => arr.Length; //Свойство для длины массива
        private static int objectCount; //Статическое поле для подсчета объектов класса

        //Конструктор класса, которые принимает размер массива и заполняет его рандомным образом
        public CarParkingArray(int length)
        {
            arr = new CarParking[length]; //Инициализация массива объектов заданного размера
            Random rand = new Random(); //Создание генератора случайных чисел
            for (int i = 0; i < length; i++) //Цикл для заполнения массива
            {
                //заполнение массива случайными числами
                int c = rand.Next(0, 1000);
                arr[i] = new CarParking(c, rand.Next(0, c));
            }
            objectCount++; //Увеличение счетчика объектов при создании нового экземпляра
        }
        public CarParkingArray()
        {
            arr = new CarParking[0];
        }
        public CarParkingArray(CarParkingArray other)
        {
            arr = new CarParking[other.Length];
            for (int i = 0;i < other.Length;i++)
            {
                arr[i] = new CarParking(other[i].NumSlots, other[i].NumCars);
            }
        }
        public void Show() //Метод для просмотра элементов массива
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Элемент {i+1}. Парковочные места: {arr[i].NumSlots}. Автомобили на парковке: {arr[i].NumCars}.");
            }
        }
        public CarParking this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                    return arr[index];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < arr.Length)
                    arr[index] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
