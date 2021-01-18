using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelStorage.Storage
{
    public interface IFileStorage
    {
        void cacheMarvelAPIData(string fileName, string content);
    }
}
