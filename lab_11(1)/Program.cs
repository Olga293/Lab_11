using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1. Задайте массив типа string, содержащий 12 месяцев(June, July, May,
//December, January ….). Используя LINQ to Object напишите запрос выбирающий
//последовательность месяцев с длиной строки равной n, запрос возвращающий
//только летние и зимние месяцы, запрос вывода месяцев в алфавитном порядке,
//запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х..
//2. Создайте коллекцию List<T> и параметризируйте ее типом(классом)
//из лабораторной №3 (при необходимости реализуйте нужные интерфейсы).
//3. На основе LINQ сформируйте следующие запросы по вариантам.
//При необходимости добавьте в класс T (тип параметра) свойства.
//4. Придумайте и напишите свой собственный запрос, в котором было
//бы не менее 5 операторов из разных категорий: условия, проекций,
//упорядочивания, группировки, агрегирования, кванторов и разиения.
//5. Придумайте запрос с оператором Join

namespace lab_11_1_
{
    abstract class GeneralInfo
    {
        public string Title { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public string Cover { get; set; }
        public double Price { get; set; }
    }
    class Book : GeneralInfo
    {
        public Book(string title, string country, int year, int pages, string cover, double price)
        {
            Title = title;
            Country = country;
            Year = year;
            Pages = pages;
            Cover = cover;
            Price = price;
        }
        public override string ToString()
        {
            return "~~~~~~~~~~Information about book~~~~~~~~~~\nTitle: " + Title + "\nYear: " + Year + "\nPages: " + Pages + "\nCountry: " + Country + "\nPrice: " + Price;
        }
    }
    public class Matrix
    {
        public int[,] Arr;
        public Matrix(int[,] arr)
        {
            Arr = arr;
        }
        public int GetLength()
        {
            return Arr.Length;
        }
        public int GetRows()
        {
            return Arr.GetLength(0);
        }
        public int GetColumns()
        {
            return Arr.GetLength(1);
        }
        public void Print()
        {
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    Console.Write(Arr[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
        public int CountOfUnits()
        {
            int num = 0;
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    if (Arr[i, j] == 1)
                    {
                        num++;
                    }
                }
            }
            return num;
        }
        public bool EqualNumber(int n)
        {
            int num = 0, kol; ;
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                kol = 0;
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    if (Arr[i, j] == 5)
                    {
                        kol++;
                    }
                }
                if (i == 0)
                {
                    num = kol;
                }
                else
                {
                    if (kol != num || num == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
    class Person
    {
        public string Name { get; set; }
        public string City { get; set; }
    }
    class Place
    {
        public string Capital { get; set; }
        public string Country { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~~~~ Task 1 ~~~~~~~~~~");
            string[] months = { "January", "Febrary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string[] summer_winter_months = { "January", "Febrary", "December", "June", "July", "August" };
            int l = 5;

            IEnumerable<string> len = months.Where(n => n.Length == l);
            Console.WriteLine("\nMonth with length 5: ");
            foreach (string x in len)
            {
                Console.Write(x + ' ');
            }

            IEnumerable<string> sum_win = months.Intersect(summer_winter_months);
            Console.WriteLine("\nOnly summer and winter months: ");
            foreach (string x in sum_win)
            {
                Console.Write(x + ' ');
            }

            IEnumerable<string> order = months.OrderBy(n => n);
            Console.WriteLine("\nMonths in alphabetical order: ");
            foreach (string x in order)
            {
                Console.Write(x + ' ');
            }

            IEnumerable<string> with_u = from p in months
                                       where p.Length >= 4 & p.Contains("u")
                                       select p;
            Console.WriteLine("\nMonths with u and length > 4:");
            foreach (string x in with_u)
            {
                Console.Write(x + ' ');
            }


            Console.WriteLine("\n\n~~~~~~~~~~ Task 2 ~~~~~~~~~~");
            List<Book> books = new List<Book>()
            {
                new Book("Harry Potter and the Prisoner of Azkaban", "United Kingdom", 1999, 464, "hard", 30),
                new Book("Harry Potter and the Half-Blood Prince", "United Kingdom", 2005, 607, "hard", 30),
                new Book("Harry Potter and the Philosopher's Stone", "United Kingdom", 1997, 332, "hard", 30),
                new Book("Harry Potter and the Goblet of Fire", "United Kingdom", 2000, 636, "hard", 30)
            };
            IEnumerable<Book> book = from x in books orderby x.Year select x;
            foreach (Book x in book)
            {
                Console.WriteLine(x + "\n");
            }


            Console.WriteLine("\n\n~~~~~~~~~~ Task 3 ~~~~~~~~~~");
            Matrix m1 = new Matrix(new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
            Matrix m2 = new Matrix(new int[,] { { 1, 1, 1 }, { 2, 2, 2 } });
            Matrix m3 = new Matrix(new int[,] { { 1, 2, 3 }, { 1, 2, 3 } });
            Matrix m4 = new Matrix(new int[,] { { 3, 7, 1 }, { 1, 1, 1 }, { 2, 4, 2 } });
            Matrix m5 = new Matrix(new int[,] { { 3, 7, 2 }, { 1, 1, 0 }, { 2, 4, 2 }, { 7, 4, 9 } });
            List<Matrix> matrix = new List<Matrix> { };
            matrix.Add(m1);
            matrix.Add(m2);
            matrix.Add(m3);
            matrix.Add(m4);
            matrix.Add(m5);

            Console.Write("List of matrices with equal number of 1 in each row:\n");
            var equal_number = from elem in matrix
                               where elem.EqualNumber(1)
                               select elem;
            foreach (var elem in equal_number)
            {
                elem.Print();
                Console.WriteLine("\n");
            }

            Console.Write("\nNumber of matrix 3*3: ");
            var num_size = from elem in matrix
                           where elem.GetRows() == 3 && elem.GetColumns() == 3
                           select elem;
            Console.WriteLine(num_size.Count());

            Console.Write("Ordered by number of elem:\n\n");
            var orderby_elem = matrix.OrderBy(el => el.CountOfUnits());
            foreach (var elem in orderby_elem)
            {
                elem.Print();
                Console.WriteLine("\n");
            }

            var max_countof_elem = orderby_elem.Take(1);
            Console.WriteLine("Matrix with min number of 1: ");
            foreach (var elem in max_countof_elem)
            {
                elem.Print();
                Console.WriteLine();
            }

            max_countof_elem = orderby_elem.Skip(orderby_elem.Count() - 1);
            Console.WriteLine("Matrix with min number of 1: ");
            foreach (var elem in max_countof_elem)
            {
                elem.Print();
            }


            Console.WriteLine("\n\n~~~~~~~~~~ Task 4 ~~~~~~~~~~");
            IEnumerable<string> month_task4 = from p in months
                                              .Where(p => p.Contains("a"))
                                              .OrderBy(p => p)
                                              .Take(10)
                                              .Except(summer_winter_months)
                                              select p;
            foreach (string s in month_task4)
            {
                Console.WriteLine(s);
            }


            Console.WriteLine("\n\n~~~~~~~~~~ Task 5 ~~~~~~~~~~");
            List<Place> teams = new List<Place>()
            {
                new Place { Capital = "Minsk", Country ="Belarus" },
                new Place { Capital = "Tallinn", Country ="Estonia" }
            };
            List<Person> players = new List<Person>()
            {
                new Person {Name="Olga Bryksa", City="Minsk"},
                new Person {Name="Elena Koiro", City="Tallinn"},
                new Person {Name="Artsiom Bryksa", City="Minsk"}
            };
            var result = players.Join(teams,                                          // второй набор
                p => p.City,                                                          //селектор из первого набора
                t => t.Capital,                                                       //селектор из второго набора
                (p, t) => new { Name = p.Name, City = p.City, Country = t.Country }); // результат
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} - {item.City} ({item.Country})");
            }
        }
    }
}
