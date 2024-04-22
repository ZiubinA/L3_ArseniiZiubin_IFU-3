using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_ArseniiZiubin_IFU_3
{
    /// <summary> 
    /// Container class for storing nodes in singly linked list 
    /// </summary> 
    public sealed class MyLinkedList
    {
        /// <summary> 
        /// Nested class for node of linked list 
        /// </summary> 
        private sealed class MyNode
        {
            public PostCard Data { get; set; }
            public MyNode Next { get; set; }
            public MyNode() { }
            public MyNode(PostCard data, MyNode address)
            {
                this.Data = data;
                this.Next = address;
            }
        }

        private MyNode head;    // start address 
        private MyNode tail;    // end address 
        private MyNode iP;      // pointer for interface 

        // Constructor: initialization of pointer values 
        public MyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.iP = null;
        }

        /// <summary> 
        /// Gets data of post card
        /// </summary> 
        /// <returns>Data of first element in linked list</returns>  
        public PostCard First() { return head.Data; }

        /// <summary> 
        /// Gets data of post card
        /// </summary> 
        /// <returns>Data of last element in linked list</returns> 
        public PostCard Last() { return tail.Data; }

        /// <summary> 
        /// Gets number of elements in linked list (0 if no elements) 
        /// Expanded get access modifier 
        /// </summary> 
        public int Count
        {
            get
            {
                if (head == null)
                    return 0;
                int k = 0;
                for (MyNode dd = head; dd != null; dd = dd.Next)
                    k++;
                return k;
            }
        }

        /// <summary> 
        /// Adds new element (node) to front of linked list   
        /// </summary> 
        /// <param name="ED">Data of single post card</param> 
        public void AddToFront(PostCard ED)
        {
            var p = new MyNode(ED, null);
            p.Next = head;
            head = p;
        }

        /// <summary> 
        /// Adds new element (node) to end of linked list   
        /// </summary> 
        /// <param name="ED">Data of single post card</param> 
        public void AddToEnd(PostCard ED)
        {
            var p = new MyNode(ED, null);
            if (head != null)
            {
                tail.Next = p;
                tail = p;
            }
            else   // if linked list is empty 
            {
                head = p;
                tail = p;
            }
        }

        /// <summary> 
        /// Deletes nodes in entire linked list 
        /// </summary> 
        public void Destroy()
        {
            while (head != null)
            {
                iP = head;
                head = head.Next;
                iP.Next = null;
            }
            tail = iP = head;   // tail = iP = null; 
        }

        /// <summary> 
        /// Sets interface pointer (IP) to head 
        /// </summary> 
        public void Start() { iP = head; }

        /// <summary> 
        /// Moves interface pointer (IP) to next node 
        /// </summary> 
        public void Next() { iP = iP.Next; }

        /// <summary> 
        /// Checks if interface pointer (IP) is valid 
        /// </summary> 
        /// <returns>True if IP points to valid object; null otherwise</returns> 
        public bool Exists() { return iP != null; }

        /// <summary> 
        /// Searches if an element is found in container 
        /// </summary> 
        /// <param name="myEd">Searched post card</param> 
        /// <returns>True, if searched post card is found, false otherwise</returns> 
        public bool Contains(PostCard myEd)
        {
            for (MyNode p = head; p != null; p = p.Next)
            {
                PostCard ed = p.Data;
                if (ed.Equals(myEd))
                    return true;
            }
            return false;
        }

        /// <summary> 
        /// Get data of element in linked list 
        /// </summary> 
        /// <returns>Data of post card(referenced by interface pointer)</returns> 
        public PostCard GetData() { return iP.Data; }

        /// <summary> 
        /// counts quantity of post card  
        /// </summary> 
        /// <returns>First electronic device (object) with longest battery life</returns> 
        public PostCard CountColPost()
        {
            PostCard NumOfCol = head.Data;
            for (MyNode p = head; p != null; p = p.Next)
            {
                PostCard ed = p.Data;
                if (ed.Quantity > NumOfCol.Quantity && ed.edType == "colored")
                {
                    NumOfCol = ed;
                }
            }
            return NumOfCol;
        }

        /// <summary>
        /// looking for post cards with more than one copy
        /// </summary>
        /// <returns>PostCard with more than one copy</returns>
        public MyLinkedList MoreThanOneCopy()
        {
            MyNode current = head;
            MyLinkedList FS = new MyLinkedList();
            
            while (current != null)
            {
                PostCard EM = current.Data;
                if (EM.Quantity > 1)
                {
                    FS.AddToEnd(EM);
                }
                current = current.Next;
            }
            return FS;
        }

        /// <summary>
        /// Joins two linked lists by appending the nodes of the second list
        /// to the end of the first list.
        /// </summary>
        /// <param name="otherList">The linked list to append to the end of the current list.</param>
        public void Join(MyLinkedList otherList)
        {
            if (head == null)
            {
                // If the current list is empty, set its head to the head of the other list
                head = otherList.head;
            }
            else
            {
                // Find the last node of the current list
                MyNode current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                // Append the other list to the current list
                current.Next = otherList.head;
            }
        }

        /// <summary> 
        /// Sort data of linked list 
        /// Algorithm: selection sort 
        /// </summary> 
        public void Sort()
        {
            for (MyNode s1 = head; s1 != null; s1 = s1.Next)
            {
                // Search for maxmimum value in range 
                MyNode maxv = s1;
                for (MyNode s2 = s1; s2 != null; s2 = s2.Next)
                    if (s2.Data <= maxv.Data)
                        maxv = s2;
                //Swap of values (exchanging data parts) 
                PostCard s = s1.Data;
                s1.Data = maxv.Data;
                maxv.Data = s;
            }
        }

        /// <summary> 
        /// Removes elements from linked list if year is equals 0  
        /// </summary> 
        public void RemoveALL()
        {
            for (MyNode s1 = head; s1 != null; s1 = s1.Next)
            {
                if (s1.Data.year == 0)
                {
                    // Store head node  
                    MyNode temp = head, previous = null;
                    // If head node itself holds the value to be deleted  
                    if (temp != null && temp.Data.year == 0)
                    {
                        head = temp.Next; // Changed head  
                        return;
                    }
                    // Search for the value to be deleted, keep track of the  
                    // previous node as we need to change temp.next  
                    while (temp != null && temp.Data.year != 0)
                    {
                        previous = temp;
                        temp = temp.Next;
                    }
                    // If value was not present in linked list  
                    if (temp == null) return;
                    // Unlink the node from linked list  
                    previous.Next = temp.Next;
                }
            }
        }

        public void InsertAll(MyLinkedList Insertion)
        {
            for (Insertion.Start(); Insertion.Exists(); Insertion.Next())
            {
                PostCard ed = Insertion.GetData();
                // Do not re-insert existing elements 
                if (!this.Contains(ed))
                {
                    MyNode n = new MyNode();
                    n.Data = ed;
                    n.Next = null;
                    // if empty linked list 
                    if (head == null) head = n;
                    else
                    {
                        // if element is inserted to front 
                        if (head.Data < ed)
                        {
                            n.Next = head;
                            head = n;
                        }
                        // Find location for insertion 
                        else
                        {
                            MyNode s = head;
                            while (s != null && s.Next != null &&
                                        ed <= s.Next.Data)
                                s = s.Next;
                            // Insertion after s 
                            n.Next = s.Next;
                            s.Next = n;
                        }
                    }
                }
            }
        }
    }    
}
