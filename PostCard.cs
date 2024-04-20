using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_ArseniiZiubin_IFU_3
{
    public class PostCard
    {
        // Auto-properties 
        public string edName { get; set; }   // Name of post card 
        public string edCountry { get; set; }   // Country of Post Card
        public int year { get; set; }   // Year of issue 
        public string edType { get; set; }   // Type of post card 
        public int height { get; set; }   // Height of post card 
        public int width { get; set; }   // Width of post card 
        public int Quantity { get; set; }   // Quantity of post card 

        /// <summary> 
        ///  Default constructor (no parameters) 
        /// </summary> 
        public PostCard() { }

        /// <summary> 
        /// Constructor (with default values) 
        /// </summary> 
        /// <param name="model">New value for model of electronic device</param> 
        /// <param name="type">New value for type of electronic device</param> 
        /// <param name="batteryLife">New value for battery life of electronic device</param> 
        public PostCard(string name = "", string country = "", int year = 0, string type = "", int height = 0, int width = 0, int quantity = 0)
        {
            edName = name;
            edCountry = country;
            this.year = year;
            edType = type;
            this.height = height;
            this.width = width;
            this.Quantity = quantity;
        }

        /// <summary> 
        /// Method for creating a string output from class properties (data fields) 
        /// </summary> 
        /// <returns>Model, Type and battery life concatenated to single string</returns> 
        public override string ToString()
        {
            string mLine;
            mLine = string.Format("|{0, -20} | {1, -20} | {2, 15} | {3, -20} | {4, 15} | {5, 15} | {6, -20} |",
                                    edName, edCountry, year, edType, height, width, Quantity);
            return mLine;
        }

        /// <summary> 
        /// Equality check method for two electronic devices 
        /// </summary> 
        /// <param name="myObject">Object of electronic device to be matched with </param> 
        /// <returns>True if type, model and battery life of one electric device 
        /// match type, model, battery life of other electric device</returns> 
        public override bool Equals(object myObject)
        {
            PostCard postCard = myObject as PostCard;
            return postCard.edName == edName &&
                   postCard.edCountry == edCountry &&
                   postCard.year == year &&
                   postCard.edType == edType &&
                   postCard.height == height &&
                   postCard.Quantity == Quantity;
        }

        /// <summary> 
        /// Reccommended method to override: GetHashCode 
        /// </summary> 
        /// <returns>Hash code for model and battery life (BITWISE XOR) </returns> 
        public override int GetHashCode()
        {
            return edName.GetHashCode() ^
                   edCountry.GetHashCode() ^
                   year.GetHashCode() ^
                   edType.GetHashCode() ^
                   height.GetHashCode() ^
                   width.GetHashCode() ^
                   Quantity.GetHashCode();
        }

        /// <summary> 
        /// Overloaded operator >= (by battery life and model) 
        /// </summary> 
        /// <param name="first">First electronic device</param> 
        /// <param name="second">Second electronic device</param> 
        /// <returns>True if battery life of first ir greater than 
        /// battery life of second or if battery lifes are equal, compares 
        /// by model name in reverse alphabetic order</returns> 
        public static bool operator >=(PostCard first, PostCard second)
        {
            int poz = String.Compare(first.edName, second.edName,
                                     StringComparison.CurrentCulture);
            return first.year > second.year ||
                   first.year == second.year && poz > 0;
        }
        /// <summary> 
        /// Overloaded operator <= (by battery life and model) 
        /// </summary> 
        /// <param name="first">First electronic device</param> 
        /// <param name="second">Second electronic device</param> 
        /// <returns>True if battery life of first ir less than 
        /// battery life of second or if battery lifes are equal, compares 
        /// by model name alphabetic order</returns> 
        public static bool operator <=(PostCard first, PostCard second)
        {
            int poz = String.Compare(first.edName, second.edName,
                                     StringComparison.CurrentCulture);
            return first.year < second.year ||
                   first.year == second.year && poz < 0;
        }

        /// <summary> 
        ///  Overloaded operator == (by model) 
        /// </summary> 
        /// <param name="first">First electronic device</param> 
        /// <param name="second">Second electronic device</param> 
        /// <returns>True if type of first is  equal to type of second</returns> 
        public static bool operator ==(PostCard first, PostCard second)
        {
            return first.edType == second.edType;
        }

        /// <summary> 
        /// Overloaded operator != (by model) 
        /// </summary> 
        /// <param name="first">First electronic device</param> 
        /// <param name="second">Second electronic device</param> 
        /// <returns>True if type of first is not equal to type of second</returns> 
        public static bool operator !=(PostCard first, PostCard second)
        {
            return first.edType != second.edType;
        }

        /// <summary> 
        /// Overloaded operator >  (by battery life) 
        /// </summary> 
        /// <param name="first">First electronic device</param> 
        /// <param name="second">Second electronic device</param> 
        /// <returns>True if battery life of first is greater than battery life of second</returns> 
        public static bool operator >(PostCard first, PostCard second)
        {
            return first.year > second.year;
        }

        /// <summary> 
        /// Overloaded operator < (by battery life) 
        /// </summary> 
        /// <param name="first">First electronic device</param> 
        /// <param name="second">Second electronic device</param> 
        /// <returns>rue if battery life of first is less than battery life of second</returns> 
        public static bool operator <(PostCard first, PostCard second)
        {
            return first.year < second.year;
        }
    }
}
