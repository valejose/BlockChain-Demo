// Creation Author: Joseph Valentin
// Create Date: 10/7/2017
// Last Update Author: Joseph Valentin
// Last Updated: 10/8/2017

using System.Security.Cryptography;
using System.Text;
using System.Windows.Media;

namespace Visual_Blockchain {
    /// <summary>
    /// Static Class to contain the resources for the program including the SolidColorBrushes, Fields enum, and method to Hash a string.
    /// </summary>
    public static class ProgramResources {

        #region Fields
        public static SolidColorBrush redBrush = new SolidColorBrush(Color.FromRgb(236, 158, 146));
        public static SolidColorBrush greenBrush = new SolidColorBrush(Color.FromRgb(195, 240, 181));
        public static SolidColorBrush blueBrush = new SolidColorBrush(Color.FromRgb(18, 38, 232));
        public static SolidColorBrush whiteBrush = new SolidColorBrush(Colors.White);
        #endregion

        #region Enums
        /// <summary>
        /// Enum for the fields of a Block. Can be used to reference the correct locations of lists or arrays that need to use the fields. 
        /// </summary>
        public enum Fields {
            Index = 0,
            Nonce = 1,
            Data = 2,
            Previous = 3,
            Hash = 4
        }
        #endregion

        #region Methods
        /// <summary>
        /// Uses the SHA256 algorithm to Hash a string passed in. 
        /// </summary>
        /// <param name="strToHash">String to get Hash of.</param>
        /// <returns>Hash represenation of string passed in.</returns>
        public static string HashString(string strToHash) {
            SHA256Managed crypt = new SHA256Managed();
            string hash = "";
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(strToHash), 0, Encoding.UTF8.GetByteCount(strToHash));
            foreach (byte theByte in crypto) {
                hash += theByte.ToString("x2");
            }
            return hash.ToString();
        }
        #endregion

    }
}
