using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresDay1_2 // Start Namespace.
{
    // A Data Structure that grows automatically as data increases and shrinks when it decreases.
    class DynamicArray //Start Class. 
    {
        private object[] array;
        private int size;
        private int count;

        //Default constructor for instances initialized without size.
        public DynamicArray()
        {
            this.size = 1;
            array = new object[this.size];
            this.count = 0;
        }

        //Parameterized constructor for instances initialized with a specified size.
        public DynamicArray(int size)
        {
            this.size = size;
            array = new object[this.size];
            this.count = 0;
        }
        //Setting up an indexer.
        public object this[int index]
        {
            get => this.array[index];
            set => this.array[index] = value;
        }
        //Property to get the number of objects in the given instance. 
        public int Count { get {return this.count; } }

        //A function that doubles the array size by copying contents to new array to add new item.
        private void IncreaseSize()
        {

            object[] tempArray = new object[this.size*2];
            for (int i = 0; i < this.size; i++)
            {
                tempArray[i] = this.array[i];
            }
            this.array = tempArray;
            this.size = this.size*2;
            //Console.WriteLine($"Size of Array Increased to {this.size}"); //**FOR DEBUGGING**
        }

        //A function to add new items to the array.
        public void Add(object newItem)
        {
            if(this.count==this.size)
            {
                IncreaseSize();
            }
            this.array[this.count++] = newItem;
            //Console.WriteLine($"Item Added to Array. The count is : {this.count}");//**FOR DEBUGGING**
        }

        //A function used to remove an item from the array.
        public void Remove(int index)
        {
            if(!isEmpty())
            {
                for(int i=index;i<this.size;i++)
                {
                    this.array[i] = this.array[i + 1];
                }
                this.count-=1;
                ShrinkArray();
            }
        }
        //Function used to reduce the size of an array.
        private void ShrinkArray()
        {
            if(!isEmpty())
            {
                object[] temp = new object[this.count+1];
                for(int i=0;i<this.size-1;i++)
                {
                    temp[i] = this.array[i];
                }
                this.array = temp;
                this.size =this.count+1 ;
            }

        }
        //Function that checks if array is empty or not.
        private bool isEmpty()
        {
            return this.count == 0;
        }
      

    }//End Class.
}// End Namespace.
