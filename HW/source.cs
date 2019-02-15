using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    abstract class File1
    {
        public string Name { get; set; }
        public string Extension { get; set; } // тип
        public string Size { get; set; }       // размер

        public File1(string name, string extension, string size)
        {
            Name = name;
            Extension = extension;
            Size = size;
        }

        public abstract void Display();
    }

    class Movies : File1
    {
        public string Info { get; set; }

        public Movies(string name, string extension, string size, string info)
    : base(name, extension, size)
        {
            Info = info;
        }

        public override void Display()
        {
            string Resolution = Info.Substring(0, Info.LastIndexOf(';'));
            string Lenght = Info.Substring(Info.LastIndexOf(';') + 1);
            Console.WriteLine($"{Name}\n\tExtension: {Extension}\n\tSize:" +
                $"{Size}\n\tResolution: {Resolution}\n\tLenght: {Lenght}");
        }
    }

    class Images : File1
    {
        public string Resolution { get; set; }

        public Images(string name, string extension, string size, string res)
    : base(name, extension, size)
        {
            Resolution = res;
        }

        public override void Display()
        {
            Console.WriteLine($"{Name}\n\tExtension: {Extension}\n\tSize:" +
                $"{Size}\n\tResolution: {Resolution}");
        }
    }

    class Text : File1
    {
        public string Content { get; set; }

        public Text(string name, string extension, string size, string con)
    : base(name, extension, size)
        {
            Content = con;
        }

        public override void Display()
        {
            Console.WriteLine($"{Name}\n\tExtension: {Extension}\n\tSize:" +
                $"{Size}\n\tContent: {Content}");
        }
    }


    public class SplitString
    {
        private string name;
        private string extension;
        private string size1;
        private string info;
        private string sourceString;

        public SplitString(string s)
        {
            sourceString = s;
        }

        public string Name
        {
            get
            {
                return name = sourceString.Substring(sourceString.IndexOf(':') + 1,
                    sourceString.IndexOf('(') - sourceString.IndexOf(':') - 1);
            }
        }

        public string Extension
        {
            get
            {
                return extension = sourceString.Substring(sourceString.LastIndexOf('.') + 1,
                    sourceString.IndexOf('(') - sourceString.LastIndexOf('.') - 1);
            }
        }

        public string Size
        {
            get
            {
                return size1 = sourceString.Substring(sourceString.IndexOf('(') + 1,
                    sourceString.IndexOf(')') - sourceString.IndexOf('(') - 1);
            }
        }

        public string Info
        {
            get
            {
                return info = sourceString.Substring(sourceString.IndexOf(';') + 1);
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\DS\Downloads\file.txt";
            FileInfo fileInf = new FileInfo(path);
            string[] allText = null;
            if (fileInf.Exists)
            {
                try
                {             // Чтение файла
                              // Чтение всех строк файла в массив строк
                    allText = File.ReadAllLines(path);  
                    foreach (string s in allText)
                    {     // Вывод всех строк на консоль
                        Console.WriteLine(s);
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine();

            List<File1> list = new List<File1>(); // список всех объектов

            var sortedText = from stringText in allText
                             orderby stringText[0] descending
                             select stringText;

            foreach (var o in sortedText)
            {
                Console.WriteLine(o);
            }

            foreach (string s in sortedText)
            {
                var splitString = new SplitString(s);

                if (s[0] == 'T')
                {
                    Text text = new Text(splitString.Name, splitString.Extension,
                        splitString.Size, splitString.Info);
                    list.Add(text);
                }
                else if (s[0] == 'I')
                {
                    Images images = new Images(splitString.Name, splitString.Extension,
                        splitString.Size, splitString.Info);
                    list.Add(images);
                }
                else
                {
                    Movies movies = new Movies(splitString.Name, splitString.Extension,
                        splitString.Size, splitString.Info);
                    list.Add(movies);
                }
            }

            Console.WriteLine();

            foreach (File1 f in list)
            {
                f.Display();
            }
        }
    }
}
