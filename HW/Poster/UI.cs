using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poster
{
    static class UI
    {
        public static void DisplayAvailableFeatures(string path)
        {
            Booking booking = new Booking(path);

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
