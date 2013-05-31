// Original Author Colden

using System;
using System.Collections;
using System.Collections.Generic;

namespace SlothathorRestart
{
    /// <summary>
    /// List of objects</summary>
    /// <typeparam name="T">
    /// Type of objects stored</typeparam>
    class List<T> : IEnumerable<T>
    {
        /// <summary>
        /// First item in list</summary>
        Node<T> head;
        /// <summary>
        /// Last item in list</summary>
        Node<T> tail;
        /// <summary>
        /// Number of items in list</summary>
        private int count;

        private int counter;

        /// <summary>
        /// Number of Nodes in list</summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Indexer for List</summary>
        /// <param name="index">
        /// Index of List item to get or set</param>
        /// <returns>
        /// get: Data at index set: nothing</returns>
        public T this[int index]
        {
            get
            {
                Node<T> temp = head;

                try
                {
                    for (int ii = 0; ii < index; ii++)
                    {
                        temp = temp.Next;
                    }
                }
                catch (Exception)
                {
                    throw new IndexOutOfRangeException("index is not in List");
                }

                return temp.Data;
            }

            set
            {
                Node<T> temp = head;

                try
                {
                    for (int ii = 0; ii < index; ii++)
                    {
                        temp = temp.Next;
                    }
                }
                catch (Exception)
                {
                    throw new IndexOutOfRangeException("index is not in List");
                }

                temp.Data = value;
            }
        }

        /// <summary>
        /// Enumerator for for loops</summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> temp = head;

            counter = count;

            for (int ii = 0; ii < counter; ii++)
            {
                yield return temp.Data; 

                temp = temp.Next;
            }
        }

        ///<summary>
        /// Returns other enumerator</summary>
        /// <returns></returns
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Default Constructor, sets default values</summary>
        public List()
        {
            count = 0;
            head = null;
            tail = null;
        }

        /// <summary>
        /// Adds item to end of list</summary>
        /// <param name="data">
        /// Data to add to list</param>
        public void Add(T data)
        {
            Node<T> toBeAdded = new Node<T>(data, count);        // Node to be put into array

            if (head == null)
            {
                //Console.WriteLine( "First Add" );
                head = toBeAdded;
                tail = head;
            }
            else
            {
                //Console.WriteLine( "Not First Add" );
                tail.Next = toBeAdded;
                tail = tail.Next;
            }

            count++;
        }

        /// <summary>
        /// Adds Item to front of List</summary>
        /// <param name="data">
        /// Item to add to front of List</param>
        public void AddFront(T data)
        {
            Node<T> toBeAdded = new Node<T>(data, 0, head);
            Node<T> temp = head;

            head = toBeAdded;
            count++;

            for (int ii = 1; ii < count; ii++)
            {
                temp.Index++;
                temp = temp.Next;
            }
        }

        /// <summary>
        /// Remove first Node with data</summary>
        /// <param name="data">
        /// Data to look for when removing</param>
        /// <returns>
        /// Whether or not anything is actually deleted</returns>
        /// <summary>
        /// Remove first Node with data</summary>
        /// <param name="data">
        /// Data to look for when removing</param>
        /// <returns>
        /// Whether or not anything is actually deleted</returns>
        public Boolean Del(T data)
        {
            Node<T> previous = head;    // Last node checked
            Node<T> current = head;    // Current node being checked

            if (head == null)
                Console.WriteLine("The list is empty.");
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (current.Data.Equals(data))
                    {
                        //Console.WriteLine( "Equal" );
                        previous.Next = current.Next;  // Sets last's Next to not be temp, but temp's Next, cutting temp out
                        count--;

                        // Subtract 1 from each Node after Current
                        for (int j = current.Index; j < count; j++)
                        {
                            current = current.Next;
                            current.Index--;
                        }
                        return true;
                    }
                    else
                    {
                        //Console.WriteLine( "Not equal" );
                        previous = current;
                        current = current.Next;
                    }
                }
            }
            return false;
        }

        public Boolean RemoveAt(int index)
        {
            Node<T> previous = head;
            Node<T> current = head;

            try
            {
                for (int ii = 0; ii < index; ii++)
                {
                    previous = current;
                    current = current.Next;
                }

                previous.Next = current.Next;
                current = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Clear()
        {
            Node<T> previous = head;    // Last node checked
            Node<T> current = head;    // Current node being checked


            if (current != null)
            {
                current = null;
                tail = null;
            }
            else if (current != null && current.Next != null)
            {
                while (current.Next != null)
                {
                    current = current.Next;
                    previous = null;
                    previous = current;
                }
            }

            head = null;
            count = 0;
        }

        /// <summary>
        /// Returns whether or not the list is empty</summary>
        /// <returns>
        /// Emptyness of list</returns>
        public Boolean IsEmpty()
        {
            return head == null;
        }

        /// <summary>
        /// Returns all items in List</summary>
        /// <returns>
        /// A string of all items</returns>
        public override string ToString()
        {
            string returnString = head.Index + ": " + head.ToString();      // String to add elements to
            Node<T> temp = head;                        // Current Node to be added to string

            for (int ii = 0; ii < count - 1; ii++)
            {
                temp = temp.Next;                       // Set temp as next
                returnString += ", " + temp.Index + ": " + temp.ToString(); // Add temp to string
            }

            return returnString;
        }
    }
}