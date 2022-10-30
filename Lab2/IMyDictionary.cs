using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal interface IMyDictionary
    {
        bool IsEmpty { get; }
        int Count { get; }
        int Capacity { get; }
        int GetMyHashCode(int key);
        void Add(int key, string value);
        void Remove(int key);
        void Clear();
        string GetValue(int key);
        bool ContainsKey(int key);
        bool ContainsValue(string value);
    }
}
