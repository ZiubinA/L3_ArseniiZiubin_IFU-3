using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_ArseniiZiubin_IFU_3
{
    /// <summary> 
    /// Container class for storing nodes of strings (singly linked list) 
    /// </summary> 
    public sealed class MyLinkedListOfStrings
    {
        private sealed class MyNode
        {
            public string Data { get; private set; }
            public MyNode Next { get; set; }
            public MyNode() { }
            public MyNode(string data, MyNode address)
            {
                this.Data = data;
                this.Next = address;
            }
        }

        private MyNode head;    // start address 
        private MyNode tail;    // end address 
        private MyNode iP;      // pointer for interface 

        private MyNode dummyHead;
        private MyNode dummyTail;

        public MyLinkedListOfStrings()
        {
            this.dummyHead = new MyNode(null, null);
            this.dummyTail = new MyNode(null, null);
            this.dummyHead.Next = this.head;
            this.dummyTail.Next = this.tail;

            this.head = null;
            this.tail = null;
            this.iP = null;
        }
        // Interface methods 
        public string First() { return head.Data; }
        public string Last() { return tail.Data; }

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

        public void AddToFront(string s)
        {
            var p = new MyNode(s, null);
            p.Next = this.dummyHead.Next;
            this.dummyHead.Next = p;
            head = p;
            if (this.head == null)
                this.tail = p; // update tail
            this.head = p;
            // or 
            //head = new MyNode(student, p); 
        }

        public void AddToEnd(string s)
        {
            var p = new MyNode(s, null);
            if (head != null)
            {
                tail.Next = p;
                tail = p;
                this.dummyHead.Next = p;
            }
            else   // if linked list is empty 
            {
                head = p;
                tail = p;
            }
            this.dummyTail.Next = p;
        }

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

        public void Start() { iP = head; }
        public void Next() { iP = iP.Next; }
        public bool Exists() { return iP != null; }

        public bool Contains(string s)
        {
            for (MyNode p = head; p != null; p = p.Next)
            {
                string sp = p.Data;
                if (sp.Equals(s))
                    return true;
            }
            return false;
        }

        public string GetData() { return iP.Data; }
    }
}
