using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelAPI.Model
{
    public class CharacterDescription
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Thumbnail thumbnail { get; set; }

    }

    public class Thumbnail
    {
        public string path { get; set; }
        public string extension { get; set; }
    }
}
