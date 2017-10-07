using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BlockChain_Demo {
    [Serializable]
    class Block {
        private int _index;
        private DateTime _timestamp;
        private string _data;
        private string _previousHash;
        private string _hash;
        private int _nonce = 0;

        public Block(int index, DateTime timestamp, string data, string previousHash) {
            _index = index;
            _timestamp = timestamp;
            _data = data;
            _previousHash = previousHash;
            GetValidHash();
        }

        public string HashString() {
            SHA256Managed crypt = new SHA256Managed();
            string hash = "";
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(AllData), 0, Encoding.UTF8.GetByteCount(AllData));
            foreach (byte theByte in crypto) {
                hash += theByte.ToString("x2");
            }
            return hash.ToString();
        }

        public void GetValidHash() {
            string tempHash = HashString();
            bool keepRunning = CheckHash(tempHash);
            _nonce++;
            while (!keepRunning) {
                tempHash = HashString();
                keepRunning = CheckHash(tempHash);
                _nonce++;
            }
            _hash = tempHash;
        }

        public bool CheckHash(string hash) {
            bool hasCorrectStart = true;
            for (int ndx = 0; ndx < 4; ndx++) {
                if (hash[ndx] != 'a') {
                    hasCorrectStart = false;
                }
            }
            return hasCorrectStart;
        }

        public string Data {
            get {
                return _data;
            }
        }

        public int Nonce {
            get {
                return _nonce;
            }
        }

        public string Hash {
            get {
                return _hash;
            }
        }

        public string PreviousHash {
            get {
                return _previousHash;
            }
        }

        public int Index {
           get {
                return _index;
            }
        }

        public string AllData {
            get {
                return _previousHash + _data + _nonce.ToString();
            }
        }
    }
}
