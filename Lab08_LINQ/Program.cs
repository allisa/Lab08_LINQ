using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Lab08_LINQ.Classes;
using Newtonsoft.Json;
using System.Collections;

namespace Lab08_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            JsonConversion();
        }

        public static void JsonConversion()
        {
            string path = "../../../data.json";
            string text = "";

            using (StreamReader sr = File.OpenText(path))
            {
                text = sr.ReadToEnd();
            }

            var manhattan = JsonConvert.DeserializeObject<FeatureCollections>(text);

            //this didn't work which is confusing b/c it was from demo code
            //IEnumerable<FeatureCollections> manhattan = JsonConvert.DeserializeObject<IEnumerable<FeatureCollections>>(text);

            Console.WriteLine("*********1 - All Neighborhhods*********");
            //Pulling all neighborhoods from feature collection
            var properties = manhattan.Features.Select(x => x).Select(x => x.Properties).Select(x => x.Neighborhood);

            foreach (var item in properties)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("*********2 - Filter Out Neighborhoods Without Names*********");

            //Filtering out neighborhoods without names
            var filterNeighborhoodsWONames = (from result in properties
                                              where result.Length > 0
                                              select result);

            foreach (var item in filterNeighborhoodsWONames)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("*********3 - Show Distinc Neighborhoods Names*********");

            //Filtering further to remove duplicate neighborhood names
            var distinctNeighborhoodNames = filterNeighborhoodsWONames.Distinct();

            foreach (var item in distinctNeighborhoodNames)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("*********4 - Done In One Expression*********");

            var filterAllPrevSolutionIntoOne = manhattan.Features.Select(x => x).Select(x => x.Properties).Select(x => x.Neighborhood).Where(x => x != "").Distinct();

            foreach (var item in filterAllPrevSolutionIntoOne)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("*********5 - Rewrite in opposing method*********");
            var filterNoNamesLambda = properties.Where(x => x.Length > 0);

            foreach(var item in filterNoNamesLambda)
            {
                Console.WriteLine(item);
            }
        }
    }
}