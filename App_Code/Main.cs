using System.Collections.Generic;
using System.Windows.Forms;

namespace L3_ArseniiZiubin_IFU_3
{
    public partial class Main : Form
    {
        /// <summary> 
        /// Disable (enable) text input, Save menu and menu items for task execution 
        /// </summary> 
        public void ToggleControls(bool enabled = false)
        {
            saveToolStripMenuItem.Enabled = enabled;
            task1ToolStripMenuItem.Enabled = enabled;
            task2ToolStripMenuItem.Enabled = enabled;
            task3ToolStripMenuItem.Enabled = enabled;
            task4ToolStripMenuItem.Enabled = enabled;
            ResultBox.Items.Clear();
            // Sets folder browse path to root of solution configuration (e.g. Debug) 
            folderBrowserDialog1.SelectedPath = Application.StartupPath;
        }

        /// <summary> 
        /// Sets status of program 
        /// </summary> 
        /// <param name="message">Provided message</param>
        public void SetStatus(string message)
        {
            //statusStrip1.Items[0].Text = message;
        }

        /// <summary> 
        /// Writes contents of initial data to ListBox 
        /// </summary> 
        /// <param name="header">Note (label) above table</param> 
        /// <param name="Data">Associative container of initial data</param> 
        public void Display(string header, Dictionary<string, MyLinkedList> Data)
        {
            ResultBox.Items.Add(header);
            // Navigation in associative container of initial data 
            foreach (KeyValuePair<string, MyLinkedList> pair in Data)
            {
                // Extract keys i.e. name of owner as table headers 
                string owner = pair.Key;
                ResultBox.Items.Add(new string('-', 12));
                string headerFormat = string.Format("| {0,-8} |", owner);
                ResultBox.Items.Add(headerFormat);
                ResultBox.Items.Add(new string('-', 12));
                // Extract values (electronic devices) 
                MyLinkedList ED = pair.Value;
                ResultBox.Items.Add(new string('-', 119));
                string tableHeader = string.Format
                ("|{0, 10} | {1, 10} | {2, 10} | {3, 10} | {4, 10} | {5, 10} | {6, 10} |",
                "Name", "Country", "Year", "Type", "Height", "Width", "Quantity");
                ResultBox.Items.Add(tableHeader);
                ResultBox.Items.Add(new string('-', 119));
                for (ED.Start(); ED.Exists(); ED.Next())
                {
                    PostCard ed = ED.GetData();
                    ResultBox.Items.Add(ed.ToString());
                }
                ResultBox.Items.Add(new string('-', 119));
                string numElements = string.Format("Number of post cards: {0}",
                                                    ED.Count);
                ResultBox.Items.Add(numElements);
            }
            ResultBox.Items.Add("\n");
        }

        /// <summary>
        /// Writes container name to ListBox
        /// </summary>
        /// <param name="data">initial data</param>
        public void DisplayContainer(Dictionary<string, string> data)
        {
            foreach (var kvp in data)
            {
                string owner = kvp.Key;
                ResultBox.Items.Add($"Collector name who has more colored post cards for specified country {owner}");
            }
        }

        /// <summary>
        /// Writes contents about post cards to ListBox
        /// </summary>
        /// <param name="header">Note (label) above table</param>
        /// <param name="E">Linked list of post cards</param>
        public void Display(string header, MyLinkedList E)
        {
            ResultBox.Items.Add(header);
            ResultBox.Items.Add(new string('-', 119));
            string tableHeader = string.Format
                   ("|{0, 10} | {1, 10} | {2, 10} | {3, 10} | {4, 10} | {5, 10} | {6, 10} |",
                   "Name", "Country", "Year", "Type", "Height", "Width", "Quantity");
            ResultBox.Items.Add(tableHeader);
            ResultBox.Items.Add(new string('-', 119));
            for (E.Start(); E.Exists(); E.Next())
            {
                PostCard em = E.GetData();
                ResultBox.Items.Add(em.ToString());
            }
            ResultBox.Items.Add(new string('-', 119));
            ResultBox.Items.Add("\n");
        }

        // / Writes contents of strings (types of post cards) to ListBox
        public void Display(MyLinkedListOfStrings S)
        {
            if (S.Count > 0)
            {
                string mLine = "Filter(-s): ";
                for (S.Start(); S.Exists(); S.Next())
                {
                    string s = S.GetData();
                    mLine += s + ",";
                }
                mLine += "\n";
                ResultBox.Items.Add(mLine);
            }
            else
            {
                ResultBox.Items.Add("No filters were selected");
            }
        }
    }
}
