using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                ResultBox.Items.Add(new string('-', 65));
                string tableHeader = string.Format
                ("|{0, -20} | {1, -20} | {2, 15} | {3, -20} | {4, 15} | {5, 15} | {6, -20} |",
                "Name", "Country", "Year", "Type", "Height", "Width", "Quantity");
                ResultBox.Items.Add(tableHeader);
                ResultBox.Items.Add(new string('-', 65));
                for (ED.Start(); ED.Exists(); ED.Next())
                {
                    PostCard ed = ED.GetData();
                    ResultBox.Items.Add(ed.ToString());
                }
                ResultBox.Items.Add(new string('-', 65));
                string numElements = string.Format("Number of post cards: {0}",
                                                    ED.Count);
                ResultBox.Items.Add(numElements);
            }
            ResultBox.Items.Add("\n");
        }
    }
}
