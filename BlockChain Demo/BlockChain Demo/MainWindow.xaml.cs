using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;

namespace BlockChain_Demo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        BlockChain TheChain;

        public MainWindow() {
            InitializeComponent();

            Button btnSave = new Button {
                Content = "Save"
            };
            btnSave.AddHandler(Button.ClickEvent, new RoutedEventHandler(SaveBlockChain));
            Grid.SetColumn(btnSave, 0);
            grdSaveLoad.Children.Add(btnSave);

            Button btnLoad = new Button {
                Content = "Load"
            };
            btnLoad.AddHandler(Button.ClickEvent, new RoutedEventHandler(LoadBlockChain));
            Grid.SetColumn(btnLoad, 1);
            grdSaveLoad.Children.Add(btnLoad);
        }

        public void ShowBlocks() {
            string displayMessage = "";
            lstBlocks.Items.Clear();
            for (int i = 0; i < TheChain.BlockCount; i++) {
                displayMessage += "Index: " + TheChain.Blocks[i].Index + "\t\t";
                displayMessage += "TimeStamp: " + TheChain.Blocks[i].TimeStamp + "\t\t";
                displayMessage += "Nonce: " + TheChain.Blocks[i].Nonce + "\r\n";
                displayMessage += "Previous Hash: " + TheChain.Blocks[i].PreviousHash + "\r\n";
                displayMessage += "Hash: " + TheChain.Blocks[i].Hash + "\r\n";
                displayMessage += "Data: " + TheChain.Blocks[i].Data + "\r\n" + "\r\n";
                lstBlocks.Items.Add(displayMessage);
                displayMessage = "";
            }
        }

        private void btnAddBlock_Click(object sender, RoutedEventArgs e) {
            if (txtInputData.Text != null) {
                TheChain.AddBlock(txtInputData.Text);
                txtInputData.Text = "";
                ShowBlocks();
            }
        }

        public void SaveBlockChain(object sender, RoutedEventArgs e) {
            string fileName = "";

            SaveFileDialog sfd = new SaveFileDialog {
                Filter = "blockchain file(*.bch)|*.bch|All files|*.*"
            };

            try {
                sfd.ShowDialog();
                fileName = sfd.FileName;
                FileStream fStream = new FileStream(fileName, FileMode.OpenOrCreate);
                BinaryFormatter br = new BinaryFormatter();
                br.Serialize(fStream, TheChain);
            } catch (ArgumentException aex) {
                MessageBox.Show("Arguement Exception: " + aex.Message);
            } catch (Exception ex) {
                MessageBox.Show("Some other error: " + ex.Message);
            }
        }

        public void LoadBlockChain(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog {
                Filter = "blockchain file(*.bch)|*.bch|All files|*.*"
            };

            try {
                bool? didItWork = ofd.ShowDialog();
                if (didItWork == true) {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fileStream = new FileStream(ofd.FileName, FileMode.Open);

                    TheChain = (BlockChain)bf.Deserialize(fileStream);

                    // Code here to handle putting program to loaded state
                    btnAddBlock.IsEnabled = true;
                    txtInputData.IsEnabled = true;
                    ShowBlocks();
                }
            } catch {
                MessageBox.Show("Error");
            }
        }

        private void btnCreateChain_Click(object sender, RoutedEventArgs e) {
            TheChain = new BlockChain();
            ShowBlocks();
            btnAddBlock.IsEnabled = true;
            txtInputData.IsEnabled = true;     
        }
    }
}
