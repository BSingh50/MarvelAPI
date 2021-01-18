using MarvelAPI.Model;
using MarvelAPIService.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarvelAPIService.Marvel
{
    public interface IMarvelDataHandler
    {
        Task<string> GetMarvelApiData(string uri, int offset = 0);
        string ComputeMD5Hash(string apikey);
    }
}
