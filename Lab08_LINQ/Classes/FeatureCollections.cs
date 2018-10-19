using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lab08_LINQ.Classes
{
    public class FeatureCollections
    {
        public string Type { get; set; }
        public List<Feature> Features { get; set; }
    }
}
