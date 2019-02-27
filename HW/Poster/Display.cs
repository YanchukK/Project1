using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Poster
{
    class Display
    {
        private string path;

        public Display(string path)
        {
            this.path = path;
        }

        
        // Блок вывода на экран

        static void DisplayMovie(List<Movie> list)
        {
            foreach (var d in list)
            {
                if (d.Name.Length > 6)
                {
                    Console.Write("\t" + d.Name + "\t");
                    DisplaySession(d.Sessions.Session);
                }
                else
                {
                    Console.Write("\t" + d.Name + "\t\t");
                    DisplaySession(d.Sessions.Session);
                }

                Console.WriteLine();
            }
        }

        static void DisplaySession(List<Session> list)
        {
            foreach (var d in list)
            {
                Console.Write(d.Time + " ");
            }
        }

        public void PosterDisplay()
        {
            var DatesList = GetDates();

            Console.Clear();

            foreach (var d in DatesList)
            {
                var m = DateTime.Parse(d.Value);

                string format = "d MMM";
                string form = "(ddd)";
                Console.WriteLine(m.ToString(format).ToLower() + " "
                    + m.ToString(form).ToUpper());
                Console.WriteLine();
                DisplayMovie(d.Movies.Movie);
            }
        }

        public List<Date> GetDates()
        {
            Dates dates = null;

            XmlSerializer serializer = new XmlSerializer(typeof(Dates));

            StreamReader reader = new StreamReader(path);
            dates = (Dates)serializer.Deserialize(reader);
            reader.Close();

            return dates.Date;
        }





        // Блок обновления при изменении

        public void UpdateScreen()
        {
            // instantiate the object
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
            var watcher = fileSystemWatcher;

            watcher.Filter = path;

            // Associate event handlers with the events
            watcher.Changed += OnChanged;

            // tell the watcher where to look
            watcher.Path = @"C:\Users\Dasha\source\repos\Poster\Poster\bin\Debug";

            // You must add this line - this allows events to fire.
            watcher.EnableRaisingEvents = true;

            PosterDisplay();
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            // Обновляется экран
                       
            Console.WriteLine($"A new file has been changed - {e.Name}");
        }
    }
}
