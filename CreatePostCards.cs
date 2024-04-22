using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace L3_ArseniiZiubin_IFU_3
{
    public partial class CreatePostCards : Form
    {
        // Reference to main form
        private Main mainForm = null;

        public CreatePostCards()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor to set reference to main form
        /// </summary>
        public CreatePostCards(Form callingForm)
        {
            mainForm = callingForm as Main;
            InitializeComponent();
            // Fill in with choices for selection
            ChoicesForSelection(checkedListBox1);
        }

        /// <summary>
        /// Populates the checkbox list with country choices
        /// </summary>
        private void ChoicesForSelection(CheckedListBox checkedListBox)
        {
            for (mainForm.UniquePostCardsStart(); mainForm.UniquePostCardsExists(); mainForm.UniquePostCardsNext())
            {
                checkedListBox.Items.Add(mainForm.UniquePostCardsData());
            }
        }

        /// <summary>
        /// Gets the selected countries as a linked list
        /// from the checklist
        /// </summary>
        /// /// <param name="checkedListBox">CheckedLisBox (GUI component)</param>
        /// <param name="Ids">Selected country</param>
        private MyLinkedListOfStrings GetSelectedPostCards(CheckedListBox checkedListBox)
        {
            MyLinkedListOfStrings Ids = new MyLinkedListOfStrings();
            for(int i = 0; i < checkedListBox.Items.Count; i++)
            {
                // Evaluate if item is selected
                if (checkedListBox.GetItemChecked(i))
                {
                    Ids.AddToEnd(checkedListBox
                    .GetItemText(checkedListBox.Items[i]));
                }
            }
            return Ids;
        }

        public MyLinkedList CreateNewContainer(MyLinkedListOfStrings SelectedTypes)
        {
            MyLinkedList PostCards= new MyLinkedList();
            for (SelectedTypes.Start(); SelectedTypes.Exists(); SelectedTypes.Next())
            {
                string selectedEdType = SelectedTypes.GetData();
                var DataEnumerator = mainForm.DataEnumerator();
                while (DataEnumerator.MoveNext())
                {
                    KeyValuePair<string, MyLinkedList> entry = (KeyValuePair<string, MyLinkedList>)DataEnumerator.Current;
                    MyLinkedList ED = entry.Value;
                    for (ED.Start(); ED.Exists(); ED.Next())
                    {
                        PostCard ed = ED.GetData();
                        if (ed.edCountry == selectedEdType)
                        {
                            //Avoid duplicates
                            if (!PostCards.Contains(ed))
                            {
                                PostCards.AddToEnd(ed);
                            }
                        }
                    }
                }
            }
            return PostCards;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            // Get selected types
            MyLinkedListOfStrings SelectedTypes = GetSelectedPostCards(checkedListBox1);
            mainForm.Display(SelectedTypes);
            MyLinkedList SelectedElectronicDevices = CreateNewContainer(SelectedTypes);
            if (SelectedElectronicDevices.Count > 0)
            {
                SelectedElectronicDevices.Sort();
                mainForm.Copy(ref SelectedElectronicDevices);
                mainForm.Display("Container was created",
                SelectedElectronicDevices);
                mainForm.SetStatus("Post cards succesfully showed.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select Country. ");
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            mainForm.SetStatus("Filter operation not executed");
            this.Close();
        }
    }
}
