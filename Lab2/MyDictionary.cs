namespace Lab2
{
    internal class MyDictionary : IMyDictionary
    {
        private static int capacity = 100000;
        private KeyValuePair[] hashTable;

        public MyDictionary()
        {
            hashTable = new KeyValuePair[capacity];
        }

        public int GetMyHashCode(int key)
        {
            return key;
        }

        public void Add(int key, string value)
        {
            KeyValuePair pair = new KeyValuePair(key, value);

            int index = GetMyHashCode(key);
            hashTable[index] = pair;
        }
        public void Remove(int key)
        {
            if (ContainsKey(key)) 
                hashTable[GetMyHashCode(key)] = null;
        }

        public string GetValue(int key)
        {
            if (ContainsKey(key))
            {
                int index = GetMyHashCode(key);

                return hashTable[index].Value;
            }

            else return null;
        }

        public bool ContainsKey(int key)
        {
            int index = GetMyHashCode(key);

            for (int i = 0; i < hashTable.Length; i++)
            {
                if (hashTable[i] != null)
                {
                    if (index == hashTable[i].Key) return true;
                }
            }

            return false;
        }

        public bool ContainsValue(string value)
        {
            for (int i = 0; i < hashTable.Length; i++)
            {
                if (hashTable[i] != null)
                {
                    if (hashTable[i].Value.Equals(value)) return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            for (int i = 0; i < hashTable.Length; i++)
            {
                hashTable[i] = null;
            }
        }

        public int Count
        {
            get
            {
                int count = 0;

                for (int i = 0; i < hashTable.Length; i++)
                {
                    if (hashTable[i] != null) count += 1;
                }

                return count;
            }
        }
        
        public bool IsEmpty
        {
            get
            {
                return Count == 0;
            }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
        }
    }
}
