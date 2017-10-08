// Creation Author: Joseph Valentin
// Create Date: 10/7/2017
// Last Update Author: Joseph Valentin
// Last Updated: 10/8/2017

namespace Visual_Blockchain {
    /// <summary>
    /// A Block contains all the data to be part of a BlockChain including a Hash representation of all the data. Its position in the BlockChain is its Index.
    /// </summary>
    public class Block {

        #region Fields
        private int _index;
        private int _nonce = 0;
        private string _data;
        private string _previous;
        private string _hash;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize a Block by Index only. The UpdateChain method in BlockChain will handle setting the rest of the fields.
        /// </summary>
        /// <param name="index">Position in the BlockChain.</param>
        public Block(int index) {
            _index = index;
        }

        /// <summary>
        /// Initialize a Block by Index and Data only. The UpdateChain method in BlockChain will handle setting the rest of the fields.
        /// </summary>
        /// <param name="index">Position in the BlockChain.</param>
        /// <param name="data">Data to be contained in the Block.</param>
        public Block(int index, string data) {
            _index = index;
            _data = data;
        }

        /// <summary>
        /// Initializes the Genesis Block. 
        /// </summary>
        /// <param name="index">First position in the BlockChain.</param>
        /// <param name="data">Hardcoded string saying 'Genesis Block'.</param>
        /// <param name="previous">Hardcoded string of 64 0's.</param>
        public Block(int index, string data, string previous) {
            _index = index;
            _data = data;
            _previous = previous;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Performs the mining process by finding a nonce to make the Blocks Hash start with four 0's.
        /// </summary>
        public void MineBlock() {
            _nonce = 0;
            string tempHash = ProgramResources.HashString(AllData);
            bool foundValidHash = CheckHash(tempHash);

            // Loop until a Hash starting with four 0's is found incrementing the Nonce every iteration.
            while (!foundValidHash) {
                _nonce++;
                tempHash = ProgramResources.HashString(AllData);
                foundValidHash = CheckHash(tempHash);  
            }

            Hash = tempHash;
        }

        /// <summary>
        /// Checks if a Hash is valid by seeing if the first four characters are 0's.
        /// </summary>
        /// <param name="hash">Hash to check for validity.</param>
        /// <returns>Returns True if valid Hash.</returns>
        public bool CheckHash(string hash) {
            bool hasValidSignature = true;

            for (int ndx = 0; ndx < 4; ndx++) {
                if (hash[ndx] != '0') {
                    hasValidSignature = false;
                }
            }
            return hasValidSignature;
        }
        #endregion

        #region Properties
        public int Index {
            get {
                return _index;
            }
        }

        public int Nonce {
            get {
                return _nonce;
            }
        }

        public string Data {
            get {
                return _data;
            }
            set {
                _data = value;
            }
        }

        public string Previous {
            get {
                return _previous;
            }
            set {
                _previous = value;
            }
        }

        public string Hash {
            get {
                return _hash;
            }
            set {
                _hash = value;
            }
        }

        /// <summary>
        /// Creates a string of all fields to make a Hash from.
        /// </summary>
        public string AllData {
            get {
                return _index.ToString() + _nonce.ToString() + _data + _previous;
            }
        }

        /// <summary>
        /// Checks the Hash and Previous field for validity. Returns True when both are valid. 
        /// </summary>
        public bool IsValidBlock {
            get {
                if (CheckHash(Hash) && CheckHash(Previous)) {
                    return true;
                } else {
                    return false;
                }
            }
        }
        #endregion

    }
}
