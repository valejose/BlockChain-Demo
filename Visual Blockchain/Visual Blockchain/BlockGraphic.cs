// Creation Author: Joseph Valentin
// Create Date: 10/7/2017
// Last Update Author: Joseph Valentin
// Last Updated: 10/8/2017

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Visual_Blockchain {
    /// <summary>
    /// A BlockGraphic contains all the visual elements to represent a Block. All elements will be contained a Grid object
    /// and will all Blocks will have a uniform format.
    /// </summary>
    public class BlockGraphic {

        #region Fields
        private Grid _grid;
        private Label[] _arrLabels;
        private TextBox[] _arrTextboxes;
        private Button _button;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize a BlockGraphic for the passed-in Block contained in the passed-in BlockChain.
        /// </summary>
        /// <param name="block">Block to make BlockGraphic for.</param>
        /// <param name="blockchain">BlockChain the Block is contained in.</param>
        public BlockGraphic(Block block, Blockchain blockchain) {
            _grid = new Grid {
                Height = 300,
                Width = 250,
                Margin = new System.Windows.Thickness(10, 10, 0, 0),
            };

            #region Labels
            // Initialize array and put all labels into it

            _arrLabels = new Label[5];
            _arrLabels[(int)ProgramResources.Fields.Index] = new Label {
                Height = 25,
                Width = 60,
                Margin = new System.Windows.Thickness(10, 16, 0, 0),
                Content = "Block:",
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Right
            };
            _arrLabels[(int)ProgramResources.Fields.Nonce] = new Label {
                Height = 25,
                Width = 60,
                Margin = new System.Windows.Thickness(10, 49, 0, 0),
                Content = "Nonce:",
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Right
            };
            _arrLabels[(int)ProgramResources.Fields.Data] = new Label {
                Height = 25,
                Width = 60,
                Margin = new System.Windows.Thickness(10, 80, 0, 0),
                Content = "Data:",
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Right
            };
            _arrLabels[(int)ProgramResources.Fields.Previous] = new Label {
                Height = 25,
                Width = 60,
                Margin = new System.Windows.Thickness(10, 185, 0, 0),
                Content = "Previous:",
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Right
            };
            _arrLabels[(int)ProgramResources.Fields.Hash] = new Label {
                Height = 25,
                Width = 60,
                Margin = new System.Windows.Thickness(10, 185, 0, 0),
                Content = "Hash:",
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Right
            };
            #endregion

            #region Textboxes
            // Initialize array and put all Textboxes into it

            _arrTextboxes = new TextBox[5];
            _arrTextboxes[(int)ProgramResources.Fields.Index] = new TextBox {
                Height = 25,
                Width = 150,
                Margin = new System.Windows.Thickness(75, 16, 0, 0),
                Text = "#",
                Background = ProgramResources.whiteBrush,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                IsEnabled = false
            };
            _arrTextboxes[(int)ProgramResources.Fields.Nonce] = new TextBox {
                Height = 25,
                Width = 150,
                Margin = new System.Windows.Thickness(75, 49, 0, 0),
                Text = "0",
                Background = ProgramResources.whiteBrush,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                IsEnabled = false
            };
            _arrTextboxes[(int)ProgramResources.Fields.Data] = new TextBox {
                Name = "txt" + block.Index.ToString(),
                Height = 100,
                Width = 150,
                Margin = new System.Windows.Thickness(75, 80, 0, 0),
                Text = "",
                TextWrapping = TextWrapping.WrapWithOverflow,
                Background = ProgramResources.whiteBrush,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                IsEnabled = true
            };
            _arrTextboxes[(int)ProgramResources.Fields.Previous] = new TextBox {
                Height = 25,
                Width = 150,
                Margin = new System.Windows.Thickness(75, 185, 0, 0),
                Text = "",
                Background = ProgramResources.whiteBrush,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                IsEnabled = false
            };
            _arrTextboxes[(int)ProgramResources.Fields.Hash] = new TextBox {
                Height = 25,
                Width = 150,
                Margin = new System.Windows.Thickness(75, 215, 0, 0),
                Text = "",
                Background = ProgramResources.whiteBrush,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                IsEnabled = false
            };

            // TextChanged Event for Data Textbox
            _arrTextboxes[(int)ProgramResources.Fields.Data].AddHandler(TextBox.TextChangedEvent, new RoutedEventHandler(blockchain.UpdateHash));
            #endregion

            #region Buttons
            _button = new Button {
                Name = "btn" + block.Index.ToString(), 
                Height = 25,
                Width = 75,
                Margin = new System.Windows.Thickness(75, 256, 0, 0),
                Content = "Mine",
                Background = ProgramResources.blueBrush,
                Foreground = ProgramResources.whiteBrush,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Top
            };

            // Click Event for Mine Button
            _button.AddHandler(Button.ClickEvent, new RoutedEventHandler(blockchain.MineBlock));
            #endregion

            // Add all elements to the Grid
            for(int i = 0; i < _arrLabels.Length; i++) {
                _grid.Children.Add(_arrLabels[i]);
                _grid.Children.Add(_arrTextboxes[i]);
            }
            _grid.Children.Add(_button);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Change the background color to the color of the SolidColorBrush passed in.
        /// </summary>
        /// <param name="color">SolidColorBrush with the color to change the Grid background to.</param>
        public void ChangeGridColor(SolidColorBrush color) {
            _grid.Background = color;
        }

        /// <summary>
        /// Update the text properties of the Textboxes in the BlockGraphic Grid to current values.
        /// </summary>
        /// <param name="block">Block that contains the data to show in the Textboxes.</param>
        public void UpdateTextBlocks(Block block) {
            _arrTextboxes[(int)ProgramResources.Fields.Index].Text = block.Index.ToString();
            _arrTextboxes[(int)ProgramResources.Fields.Nonce].Text = block.Nonce.ToString();
            _arrTextboxes[(int)ProgramResources.Fields.Data].Text = block.Data;
            _arrTextboxes[(int)ProgramResources.Fields.Previous].Text = block.Previous;
            _arrTextboxes[(int)ProgramResources.Fields.Hash].Text = block.Hash;
        }
        #endregion

        #region Properties
        public Grid BlockGrid {
            get {
                return _grid;
            }
        }

        /// <summary>
        /// Get the text in the Data Textbox
        /// </summary>
        public string DataText {
            get {
                return _arrTextboxes[(int)ProgramResources.Fields.Data].Text;
            }
        }
        #endregion     

    }
}
