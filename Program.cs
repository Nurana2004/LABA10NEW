using ClockLibrary;
using Lab9lib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestLab10
{
    internal class Program
    {

        static void Part1()
        {
            Clock[] clockList = arrayInition();
            Console.WriteLine("Вывод виртуальной функцией Show");
            Show(clockList, true);
            Console.WriteLine("Вывод невиртуальной функции");
            Show(clockList, false);
        }
        static void Part2()
        {
            Clock[] clockList = arrayInition();
            Console.WriteLine("Запрос 1: Самый новый бренд часов по году выпуска\n ");
            Console.WriteLine(Query1(clockList).Brand);
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Запрос 2: Количество умных часов с датчиком измерения пульса");
            Console.WriteLine("Количество: " + Query2(clockList));
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Запрос 3: Уникальные стили аналоговых часов ");
            foreach (var str in Query3(clockList))
            {
                Console.WriteLine(str);
            }
        }
        static void Part3()
        {
            Clock[] clockArray = arrayInition();
            Rectangle[] rectangles = arrayRectangles(7);
            int rectSize = rectangles.Length;
            int clockSize = clockArray.Length;
            int size = rectSize + clockSize;
            object[] array = new object[size];
            int i = 0;
            for (; i < rectSize; i++)
            {
                array[i] = rectangles[i];
            }

            for (int j = 0; i < size; i++, j++)
            {
                array[i] = clockArray[j];
            }
            int countRectangles = 0;
            int countClocks = 0;

            Console.WriteLine("\nВывод общего массива Rectangle и Clock");
            foreach (var obj in array)
            {
                if (obj is Clock)
                {
                    (obj as Clock).Show();
                    countClocks++;
                }
                else
                {
                    (obj as Rectangle).Display();
                    countRectangles++;
                }
            }

            Console.WriteLine("Количество часов: " + countClocks.ToString() + "\tКоличество Прямоугольников: " + countRectangles.ToString());

            Console.WriteLine("\n\nРеализация сортировки в массиве из разных часов");
            Clock[] clocks = arrayInition().ToArray();
            Array.Sort(clocks, new ClockComparer());

            Show(clocks, true);

            Console.WriteLine("\n\nБинарный поиск");
            Clock clockForBinarySearch = clocks[5];
            Console.WriteLine("Ищем этот объект бинарным поиском");
            clockForBinarySearch.Show();

            Console.WriteLine("Результат поиска :" + Array.BinarySearch(clocks, clockForBinarySearch, new ClockComparer()));

            Console.WriteLine("\n\nРеализация IClonable");
            // Создание объекта Clock с вложенным объектом IdNumber
            Clock clock1 = new Clock("Бренд1", 2023, new IdNumber(1));
            Console.WriteLine("Исходный объект до манипуляций:");
            clock1.Show();
            // Клонирование объекта Clock
            Clock clock2 = (Clock)clock1.Clone();

            // Поверхностное копирование объекта Clock
            Clock clock3 = clock1.ShallowCopy();

            // Изменение значений полей клонированного объекта
            clock2.Brand = "Бренд2";
            clock2.Year = 2022;
            clock2.Id.Number = 2; // Изменение значения поля вложенного объекта

            // Изменение значений полей поверхностной копии объекта
            clock3.Brand = "Бренд3";
            clock3.Year = 2021;
            clock3.Id.Number = 3; // Изменение значения поля вложенного объекта

            // Вывод значений полей исходного объекта
            Console.WriteLine("\nИсходный объект после изменений:");
            clock1.Show();
            // Вывод значений полей клонированного объекта
            Console.WriteLine("\nКлонированный объект:");
            clock2.Show();
            // Вывод значений полей поверхностной копии объекта
            Console.WriteLine("\nПоверхностная копия объекта:");
            clock3.Show();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("|------------------------------------------------------|");
            Console.WriteLine("|                                                      |");
            Console.WriteLine("|                                                      |");
            Console.WriteLine("|                        Part1                         |");
            Console.WriteLine("|                                                      |");
            Console.WriteLine("|                                                      |");
            Console.WriteLine("|------------------------------------------------------|");
            Part1();
            Console.WriteLine("\n\n\n|------------------------------------------------------|");
            Console.WriteLine("|                                                      |");
            Console.WriteLine("|                                                      |");
            Console.WriteLine("|                        Part2                         |");
            Console.WriteLine("|                                                      |");
            Console.WriteLine("|                                                      |");
            Console.WriteLine("|------------------------------------------------------|");
            Part2();
            Console.WriteLine("\n\n\n|------------------------------------------------------|");
            Console.WriteLine("|                                                      |");
            Console.WriteLine("|                                                      |");
            Console.WriteLine("|                        Part3                         |");
            Console.WriteLine("|                                                      |");
            Console.WriteLine("|                                                      |");
            Console.WriteLine("|------------------------------------------------------|");
            Part3();

        }
        static Clock Query1(Clock[] clockList)
        {
            Clock clockOut = null;
            int year = Int32.MinValue;
            foreach (var clock in clockList)
            {
                if (clock.Year > year)
                {
                    year = clock.Year;
                    clockOut = clock;
                }
            }
            return clockOut;
        }
        static int Query2(Clock[] clockList)
        {
            int count = 0;
            foreach (var clock in clockList)
            {
                if (clock is SmartWatch)
                {
                    if ((clock as SmartWatch).isPulseSensor) count++;
                }
            }
            return count;
        }
        static String[] Query3(Clock[] clockList)
        {
            HashSet<String> result = new HashSet<String>();//Элемент из следующей лабораторной, но он тут напрашивается

            foreach (var clock in clockList)
            {
                if (clock is ClassicWatch)

                { result.Add((clock as ClassicWatch).Style); }
            }

            return result.ToArray<String>();
        }
        static Clock[] arrayInition()
        {
            Clock clockOriginal = new Clock("Бренд1", 2000, new IdNumber(1));
            Clock clockOriginal2 = new Clock("Бренд1", 2001, new IdNumber(2));

            ClassicWatch classicWatch = new ClassicWatch("Бренд2", 2000, "Очень Фешн", new IdNumber(3));
            ClassicWatch classicWatch2 = new ClassicWatch("Бренд3", 2001, "Фешн", new IdNumber(4));

            DigitalWatch digitalWatch = new DigitalWatch("Бренд3", 1999, new IdNumber(5), "Стрелки");
            DigitalWatch digitalWatch2 = new DigitalWatch("Бренд3", 1998, new IdNumber(6), "Led");

            SmartWatch smartWatch = new SmartWatch("Яблоко", 2010, new IdNumber(7), "IOS", true);
            SmartWatch smartWatch2 = new SmartWatch("Самсунг", 2010, new IdNumber(8), "OS", true);



            Clock[] clockArray = new Clock[12];

            clockArray[0] = new Clock("Бренд1", 2000, new IdNumber(1));
            clockArray[1] = new Clock("Бренд1", 2001, new IdNumber(2));
            clockArray[2] = new ClassicWatch("Бренд2", 2000, "Очень Фешн", new IdNumber(3));
            clockArray[3] = new ClassicWatch("Бренд3", 2001, "Фешн", new IdNumber(4));
            clockArray[4] = new DigitalWatch("Бренд3", 1999, new IdNumber(5), "Стрелки");
            clockArray[5] = new DigitalWatch("Бренд3", 1998, new IdNumber(6), "Led");
            clockArray[6] = new SmartWatch("Яблоко", 2010, new IdNumber(7), "IOS", true);
            clockArray[7] = new SmartWatch("Самсунг", 2010, new IdNumber(8), "OS", true);




            Random random = new Random();
            for (int i = 8; i < 12; i++)
            {

                int number = random.Next(4);
                switch (number)
                {
                    case 0:
                        {
                            clockArray[i] = (Clock)new Clock().RandomCreate();
                            break;
                        }
                    case 1:
                        {
                            clockArray[i] = (Clock)new Clock().RandomCreate();
                            break;
                        }

                    case 2:
                        {
                            clockArray[i] = (Clock)new Clock().RandomCreate();
                            break;
                        }
                    case 3:
                        {
                            clockArray[i] = (Clock)new Clock().RandomCreate();// создаётся объект, сразу присваивается и у него же сразу вызывается метод randominit
                            break;
                        }
                }
            }

            return clockArray;
        }
        static Rectangle[] arrayRectangles(int size)
        {
            RectangleArray rectangleArray = new RectangleArray(size);

            Rectangle[] arrayRectangles = new Rectangle[size];
            for (int i = 0; i < size; i++)
            {
                arrayRectangles[i] = rectangleArray[i];
            }
            return arrayRectangles;
        }
        public static void Show(Clock[] clockArray, bool isVirtual)
        {
            Console.WriteLine("-------------Начало-вывода-массива--------------------------------");
            if (isVirtual)
            {
                foreach (var clock in clockArray)
                {
                    clock.Show();// работает так как в каждом наследнике переопределён ToString() и функция virtual
                }
            }
            else
                foreach (var clock in clockArray)
                {
                    clock.ShowTypeNotVirtual();//переопределено в каждом наследнике, но тип массива - базовый класс, соответственно вызывается базовая функция
                }
            Console.WriteLine("--------------Конец-вывода-массива--------------------------------");

        }
    }
}
