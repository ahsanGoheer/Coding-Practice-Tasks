using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresDay1_2 // Start Namespace.
{
    class Stack // Start Class.
    {
        private object[] array;
        private int stackPointer;
        private int arraySize;
        //Constructor.
        public Stack(int arraySize)
        {
            this.arraySize = arraySize;
            this.array = new object[arraySize];
            this.stackPointer = -1;
        }

        //Check is stack is empty.
        private bool isEmpty()
        {
            return this.stackPointer == -1;
        }
        //Check if is full.
        private bool isFull()
        {
            return this.stackPointer==(arraySize-1);
        }
        //Method to add items to the stack.
        public void Push(object item)
        {
            if(!isFull())
            {
                this.array[++this.stackPointer] = item;
                this.stackPointer += 1;
                //Console.WriteLine($"Push : {(this.stackPointer)}");

            }

        }
        //Method to remove items from the stack.
        public object Pop()
        {
           if(!isEmpty())
            {
                object temp;
                temp = this.array[this.stackPointer];
                this.stackPointer -= 1;
                //Console.WriteLine($"Pop : {this.stackPointer} ");
                return temp;
            }
            return null;
        }

        //Get Number of Items in Stack.
        public int Count { get { return this.stackPointer + 1; } }

    }//End Class.
}//End Namespace.
