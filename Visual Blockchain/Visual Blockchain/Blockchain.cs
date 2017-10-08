// Creation Author: Joseph Valentin
// Create Date: 10/7/2017
// Last Update Author: Joseph Valentin
// Last Updated: 10/8/2017

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Visual_Blockchain {
    /// <summary>
    /// A Blockchain contains a list of all the Blocks contained in the chain. Every Blockchain will have the same Genesis Block. 
    /// The Blockchain also contains a list of BlockGraphics. This is a parallel list to the Block list that 
    /// contains the visual represenation of all the blocks.
    /// </summary>
    public class Blockchain {

        #region Fields
        private List<Block> _lstBlocks;
        private List<BlockGraphic> _lstGraphics;
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor to initialize the Block and BlockGraphic list with the Genesis Block.
        /// </summary>
        public Blockchain() {
            _lstBlocks = new List<Block>();
            _lstGraphics = new List<BlockGraphic>();

            Block genesis = new Block(0, "Genesis Block", "0000000000000000000000000000000000000000000000000000000000000000");
            _lstBlocks.Add(genesis);

            BlockGraphic graphic = new BlockGraphic(genesis, this);           
            _lstGraphics.Add(graphic);

            UpdateChain();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method to set every Blocks Previous field to the Hash field of the Block before it. If the Block is valid, the background will appear
        /// green. Otherwise it will be red. 
        /// </summary>
        public void UpdateChain() {
            for(int i = 0; i < _lstBlocks.Count; i++) {
                // Set Previous field of Block, ignore genesis Block.
                if (i != 0) {
                    _lstBlocks[i].Previous = _lstBlocks[i - 1].Hash;
                }

                UpdateHash(i);

                // Set background color based on Block validity.
                if (_lstBlocks[i].IsValidBlock) {
                    _lstGraphics[i].ChangeGridColor(ProgramResources.greenBrush);
                } else {
                    _lstGraphics[i].ChangeGridColor(ProgramResources.redBrush);
                }

                // Set all Textbox Text properties to current values.
                _lstGraphics[i].UpdateTextBlocks(_lstBlocks[i]);
            }
        }

        /// <summary>
        /// Adds a new Block to the chain and a corresponding BlockGraphic.
        /// </summary>
        public void AddBlock() {
            Block tempBlock = new Block(Blocks.Count);
            _lstBlocks.Add(tempBlock);
            _lstGraphics.Add(new BlockGraphic(tempBlock, this));
            UpdateChain();
        }

        /// <summary>
        /// Updates the Hash field of a specified Block based on the text of the Data Textbox in the corresponding BlockGraphic.
        /// </summary>
        /// <param name="ndx">Index of the Block to update.</param>
        public void UpdateHash(int ndx) {
            _lstBlocks[ndx].Data = _lstGraphics[ndx].DataText;
            _lstBlocks[ndx].Hash = ProgramResources.HashString(_lstBlocks[ndx].AllData);
        }
        #endregion

        #region Events
        /// <summary>
        /// TextChange Event for the Data Textbox in a BlockGraphic. Updates the BlockChain based on the changes.
        /// </summary>
        public void UpdateHash(object sender, RoutedEventArgs e) {
            UpdateChain();
        }

        /// <summary>
        ///  Click Event that starts the mining process for a Block. 
        /// </summary>
        public void MineBlock(object sender, RoutedEventArgs e) {
            Button btn = (Button)sender;

            // Get the index of which Block to mine by removing 'btn' from the Name of the Button that was clicked. 
            int ndx = int.Parse(btn.Name.Substring(3));
            _lstBlocks[ndx].MineBlock();

            UpdateChain();
        }
        #endregion

        #region Properties
        public List<Block> Blocks {
            get {
                return _lstBlocks;
            }
        }

        public List<BlockGraphic> Graphics {
            get {
                return _lstGraphics;
            }
        }
        #endregion

    }
}
