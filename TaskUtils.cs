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
        public static Dictionary<string, string> FindCollectorForSpecCountry (Dictionary<string, MyLinkedList> Data, string country)
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

        // Task 2 : create first shift container 
        /// <summary>
        /// Task 2 : Finds all employees in the first shift (before 10 am) across all companies
        /// and combines them into a single linked list.
        /// </summary>
        /// <param name="Data">Source data of companies and employee lists.</param>
        /// <returns>Linked list containing first shift employees.</returns>
        public static MyLinkedList MoreThanOneCopyP(Dictionary<string, MyLinkedList> Data)
        {
            // Creates a dictionary to store first shift employee lists grouped by company
            Dictionary<string, MyLinkedList> moreThan1Copy = new Dictionary<string, MyLinkedList>();

            foreach (KeyValuePair<string, MyLinkedList> pair in Data)
            {
                // Gets the employee list for the current company
                MyLinkedList postCardList = pair.Value;
                MyLinkedList moreThaOneCopy = postCardList.MoreThanOneCopy();
                moreThan1Copy.Add(pair.Key, moreThaOneCopy);

            }
            MyLinkedList C = new MyLinkedList();
            // Joins each first shift list into the target list
            foreach (KeyValuePair<string, MyLinkedList> pair in moreThan1Copy)
            {
                MyLinkedList employeesList = pair.Value;
                C.Join(employeesList);
            }
            return C;
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
