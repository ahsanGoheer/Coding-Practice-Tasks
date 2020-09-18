using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresDay1_2
{
    class HashNode<T>
    {
        public HashNode<T> Next { get; set; }
        public T Value { get; set; }
        public string Key { get; set; }
    }
    class HashTable<T>
    {
        private readonly HashNode<T>[] _bucket; //Buckets for the hash table.
        
        public HashTable(int size)
        {
            this._bucket = new HashNode<T>[size];
        }

        public T Get(string key)
        {
            ValidateKey(key); // Check if the key is appropriate.
            var (_, node) = GetNodeByKey(key);
            if(node==null)
            {
                throw new ArgumentOutOfRangeException(nameof(key),$"The key '{key}' is not found!");
            }
            return node.Value;
        }

        public void Add(string key,T value)
        {
            ValidateKey(key);
            var valueNode = new HashNode<T> { Next = null, Value = value,Key=key };
            int position = GetBucketByKey(key);
            HashNode<T> listNode = _bucket[position];
            if(listNode==null)
            {
                _bucket[position] = valueNode;
            }
            else
            {
                while(listNode.Next!=null)
                {
                    listNode = listNode.Next;
                }
                listNode.Next = valueNode;

            }
        }

        public void ValidateKey(string key)
        {
            if(string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
        }

        public (HashNode<T>previous,HashNode<T>foundNode) GetNodeByKey(string key)
        {
            int position = GetBucketByKey(key);
            HashNode<T> fetchedNode = _bucket[position];
            HashNode<T> previous = null;
            while(fetchedNode!=null)
            {
                if (fetchedNode.Key == key) return (previous, fetchedNode);

            }
            return (null, null);
        }

        public bool Remove(string key)
        {
            int position = GetBucketByKey(key);
            (HashNode<T> previous, HashNode<T> current) = GetNodeByKey(key);
            if (current == null) return false;
            if (previous == null)
            {
                _bucket[position] = null;
                return true;
            }
            previous.Next = current.Next;
            return true;

        }

        public bool ContainsKey(string key)
        {
            ValidateKey(key);
            var (_, node) = GetNodeByKey(key);
            if(node!=null)
            {
                return true;
            }
            return false;
        }

        public int GetBucketByKey(string key)
        {
            return key[0] % _bucket.Length;
        }
    }

}
