using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlockChain_Demo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        BlockChain TheChain = new BlockChain();

        public MainWindow() {
            InitializeComponent();
            CreateBlock();
            ShowBlocks();
        }

        public void CreateBlock() {
            TheChain.AddBlock("Second Block in the chain.");
            TheChain.AddBlock("This is the third block in the chain.");
            TheChain.AddBlock("I am block #4.");
        }

        public void ShowBlocks() {
            string displayMessage = "";
            for (int i = 0; i < TheChain.BlockCount; i++) {
                displayMessage += "Index: " + TheChain.Blocks[i].Index + "\r\n";
                displayMessage += "Previous Hash: " + TheChain.Blocks[i].PreviousHash + "\r\n";
                displayMessage += "Hash: " + TheChain.Blocks[i].Hash + "\r\n";
                displayMessage += "Nonce: " + TheChain.Blocks[i].Nonce + "\r\n";
                displayMessage += "Data: " + TheChain.Blocks[i].Data + "\r\n" + "\r\n";
            }
            MessageBox.Show(displayMessage);
        }
    }
}
