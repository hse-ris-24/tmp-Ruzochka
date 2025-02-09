using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace лаба99
{
    internal class CarParking
    {
        private int numSlots; //Количество парковочных мест
        private int numCars; // Количество машин на парковке
        private static int count = 0; //Счетчик объектов
        public static int ObjectCount()
        {
            return count;
        }

        public int NumSlots
        {
            get => numSlots;
            set // Сет с проверкой, чтобы количество мест не было отрицательным
            {
                if (value < 0)
                {
                    throw new ValidationException("Количество парковочных мест не может быть отрицательным числом");
                }
                else
                {
                    numSlots = value;
                }
            }
        }
        public int NumCars
        {
            get => numCars;
            set
            {
                if (value < 0)
                {
                    throw new ValidationException("Количество машин на парковке не может быть отрицательным числом");
                }
                else if (value > numSlots)
                {
                    throw new ValidationException("Количество машин на парковке не может быть больше количества мест на парковке");
                }
                else
                {
                    numCars = value;
                }
            }
        }
        public CarParking(int numSlots, int numCars)
        {
            NumSlots = numSlots; //Установка количества мест на парковке
            NumCars = numCars; //Установка количества машин на парковке
            count++; //Увеличение счетчика объектов
        }
        public CarParking(CarParking carParking)
        {
            NumSlots = carParking.NumSlots;
            NumCars = carParking.NumCars;
        }
        public CarParking() //без параметров, инициализирует количество мест и машин на парковке равными 0
        {
            numSlots = 0; //Установка нулевого количества мест на парковке
            numCars = 0; //Установка нулевого количества машин на парковке
            count++; //Увеличение счетчика объектов
        }
        public double CalculateLoad() // Вычисление загруженности парковки в процентах
        {
            if (numSlots > 0)
            {
                return Math.Round((double)numCars / numSlots * 100, 2);
            }
            return 0; // Если количество мест на парковке равно 0, то загруженность парковки невозможно вычислить
        }

        //Часть 2
        //Новый объект типа CarParking с увеличением на 1
        public static CarParking operator ++(CarParking carParking)
        {
            CarParking result = new CarParking(carParking);
            result.NumCars = result.NumCars + 1;
            return result;
        }
        //Новый объект типа CarParking с уменьшением на 1
        public static CarParking operator --(CarParking carParking)
        {
            CarParking result = new CarParking(carParking);
            result.NumCars = result.NumCars - 1;
            return result;
        }
        //Явное приведение
        public static explicit operator int(CarParking carParking)
        {
            int result = (int)Math.Ceiling(carParking.numSlots * 0.8);
            return Math.Max(0, result - carParking.numCars);
        }
        //Неявное приведение
        public static implicit operator bool(CarParking carParking)
        {
            return carParking.numCars == carParking.numSlots;
        }
        //Бинарные операции
        public static CarParking operator +(CarParking carParking1, CarParking carParking2)
        {
            return new CarParking(carParking1.NumSlots + carParking2.NumSlots, carParking1.NumCars + carParking2.NumCars);
        }
        public static bool operator >(CarParking carParking1, CarParking carParking2)
        {
            return carParking1.CalculateLoad() < carParking2.CalculateLoad() && carParking1.NumSlots > carParking2.NumSlots;
        }
        public static bool operator <(CarParking carParking1, CarParking carParking2)
        {
            return carParking1.CalculateLoad() > carParking2.CalculateLoad() && carParking1.NumSlots < carParking2.NumSlots;
        }
    }
}

