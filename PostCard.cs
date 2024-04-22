using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
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
        /// <param name="name">New value for name of post cards</param> 
        /// <param name="country">New value for country of post cards</param> 
        /// <param name="year">New value for year of post cards</param> 
        /// <param name="height">New value for height of post cards</param> 
        /// <param name="width">New value for width of post cards</param> 
        /// <param name="type">New value for type of post cards/param> 
        /// <param name="quantity">New value for quantity of post cards</param> 
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
        public override string ToString()
        {
            string mLine;
            mLine = string.Format("|{0, 10} | {1, 10} | {2, 10} | {3, 10} | {4, 10} | {5, 10} | {6, 10} |",
                                    edName, edCountry, year, edType, height, width, Quantity);
            return mLine;
        }

        /// <summary> 
        /// Equality check method
        /// </summary> 
        /// <param name="myObject">Object of post cards to be matched with </param>  
        public override bool Equals(object myObject)
        {
            PostCard postCard = myObject as PostCard;
            return postCard.edName == edName &&
                   postCard.edCountry == edCountry &&
                   postCard.year == year &&
                   postCard.edType == edType &&
                   postCard.height == height &&
                   postCard.width == width &&
                   postCard.Quantity == Quantity;
        }

        /// <summary> 
        /// Reccommended method to override: GetHashCode 
        /// </summary> 
        /// <returns>Hash code (BITWISE XOR) </returns> 
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
        /// Overloaded operator >= (by year and name) 
        /// </summary> 
        /// <param name="first">First post card</param> 
        /// <param name="second">second post card</param> 
        /// <returns>True if year of first ir greater than 
        /// year of second or if battery lifes are equal, compares 
        /// by name in reverse alphabetic order</returns> 
        public static bool operator >=(PostCard first, PostCard second)
        {
            int poz = String.Compare(first.edName, second.edName,
                                     StringComparison.CurrentCulture);
            return first.year > second.year ||
                   first.year == second.year && poz > 0;
        }

        /// <param name="first">First post card</param> 
        /// <param name="second">second post card</param> 
        /// <returns>True if year of first ir greater than 
        /// year of second or if battery lifes are equal, compares 
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
        /// <param name="first">First post card</param> 
        /// <param name="second">Second post card</param> 
        /// <returns>True if name of first is equal to name of second</returns> 
        public static bool operator ==(PostCard first, PostCard second)
        {
            return first.edName == second.edName;
        }

        /// <summary> 
        /// Overloaded operator != (by model) 
        /// </summary> 
        /// <param name="first">First post card</param> 
        /// <param name="second">Second post card</param> 
        /// <returns>True if type of first is not equal to type of second</returns> 
        public static bool operator !=(PostCard first, PostCard second)
        {
            return first.edType != second.edType;
        }

        /// <summary> 
        /// Overloaded operator >  (by battery life) 
        /// </summary> 
        /// <param name="first">First post card</param> 
        /// <param name="second">Second post card</param> 
        /// <returns>True if year of first is greater than year of second</returns> 
        public static bool operator >(PostCard first, PostCard second)
        {
            return first.year > second.year;
        }

        /// <summary> 
        /// Overloaded operator < (by battery life) 
        /// </summary> 
        /// <param name="first">First post card</param> 
        /// <param name="second">Second post card</param> 
        /// <returns>True if year of first is greater than year of second</returns>  
        public static bool operator <(PostCard first, PostCard second)
        {
            return first.year < second.year;
        }
    }
}
