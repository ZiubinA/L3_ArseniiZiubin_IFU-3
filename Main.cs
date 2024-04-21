using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L3_ArseniiZiubin_IFU_3
{
    public partial class Main : Form
    {
        // Initial data (associative container: Dictionary) 
        private Dictionary<string, MyLinkedList> Data;

        // Associative container for Task1 
        private Dictionary<string, string> AllLongestBatteryLife;

        // Filtered electronic devices (required for Task2) 
        private MyLinkedList Result;



        public IEnumerator DataEnumerator() { return Data.GetEnumerator(); }

        // Singly linked list of unique names of models (reuired for Task2) 
        MyLinkedListOfStrings UniqueModels;
        // Interface methods  
        public void UniqueModelStart() { UniqueModels.Start(); }
        public bool UniqueModelExists() { return UniqueModels.Exists(); }
        public void UniqueModelNext() { UniqueModels.Next(); }
        public string UniqueModelData() { return UniqueModels.GetData(); }

        public Main()
        {
            InitializeComponent();
            ToggleControls();
            SetStatus("Open folder to read data");

            Result = new MyLinkedList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 'OK' button is clicked (Browse for folder) 
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Data = IOUtils.Read(folderBrowserDialog1.SelectedPath);
                    if (Data.Count != 0)
                    {
                        ToggleControls(true);
                        Display("Initial data", Data);
                        SetStatus("Initial data successfully read");
                    }
                    else
                    {
                        SetStatus("Please choose another folder");
                    }
                }
                // Exception is caught: display error message 
                catch (Exception)
                {
                    SetStatus("Files in data folder are not of correct format.");
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void task1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllLongestBatteryLife = TaskUtils.FindCollectorForSpecCountry(Data, textBox1.Text);

            DisplayContainer(AllLongestBatteryLife);
            SetStatus("Electronic devices with longest battery life are found.");
        }

        private void task2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Result = TaskUtils.MoreThanOneCopyP(Data);

            Display("All post cards with more than 1 copy", Result);
            SetStatus("Electronic devices with longest battery life are found.");
        }

        private void task3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Result.Sort();
            Display("Sorted result container", Result);
            SetStatus("Result container sorted");
        }
    }
}
