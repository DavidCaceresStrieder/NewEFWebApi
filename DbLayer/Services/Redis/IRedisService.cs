using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Services.Redis
{
    public interface IRedisService
    {
        string ReadData(string Key);
        bool SaveData(string key, string value);
    }
}
