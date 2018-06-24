using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

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
            string path = @"../../../data.json";

            using (StreamReader r = new StreamReader(path))
            {   //getting json file to show on screen
                string json;

                json = r.ReadToEnd();

                RootObjs manhatten = JsonConvert.DeserializeObject<RootObjs>(json);

                //Query 1
                var neighborhoods = from i in manhatten.Features
                                    select i.Properties.Neighborhood;
                Console.WriteLine("-----------------------------------------------------");

                foreach (var hoods in neighborhoods)
                {
                    Console.WriteLine(hoods);
                }
                Console.ReadKey();
                Console.Clear();

                //Query 2
                var neighborhoodies = from n in manhatten.Features
                                      where n.Properties.Neighborhood != ""
                                      select n.Properties.Neighborhood;
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------");

                foreach (var hoods in neighborhoodies)
                {
                    Console.WriteLine(hoods);
                }
                Console.ReadKey();
                Console.Clear();

                //Query 3
                var ridOfDuplicates = from x in manhatten.Features
                                      group x by x.Properties.Neighborhood into hoodles
                                      where hoodles.Key != ""
                                      orderby hoodles.Key
                                      select hoodles.Key;

                foreach (var hoods in ridOfDuplicates)
                {
                    Console.WriteLine(hoods);
                }
                Console.ReadKey();
                Console.Clear();

                //Query 4
                var allHoodLambda = manhatten.Features
                                .Where(n => n.Properties.Neighborhood != "")
                                .GroupBy(g => g.Properties.Neighborhood)
                                .Select(s => s.Key);

                foreach (var items in allHoodLambda)
                {
                    Console.WriteLine(items);
                };
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------");

                //Query 5
                var allHoodLinq = from i in manhatten.Features
                                  where i.Properties.Neighborhood != ""
                                  group i.Properties.Neighborhood by i.Properties.Neighborhood
                                  into myneighborhood
                                  select myneighborhood.Key;

                foreach (var items in allHoodLinq)
                {
                    Console.WriteLine(items);
                };
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}