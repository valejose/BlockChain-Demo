// Creation Author: Joseph Valentin
// Create Date: 10/7/2017
// Last Update Author: Joseph Valentin
// Last Updated: 10/8/2017

using System.Windows;

namespace Visual_Blockchain {
    public partial class MainWindow : Window {

        #region Fields
        Blockchain TheChain;
        #endregion

        #region Constructor
        public MainWindow() {
            InitializeComponent();
            // Initialize Blockchain and draw the Genesis Block on the screen
            TheChain = new Blockchain();
            DrawBlocks();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Clear any visual blocks in the stackpanel and add every block in TheChain to it
        /// </summary>
        public void DrawBlocks() {
            stkBlocks.Children.Clear();
            for (int i = 0; i < TheChain.Blocks.Count; i++) {
                stkBlocks.Children.Add(TheChain.Graphics[i].BlockGrid);
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Click Event for the Add Block menu item. Adds a single new block to the chain.
        /// </summary>
        private void AddBlock_Click(object sender, RoutedEventArgs e) {
            TheChain.AddBlock();
            DrawBlocks();
        }

        /// <summary>
        /// Click Event for the Add Five Blocks menu item. Adds five new block to the chain.
        /// </summary>
        private void AddFiveBlocks_Click(object sender, RoutedEventArgs e) {
            for(int i = 0; i < 5; i++) {
                TheChain.AddBlock();
            }
            DrawBlocks();
        }
        #endregion

    }
}
