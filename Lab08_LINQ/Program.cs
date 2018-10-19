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
            //IEnumerable<FeatureCollections> manhattan = JsonConvert.DeserializeObject<IEnumerable<FeatureCollections>>(text);


            var properties = manhattan.Features.Select(x => x).Select(x => x.Properties).Select(x => x.Neighborhood);

            foreach (var item in properties)
            {
                Console.WriteLine(item);
            }
        }
    }
}



//Read in the file and answer the questions below
//Use LINQ queries and Lambda statements(when appropriate) to find the answers.
//Use a combination of both to answer the questions.
//Each question and answer should be outputted to the console.

//Output all of the neighborhoods in this data list
//Filter out all the neighborhoods that do not have any names
//Remove the Duplicates
//Rewrite the queries from above, and consolidate all into one single query.
//Rewrite at least one of these questions only using the opposing method(example: Use LINQ instead of a Lambda and vice versa.)