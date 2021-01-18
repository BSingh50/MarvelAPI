using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MarvelStorage.Storage
{
    public class FileStorage : IFileStorage
    {
        const string filePath = @"C:\";
        public void cacheMarvelAPIData(string fileName, string content)
        {
            File.WriteAllText(filePath + fileName, content);
        }
        
    }
}
