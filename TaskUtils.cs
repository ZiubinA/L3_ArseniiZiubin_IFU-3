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
        /// Task1: Finds all electronic devices with longest battery life 
        /// </summary> 
        /// <param name="Data">Associative container (dictionary) of electronic devices</param> 
        /// <returns>Dictionary (owner, MyLinkedList) of electronic devices </returns> 
        public static Dictionary<string, MyLinkedList> FindCollectorForSpecCountry
                     (Dictionary<string, MyLinkedList> Data, string country)
        {
            Dictionary<string, MyLinkedList> AllLongest = new Dictionary<string, MyLinkedList>();

            foreach (KeyValuePair<string, MyLinkedList> pair in Data)
            {
                string owner = pair.Key;
                PostCard SpecQuant = pair.Value.CountColPost();
                MyLinkedList ED = new MyLinkedList();
                // Copy electronic devices with longest battery life 
                for (pair.Value.Start(); pair.Value.Exists(); pair.Value.Next())
                {
                    PostCard ed = pair.Value.GetData();
                    // Find all devices with maximum battery life 
                    if (ed.edCountry == country && SpecQuant.Quantity == ed.Quantity)
                    {
                        ED.AddToEnd(ed);

                    }
                }
                if (!AllLongest.ContainsKey(owner) && ED.Count != 0)
                {
                    AllLongest.Add(owner, ED);
                }
            }
            return AllLongest;
        }

        public static Dictionary<string, MyLinkedList> FindAllPostCards
             (Dictionary<string, MyLinkedList> Data)
        {
            Dictionary<string, MyLinkedList> AllLongest = new Dictionary<string, MyLinkedList>();

            foreach (KeyValuePair<string, MyLinkedList> pair in Data)
            {
                string owner = pair.Key;
                MyLinkedList ED = new MyLinkedList();
                // Copy electronic devices with longest battery life 
                for (pair.Value.Start(); pair.Value.Exists(); pair.Value.Next())
                {
                    PostCard ed = pair.Value.GetData();
                    // Find all devices with maximum battery life 
                    if (ed.Quantity > 1)
                    {
                        if (!ED.Contains(ed))
                            ED.AddToEnd(ed);
                    }
                }
                if (!AllLongest.ContainsKey(owner))
                {
                    AllLongest.Add(owner, ED);
                }
            }
            return AllLongest;
        }

        /// <summary> 
        /// Creates a unique list of electronic devices (required for Task2) 
        /// </summary> 
        /// <param name="Data">Associative container (dictionary) of electronic devices</param> 
        /// <returns>List (implemented as singly linked list) of unique type of models</returns> 
        public static MyLinkedListOfStrings UniqueTypes(Dictionary<string, MyLinkedList> Data)
        {
            MyLinkedListOfStrings Unique = new MyLinkedListOfStrings();
            foreach (KeyValuePair<string, MyLinkedList> pair in Data)
            {
                string owner = pair.Key;
                MyLinkedList ED = pair.Value;
                for (ED.Start(); ED.Exists(); ED.Next())
                {
                    string mType = ED.GetData().edType;
                    // Add only unique names of model  
                    if (!Unique.Contains(mType))
                        Unique.AddToEnd(mType);
                }
            }
            return Unique;
        }
    }
}
