namespace Poster
{
    class Ticket
    {
        // нужно ли билету состоять из Date, Movie и Session

        public int GetDate { get; set; } // нужно ли в дататайм??

        public string GetMovie { get; set; }

        public string GetSession { get; set; }

        public int Count { get; set; }

        public Ticket(int date, string movie, string session, int count)
        {
            this.GetDate = date;
            this.GetMovie = movie;
            this.GetSession = session;
            this.Count += count;
        }
    }
}
