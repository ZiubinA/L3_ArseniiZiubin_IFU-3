using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_ArseniiZiubin_IFU_3
{
    internal class TaskUtils
    {
        /// <summary> 
        /// Task1: Finds all post cards which country is same as entered from keyboard 
        /// </summary> 
        /// <param name="Data">Associative container (dictionary) of post cards</param> 
        /// <param name="country">name of the country</param> 
        /// <returns>Dictionary (owner, MyLinkedList) of post cards </returns> 
        public static Dictionary<string, string> FindCollectorForSpecCountry (Dictionary<string, MyLinkedList> Data, string country)
        {
            if(country != null)
            {
                Dictionary<string, string> AllLongest = new Dictionary<string, string>();

                foreach (KeyValuePair<string, MyLinkedList> pair in Data)
                {
                    string owner = pair.Key;
                    PostCard SpecQuant = pair.Value.CountColPost();
                    // Copy electronic devices with longest battery life 
                    for (pair.Value.Start(); pair.Value.Exists(); pair.Value.Next())
                    {
                        PostCard ed = pair.Value.GetData();
                        // Find all devices with maximum battery life 
                        if (ed.edCountry == country && SpecQuant.Quantity == ed.Quantity)
                        {
                            AllLongest.Add(owner, null);

                        }
                    }
                }
                return AllLongest;
            }
            else { return null; }
        }

        /// Task 2 : Finds postcards from all collectors with more than 1 copy        
        /// </summary>
        /// <param name="Data">Source data of post card lists.</param>
        /// <returns>Linked list containing with more than one copy.</returns>
        public static MyLinkedList MoreThanOneCopyP(Dictionary<string, MyLinkedList> Data)
        {
            Dictionary<string, MyLinkedList> moreThan1Copy = new Dictionary<string, MyLinkedList>();

            foreach (KeyValuePair<string, MyLinkedList> pair in Data)
            {
                MyLinkedList postCardList = pair.Value;
                MyLinkedList moreThaOneCopy = postCardList.MoreThanOneCopy();
                moreThan1Copy.Add(pair.Key, moreThaOneCopy);

            }
            MyLinkedList C = new MyLinkedList();
            foreach (KeyValuePair<string, MyLinkedList> pair in moreThan1Copy)
            {
                MyLinkedList employeesList = pair.Value;
                C.Join(employeesList);
            }
            return C;
        }

        /// <summary> 
        /// Creates a unique list of post cards (required for Task5) 
        /// </summary> 
        /// <param name="Data">Associative container (dictionary) of post cards</param> 
        /// <returns>List (implemented as singly linked list) of unique countries</returns> 
        public static MyLinkedListOfStrings UniqueTypes(Dictionary<string, MyLinkedList> Data)
        {
            MyLinkedListOfStrings Unique = new MyLinkedListOfStrings();
            foreach (KeyValuePair<string, MyLinkedList> pair in Data)
            {
                string owner = pair.Key;
                MyLinkedList ED = pair.Value;
                for (ED.Start(); ED.Exists(); ED.Next())
                {
                    string mType = string.Format("{0} {1} {2}", ED.GetData().edCountry, ED.GetData().height, ED.GetData().width );
                    
                    if (!Unique.Contains(mType))
                        Unique.AddToEnd(mType);
                }
            }
            return Unique;
        }
    }
}
