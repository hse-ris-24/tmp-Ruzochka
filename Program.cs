using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp18;
using лаба99;

internal class Program
{
    static void Main(string[] args)
    {
        UserInterface ui = new UserInterface();

        //Ввод данных о парковке
        Console.WriteLine("Конструктор с параметрами:");
        CarParking parking1 = ui.InputData();
        UserInterface.Show(parking1);
        Console.WriteLine("Конструктор без параметров");
        CarParking parking2 = new CarParking();
        UserInterface.Show(parking2);

        //Вычисление загруженности парковки
        Console.WriteLine($"Загруженность парковки: {parking1.CalculateLoad()}%");

        //Демонстрация унарных операций
        CarParking parking3 = new CarParking(20, 15);
        Console.WriteLine($"Исходное количество автомобилей на парковке: {parking3.NumCars}");
        parking3++;
        Console.WriteLine($"Количество автомобилей на парковке после увеличения на 1: {parking3.NumCars}");
        parking3--;
        Console.WriteLine($"Количество автомобилей на парковке после уменьшения на 1: {parking3.NumCars}");

        //Демонстрация операций приведения типа
        Console.WriteLine($"Для загруженности парковки до 80% не хватает {(int)parking3} автомобилей.");
        if (parking3) Console.WriteLine("На парковке нет свободных мест");
        else Console.WriteLine("На парковке есть свободные места");

        //Демонстрация бинарных операций
        Console.WriteLine("Введите количество мест на первой парковке");
        int numSlots2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество автомобилей на первой парковке");
        int numCars2 = int.Parse(Console.ReadLine());
        CarParking parking4 = new CarParking(numSlots2, numCars2);
        UserInterface.Show(parking4);

        Console.WriteLine("Введите количество мест на второй парковке");
        int numSlots3 = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество автомобилей на второй парковке");
        int numCars3 = int.Parse(Console.ReadLine());
        CarParking parking5 = new CarParking(numSlots3, numCars3);
        UserInterface.Show(parking5);

        Console.WriteLine($"Количество мест на совмещенной парковке {(parking4 + parking5).NumSlots}. Количество автомобилей на совмещенной парковке {(parking4 + parking5).NumCars}");
        //Сравнение парковок
        Console.WriteLine($"Загруженность первой парковки ниже и общее количество мест больше, чем на второй? {parking4 > parking5}");
        Console.WriteLine($"Загруженность первой парковки выше и общее количество мест меньше, чем на второй? {parking4 < parking5}");

        //Создание массива парковок (конструктор без параметров)
        Console.WriteLine("Создание массива парковок(конструктор без параметров");
        CarParkingArray carParkingArray2 = new CarParkingArray();
        Console.WriteLine("Парковки из массива:");
        carParkingArray2.Show();

        //Создание массива парковок (конструктор с параметрами)
        Console.WriteLine("Создание массива парковок(конструктор с параметрами)");
        CarParkingArray carParkingArray = new CarParkingArray(5); // Создание массива с 5 случайными парковками
        Console.WriteLine("Парковки из массива:");
        carParkingArray.Show();

        //Поиск менее загруженной парковки
        LeastLoadedParking(carParkingArray);

        // Создание новой коллекции на основе существующей (глубокое копирование)
        CarParkingArray arrayCopy = new CarParkingArray(carParkingArray);
        Console.WriteLine("Копия массива парковок:");
        arrayCopy.Show();
        // Демонстрация работы индексатора
        try
        {
            Console.WriteLine("Парковка на индексе 0:");
            UserInterface.Show(carParkingArray[0]);
            Console.WriteLine("Запись и получение массива с существующим индексом:");
            arrayCopy[0] = new CarParking(40, 8);
            Console.WriteLine("Измененная первая парковка:");
            UserInterface.Show(arrayCopy[0]);
            //Проверка получения объекта с несуществующим индексом
            Console.WriteLine("Получение объекта с несуществующим индексом:");
            var carParking = arrayCopy[10]; // это вызовет исключение
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        try
        {
            Console.WriteLine("Запись объекта с несуществующим индексом:");
            arrayCopy[10] = new CarParking(30, 7); // это вызовет исключение
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        // Подсчет количества созданных объектов и коллекций
        Console.WriteLine($"Количество созданных объектов CarParking: {CarParking.ObjectCount()}");
        Console.WriteLine($"Количество созданных коллекций CarParkingArray: 2"); // Мы создали 2 коллекции

        static void LeastLoadedParking(CarParkingArray array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив парковок пуст.");
                return;
            }
            CarParking minLoadedParking = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CalculateLoad() < minLoadedParking.CalculateLoad())
                {
                    minLoadedParking = array[i];
                }
            }
            int freeSpaces = minLoadedParking.NumSlots - minLoadedParking.NumCars;
            Console.WriteLine($"Менее загруженная парковка: {minLoadedParking.NumSlots} мест, {minLoadedParking.NumCars} машин.");
            Console.WriteLine($"Оставшиеся свободные места: {freeSpaces}");
        }
    }
}
