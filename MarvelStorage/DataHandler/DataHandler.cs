using MarvelStorage.DataHandler;
using MarvelStorage.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelStorage.StorageHandler
{
    public class DataHandler : IDataHandler
    {
        IFileStorage _fileStorage;
        public DataHandler(IFileStorage fileStorage)
        {
            _fileStorage = fileStorage;
        }
        public void saveToFile(string fileName, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            _fileStorage.cacheMarvelAPIData(fileName, json);
        } 
    }
}
