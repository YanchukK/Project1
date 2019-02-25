using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Registration
{
    static class FileService
    {
        // Считываем построчно
        public static bool IsPropertyAlreadyExist(string property, string path)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(property))
                    {
                        Console.WriteLine("{0} уже существует", property);
                        return false;
                    }
                }
                return true;
            }
        }


        public static void SaveUser(User user, string path)
        {
            //DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(User));

            ////string json = JsonConvert.SerializeObject(user);

            //using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            //{ 
            //    jsonFormatter.WriteObject(fs, user);
            //}


            var jsonData = File.ReadAllText(path);
            // De-serialize to object or create new list
            var userList = JsonConvert.DeserializeObject<List<User>>(jsonData)
                                  ?? new List<User>();

            // Add any new employees
            userList.Add(user);

            // Update json data string
            jsonData = JsonConvert.SerializeObject(userList);
            File.WriteAllText(path, jsonData);
        }

    }
}
