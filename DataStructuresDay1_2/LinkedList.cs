using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresDay1_2
{
    //Create a node class.
    public class Node<T>
    {
        public Node<T> Next { get; set; } //Points to the next node.
        public T value { get; set; } // Holds the value of the node.
    }//End Class.

    //Create a Linked List Class.
    class LinkedList<T>
    {
        public Node<T> rootNode { get; private set; } //Is the root node of the list. 


        //Functions in the class.
        public (Node<T> prev, Node<T> found) Find (T value)
        {
            Node<T> prev = null; //Holds the value of the previous node.
            Node<T> curr = this.rootNode; //Holds the value of the root node. 
            if (curr == null) return (null, null); //If the root node is empty then a null value will be returned.
            if (curr.value.Equals(value)) return (prev, curr); // If root node is the desired node then return it. 

            do
            {
                prev = curr;
                curr = curr.Next;
                if(curr.value.Equals(value))
                {
                    return (prev, curr);
                }

            } while (curr.Next!=null);

            return (null, null);
        }
        public Node<T> AddAfter(Node<T> node,T value)
        {

            Node<T> newNode = new Node<T>
            {
                Next = node.Next,
                value = value
            };
                node.Next = newNode;
            return newNode;
        }

        public Node<T> Add(T value)
        {
            Node<T> newNode = new Node<T> {
                Next = null,
                value = value
            };
            if(this.rootNode==null)
            {
                this.rootNode = newNode;
                return newNode;
            }
            Node<T> currentNode = this.rootNode;
            while(currentNode.Next!=null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = newNode;
            return newNode;
        }

        public bool DeleteAfter(Node<T> node)
        {
            var nextNode = node.Next;
            if(node.Next==null)
            {
                return false;
            }
            node.Next = nextNode.Next;
            return true;            
        }

        public bool Delete(T value)
        {
            if (this.rootNode == null) return false;
            else if (this.rootNode.value.Equals(value)) {var node=this.rootNode; this.rootNode = this.rootNode.Next; node = null ; return true; }
            else
            {
                Node<T> prevNode = null;
                Node<T> currNode = this.rootNode;

                do
                {
                    prevNode = currNode;
                    currNode = currNode.Next;
                    if (currNode.value.Equals(value))
                    {
                        prevNode.Next = currNode.Next;
                        currNode.Next = null;
                        return true;
                    }
                   

                } while (currNode.Next != null);
            }
            return false;
        }

        public override string ToString()
        {
            Node<T> node = this.rootNode;
            string output = "[";
            while(node!=null)
            {
                output += node.value.ToString()+" ";
                node = node.Next;
            }
            output += "]";
            return output;
        }
    }//End Class.

}//End Namespace.
