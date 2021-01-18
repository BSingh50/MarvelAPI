using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelStorage.DataHandler
{
    public interface IDataHandler
    {
        void saveToFile(string fileName, object content);
    }
}
