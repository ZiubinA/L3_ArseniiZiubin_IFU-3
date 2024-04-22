using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace L3_ArseniiZiubin_IFU_3
{
    public partial class Main : Form
    {
        // Initial data (associative container: Dictionary) 
        private Dictionary<string, MyLinkedList> Data;

        // Associative container for Task1 
        private Dictionary<string, string> SameCountry;

        // Filtered post card (required for Task5) 
        private MyLinkedList Result;

        public Main()
        {
            InitializeComponent();
            ToggleControls();
            SetStatus("Open folder to read data");

            Result = new MyLinkedList();
        }

        public IEnumerator DataEnumerator() { return Data.GetEnumerator(); }

        MyLinkedListOfStrings UniquePostCards;
        // Interface methods  
        public void UniquePostCardsStart() { UniquePostCards.Start(); }
        public bool UniquePostCardsExists() { return UniquePostCards.Exists(); }
        public void UniquePostCardsNext() { UniquePostCards.Next(); }
        public string UniquePostCardsData() { return UniquePostCards.GetData(); }

        /// <summary>
        /// Makes a copy for linked list
        /// </summary>
        /// <param name="Source">Specified linked list to copy from</param>
        public void Copy(ref MyLinkedList Source)
        {
            Result = new MyLinkedList();
            for (Source.Start(); Source.Exists(); Source.Next())
            {
                PostCard ed = Source.GetData();
                Result.AddToEnd(ed);
            }
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
            SameCountry = TaskUtils.FindCollectorForSpecCountry(Data, textBox1.Text);
            if (SameCountry.Count != 0)
            {
                DisplayContainer(SameCountry);
                SetStatus("post cards are found.");
            }
            else
                MessageBox.Show("Such country does not exist. ");
        }

        private void task2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Result = TaskUtils.MoreThanOneCopyP(Data);
            if (Result.Count != 0)
            {
                Display("All post cards with more than 1 copy", Result);
                SetStatus("post cards are found.");
            }
            else
                MessageBox.Show("There is no post cards with more than one copy. ");
        }

        private void task3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Result.Sort();
            Display("Sorted result container", Result);
            SetStatus("Result container sorted");
        }

        private void task4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int j = Result.Count;
            for(int i = 0; i < j; i++)
            {
                Result.RemoveALL();
            }
            if(Result.Count != 0)
            {
                Display("Removed all data where year is unknown", Result);
                SetStatus("Remove is done");
            }
            else if(Result.Count == 0 && j != 0)
                MessageBox.Show("all post cards were removed.. ");
            else
                MessageBox.Show("There is no post cards left after removing. ");

        }

        private void task5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UniquePostCards = TaskUtils.UniqueTypes(Data);

            // Interaction mechanism to pass values between different forms
            CreatePostCards filterForm = new CreatePostCards(this);
            filterForm.Show();
        }
    }
}
