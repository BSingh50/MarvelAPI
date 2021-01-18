using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MarvelAPIService.Model;
using Newtonsoft.Json;
using System.Linq;
using MarvelAPI.Model;
using MarvelStorage.Storage;
using Microsoft.Extensions.Options;

namespace MarvelAPIService.Marvel
{
    public partial class MarvelDataHandler : IMarvelDataHandler
    {
        private readonly API_KEYS _apikey;
        public MarvelDataHandler(API_KEYS apikey)
        {
            _apikey = apikey;
        }
        public string ComputeMD5Hash(string apikey)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(apikey);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public async Task<string> GetMarvelApiData(string uri, int offset = 0)
        {
            var ts_time = DateTime.Now.Ticks.ToString();
            var hashedKey = ComputeMD5Hash(ts_time + _apikey.MARVEL_PRIVATE_API_KEY + _apikey.MARVEL_PUBLIC_API_KEY).ToLower();

            using (var client = new HttpClient())
            {
                var url = new Uri($"http://gateway.marvel.com/v1/public/{uri}?offset={offset}&limit=100&ts={ts_time}&apikey={_apikey.MARVEL_PUBLIC_API_KEY}&hash={hashedKey}");
                var response = await client.GetAsync(url);

                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }

                return json;
            }
        
        }
        
    }
}
