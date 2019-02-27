using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace Poster
{
    class Booking
    {
        private string path;

        public Booking(string path)
        {
            this.path = path;
        }


        // Реализовать возможность бронирования билета на сеанс
        // с выбором фильма и времени

        List<Ticket> tickets = new List<Ticket>();

        // Дата
        private List<Date> GetDates()
        {
            Dates dates = null;

            XmlSerializer serializer = new XmlSerializer(typeof(Dates));

            StreamReader reader = new StreamReader(path);
            dates = (Dates)serializer.Deserialize(reader);
            reader.Close();

            return dates.Date;
        }

        private bool IsDateExist(int date)
        {
            var datesList = GetDates();
            var datesValueList = new List<int>();
            foreach (var d in datesList)
            {
                var day = DateTime.Parse(d.Value);

                datesValueList.Add(day.Day);
            }

            if (datesValueList.Contains(date))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        // Фильм
        private List<Movie> GetMovies(int date)
        {
            var datesList = GetDates();

            var movies = new List<Movie>();

            foreach (var d in datesList)
            {
                var day = DateTime.Parse(d.Value);
                if (day.Day == date)
                {
                    movies = d.Movies.Movie;
                }
            }
            return movies;
        }

        private bool IsMovieExist(int date, string movie)
        {
            var MovieList = GetMovies(date);
            List<string> movies = new List<string>();
            foreach (var m in MovieList)
            {
                movies.Add(m.Name);
            }

            if (movies.Contains(movie))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        // Сеанс
        private List<Session> GetSession(int date, string movie)
        {
            var moviesList = GetMovies(date);

            var sessions = new List<Session>();

            foreach (var d in moviesList)
            {
                if (d.Name == movie)
                {
                    sessions = d.Sessions.Session;
                }
            }
            return sessions;
        }

        private bool IsSessionExist(int date, string movie, string ses)
        {
            var sessionList = GetSession(date, movie);
            int i = 0;
            foreach (var m in sessionList)
            {
                if (m.Time == ses)
                {
                    i++;
                }
            }

            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        private void BookTicket(int date, string movie, string session)
        {
            if (IsTicketAlreadyExist(date, movie, session))
            {
                var ticket = (from t in tickets
                              where t.GetDate == date &&
                              t.GetMovie == movie && t.GetSession == session
                              select t).FirstOrDefault();

                int index = tickets.IndexOf(ticket);
                tickets[index].Count += 1;
            }
            else
            {
                tickets.Add(new Ticket(date, movie, session, 1));
            }
        }


        private bool IsTicketAlreadyExist(int date, string movie, string session)
        {
            foreach (var h in tickets)
            {
                if (h.GetDate == date &&
                    h.GetMovie == movie &&
                    h.GetSession == session)
                {
                    return true;
                }
            }
            return false;
        }


        public void BookingTicket()
        {
            Console.Write("Введите число: ");
            //string strdate = Console.ReadLine();

            int date = int.Parse(Console.ReadLine());

            while (!IsDateExist(date))
            {
                Console.Write("Такой даты нету. Трай эгейн: ");
                int.TryParse(Console.ReadLine(), out date);
            }

            Console.Write("Введите название фильма: ");
            string movie = Console.ReadLine();

            while (!(IsMovieExist(date, movie)))
            {
                Console.Write("В этот день такой фильм не идет. Трай эгейн: ");
                movie = Console.ReadLine();
            }

            if (GetSession(date, movie).Count == 1)
            {
                var sessionlist = GetSession(date, movie);
                string session;
                foreach (var s in sessionlist)
                {
                    session = s.Time;
                    BookTicket(date, movie, session);
                }
                Console.WriteLine("Все ща заброним");
                Console.WriteLine();
            }
            else
            {
                Console.Write("Введите время сеанса: ");
                string session = Console.ReadLine();

                while (!(IsSessionExist(date, movie, session)))
                {
                    Console.Write("Сеанса на такое время нету. Трай эгейн: ");
                    session = Console.ReadLine();
                }

                Console.WriteLine("Все ща заброним");
                Console.WriteLine();
                BookTicket(date, movie, session);
            }
        }


        // Реализовать возможность отображения всех забронированных сеансов.

        public void DisplayAllBook()
        {
            if (tickets.Count == 0)
            {
                Console.WriteLine("Пока никто ничего не забронировал");
                Console.WriteLine();
            }
            else
            {
                DisplayBook();
            }
        }

        private void DisplayBook()
        {
            int i = 1;

            foreach (var t in tickets)
            {
                Console.WriteLine(i);
                Console.WriteLine("\tДень: {0}\n\tФильм: {1}\n\tВремя: {2}" +
                    "\n\tКоличество забронированых билетов: {3}",
                    t.GetDate, t.GetMovie, t.GetSession, t.Count);

                i++;
            }
        }

        // Реализовать возможность отменить бронь
        public void CancelBooking()
        {
            if (tickets.Count == 0)
            {
                Console.WriteLine("Пока никто ничего не забронировал");
                Console.WriteLine();
            }
            else
            {
                DisplayBook();
                Console.Write("Введите номер вашего заказа: ");
                int ordernumber = 0;

                while (!int.TryParse(Console.ReadLine(), out ordernumber))
                {
                    Console.WriteLine("Такого номера не существует");
                    Console.Write("Попробуйсте еще раз: ");
                }

                if (ordernumber > tickets.Count)
                {
                    Console.WriteLine("Такого номера не существует");
                }
                else if (tickets[ordernumber - 1].Count == 1)
                {
                    tickets.RemoveAt(ordernumber - 1);

                    Console.WriteLine("Заказ отменен");
                }
                else
                {
                    tickets[ordernumber - 1].Count -= 1;

                    Console.WriteLine("Заказ отменен");
                }
            }
        }
    }
}
