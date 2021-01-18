using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelAPIService.Model
{
    public class Result<T>
    {
        public List<T> results { get; set; }
    }
}
