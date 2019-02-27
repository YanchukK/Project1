using System;

namespace Poster
{
    class Program
    {
        static void Main(string[] args)
        {
            string Path = "persons.xml";

            // Вывести афишу на экран

            Display display = new Display(Path);

            display.UpdateScreen();


            // Манипуляции с билетами

            Booking booking = new Booking(Path);

            while (true)
            {
                Console.WriteLine("Команды:");
                Console.WriteLine("1.Забронировать сеанс");
                Console.WriteLine("2.Список забронированных сеансов");
                Console.WriteLine("3.Отменить бронь");
                Console.Write("\n>");

                int i = int.Parse(Console.ReadLine());
                if (i == 1)
                {
                    booking.BookingTicket();
                }
                else if (i == 2)
                {
                    booking.DisplayAllBook();
                }  
                else if (i == 3)
                {
                    booking.CancelBooking();
                }
            }
        }
    }
}
