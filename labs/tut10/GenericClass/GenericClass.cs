using System;
using static System.Console;
//~ using System.IO; // to read files
//~ using MediCal;	// import MediCal namespace

namespace Bme121
{
    static class Program
    {
        static void Main()
        {
			// to test my generic linked list, I generate a list of random integers
			Random rGen = new Random( );
	            
			LL<int> LLofInts = new LL<int>( );
			
			for( int i = 0; i < 10; i++ )
			LLofInts.Append( rGen.Next(101) );
					
			LLofInts.PrintList();
			WriteLine("Min = {0}", LLofInts.FindMin( (a, b) => a.CompareTo(b) ));
			// useful syntax: map the "inputs" of Method in this way, you defined method
			// to be Method( a, b )
			
			LL<int> emptyList = new LL<int>( );
			int max = emptyList.FindMin( (a, b) => a.CompareTo(b));
        }
    }

	class LL<T> // T can represent any type
	{
		// good practice to keep Node class private, only 
		// allows class LL to use the Node class.
		class Node
		{
			// private fields
			Node nextNode; // reference to next element in list
			T data; // data node will hold

			// public properties
			public Node Next {get{return nextNode;} set{nextNode = value;}}
			public T Data {get{return data;} set{data = value;}}
			
			// constructor
			public Node( T data ) { this.data = data; }
		}
		
		// FIELDS - keep private
		Node head; // defaults to null
		Node tail; // defaults to null
		int count; // defaults to 0
		
		// METHODS
		// method to print the contents of LL to console
		public void PrintList( )
		{
			Node currentNode = head;
			
			for( int i = 0; i < this.count; i++ )
			{
				WriteLine($"{i,5} { currentNode.Data }");
				currentNode = currentNode.Next;
			}
		}
		
// method to add a new node to the end of the LL
		public void Append( T newData )
		{
			// check data validity
			if( newData == null ) throw new ArgumentNullException( );
			
			// create new node
			Node newNode = new Node( newData );
			
			Node oldTail = tail;
			
			// case 1: if the list is empty
			if( count == 0 )
			{
				head = newNode;
			}
			// case 2: if the list is not empty
			else
			{
				oldTail.Next = newNode;
			}
			
			tail = newNode;
			
			// increment count
			count++;
		}
		
		// method to remove the first node while returning the data
		public T Pop( )
		{
			
			// case 2: list is empty
			if( count == 0 ) return default(T);
			
			// case 1: only one node in list
			if( count == 1 ) tail = null;
			
			// copy data from first node
			T poppedData = head.Data;
			
			// remove popped node from LL
			head = head.Next;
			
			// decrease count
			count--;
			
			return poppedData;
			
		}
		
		// type is available outside of class if made public
		public delegate int Comparison( T a, T b );
		public T FindMin( Comparison Method )
		{
			Node currentNode = head;
			T min;
			
			// this is what I chose to do, really depends on your design
			// requirements how to handle an empty list!
			// We could've just thrown an exception
			if( count == 0 ) min = default(T);
			else min = currentNode.Data;
			
			// linear search for maximum
			while( currentNode != null )
			{
				// if min is larger than current node
				if( Method( min, currentNode.Data ) > 0 )
					min = currentNode.Data;
				
				// increment pointer
				currentNode = currentNode.Next;
			}
			
			return min;
		}
	}
}
