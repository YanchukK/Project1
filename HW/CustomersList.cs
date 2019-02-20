using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Дан список потребителей https://bitbucket.org/snippets/NazariyTaran/8enepB#file-CustomersList.cs 

Найти потребителя, который зарегистрировался раньше всех

            // var EarlierRegistration = from earlier in customers
            //                          where earlier.RegistrationDate.Date
            //                          select earlier;



Написать метод, который позволяет фильтровать потребителей
по части имени не учитывая регистр

Написать метод, который выведет на экран, в хронологическом
порядке, потребителей которые зарегистрировались в один месяц,
при этом в одной такой группе они должны быть отсортированы в алфавитном порядке

Написать метод, который отсортирует потребителей по заданному полю
и направлению(ascending, descending) [ремарка - рефлексия в помощь]

Написать метод, который выведет на экран имена всех потребителей в коллекции через запятую
*/



namespace ConsoleApp1
{
    class Program
    {
        // Написать метод, который считает среднее арифметическое всех балансов всех потребителей
        public static double ArithmeticAverageAllBalances(List<Customer> customers)
        {
            double BalanceSum = 0;
            foreach (var customer in customers)
            {
                BalanceSum += customer.Balance;
            }

            return BalanceSum / customers.Count;
        }


        // Написать метод, который позволит фильтровать потребителей
        // по дате регистрации(от X до Y). Если нет результата по фильтру
        // - выводить сообщение "No results"

        public static List<Customer> FiltrRegistrationDate(List<Customer> customers, DateTime X, DateTime Y)
        {
            var FilteredCustomers = (from customer in customers
                                     where customer.RegistrationDate > X && customer.RegistrationDate < Y
                                     select customer).ToList();
            if (FilteredCustomers.Count == 0)
            {
                Console.WriteLine("No results");
                return FilteredCustomers;
            }
            else
                return FilteredCustomers;
        }

        // Написать метод, который позволяет фильтровать потребителей по Id-шникам
        public static List<Customer> FiltrById(List<Customer> customers, int Id)
        {
            var FilteredCustomers = (from customer in customers
                                     where customer.Id > Id
                                     select customer).ToList();
            return FilteredCustomers;
        }

        // Написать метод, который позволяет фильтровать потребителей
        // по части имени не учитывая регистр
        public static List<Customer> FiltrByName(List<Customer> customers, string partOfName)
        {
            var FilteredCustomers = (from customer in customers
                                     where customer.Name.ToLower().Contains(partOfName.ToLower())
                                     select customer).ToList();
            return FilteredCustomers;
        }



        static void Main(string[] args)
        {

            var customers = new List<Customer>
            {
                new Customer(1, "Tawana Shope", new DateTime(2017, 7, 15), 15.8),
                new Customer(2, "Danny Wemple", new DateTime(2016, 2, 3), 88.54),
                new Customer(3, "Margert Journey", new DateTime(2017, 11, 19), 0.5),
                new Customer(4, "Tyler Gonzalez", new DateTime(2017, 5, 14), 184.65),
                new Customer(5, "Melissa Demaio", new DateTime(2016, 9, 24), 241.33),
                new Customer(6, "Cornelius Clemens", new DateTime(2016, 4, 2), 99.4),
                new Customer(7, "Silvia Stefano", new DateTime(2017, 7, 15), 40),
                new Customer(8, "Margrett Yocum", new DateTime(2017, 12, 7), 62.2),
                new Customer(9, "Clifford Schauer", new DateTime(2017, 6, 29), 89.47),
                new Customer(10, "Norris Ringdahl", new DateTime(2017, 1, 30), 13.22),
                new Customer(11, "Delora Brownfield", new DateTime(2011, 10, 11), 0),
                new Customer(12, "Sparkle Vanzile", new DateTime(2017, 7, 15), 12.76),
                new Customer(13, "Lucina Engh", new DateTime(2017, 3, 8), 19.7),
                new Customer(14, "Myrna Suther", new DateTime(2017, 8, 31), 13.9),
                new Customer(15, "Fidel Querry", new DateTime(2016, 5, 17), 77.88),
                new Customer(16, "Adelle Elfrink", new DateTime(2017, 11, 6), 183.16),
                new Customer(17, "Valentine Liverman", new DateTime(2017, 1, 18), 13.6),
                new Customer(18, "Ivory Castile", new DateTime(2016, 4, 21), 36.8),
                new Customer(19, "Florencio Messenger", new DateTime(2017, 10, 2), 36.8),
                new Customer(20, "Anna Ledesma", new DateTime(2017, 12, 29), 0.8)
            };

            // средние арифметическое
            Console.WriteLine("Arithmetic average all balances " + ArithmeticAverageAllBalances(customers));

            var X = new DateTime(2018, 1, 1);
            var Y = new DateTime(2017, 12, 1);
            var ResultCustomers = FiltrRegistrationDate(customers, X, Y);

            foreach (var customer in ResultCustomers)
            {
                Console.WriteLine(customer.Name + " " + customer.RegistrationDate); // проверка дату
            }


            ResultCustomers = FiltrById(customers, 10);
            foreach (var customer in ResultCustomers)
            {
                Console.WriteLine(customer.Id + " " + customer.Name); // проверка ид
            }



            ResultCustomers = FiltrByName(customers, "aWan");
            foreach (var customer in ResultCustomers)
            {
                Console.WriteLine(customer.Id + " " + customer.Name); // проверка имя
            }
            Console.WriteLine();
        }
    }
}
