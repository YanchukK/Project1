using System;
using System.Text;

namespace Poster
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string Path = "poster.xml";

            // Вывести афишу на экран

            Display display = new Display(Path);

            display.UpdateScreen();    
            
            // Манипуляции с билетами

            UI.DisplayAvailableFeatures(Path);
        }
    }
}
