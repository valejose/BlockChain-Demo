using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BlockChain_Demo
{
    class Block
    {
        private int _index;
        private DateTime _timestamp;
        private string _data;
        private string _previousHash;
        public Block(int index, DateTime timestamp, string data, string previousHash)
        {
            _index = index;
            _timestamp = timestamp;
            _data = data;
            _previousHash = previousHash;
        }
    }
}
