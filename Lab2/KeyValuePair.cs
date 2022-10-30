using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class KeyValuePair
    {
        private int _key;
        private string _value;

        public KeyValuePair(int key, string value)
        {
            _key = key;
            _value = value;
        }

        public int Key
        {
            get
            { 
                return _key; 
            }
        }

        public string Value
        {
            get
            { 
                return _value; 
            }
        }

    }
}
