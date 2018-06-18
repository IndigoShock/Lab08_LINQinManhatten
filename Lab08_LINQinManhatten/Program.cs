using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lab08_LINQinManhatten
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LoadJSON();

        }

        public static void LoadJSON()
        {
            string path = "data.json";

            //Properties properties = JsonConvert.DeserializeObject<Properties>(path);

            using (StreamReader r = new StreamReader(path))
            {   //getting json file to show on screen
                dynamic json = r.ReadToEnd();

                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var items in array)
                {
                    Console.WriteLine(items);
                }
            }
        }
    }
}

