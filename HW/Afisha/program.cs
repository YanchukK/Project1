using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Security.Permissions;

namespace Affiche
{
    class Program
    {
        static void Main(string[] args)
        {
        
        // https://jeremylindsayni.wordpress.com/2016/04/10/how-to-use-the-filesystemwatcher-in-c-to-report-file-changes-on-disk/
        
        
            // instantiate the object
            var fileSystemWatcher = new FileSystemWatcher();

            // Associate event handlers with the events
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.Changed += FileSystemWatcher_Changed;
            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;

            // tell the watcher where to look
            fileSystemWatcher.Path = @"C:\Users\Jeremy\Pictures\Screenshots\";

            // You must add this line - this allows events to fire.
            fileSystemWatcher.EnableRaisingEvents = true;

            Console.WriteLine("Listening...");
            WriteLine("(Press any key to exit.)");

            ReadLine();
        }

        private static void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            ForegroundColor = Yellow;
            WriteLine($"A new file has been renamed from {e.OldName} to {e.Name}");
        }

        private static void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            ForegroundColor = Red;
            WriteLine($"A new file has been deleted - {e.Name}");
        }

        private static void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            ForegroundColor = Green;
            WriteLine($"A new file has been changed - {e.Name}");
        }

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            ForegroundColor = Blue;
            WriteLine($"A new file has been created - {e.Name}");
        }
    }
}
