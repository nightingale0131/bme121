using System;
using System.IO; // to read files
using static System.Console;
using MediCal;	// import MediCal namespace

namespace LinkedList
{
	
	class LL
	{
		
		// good practice to keep Node class private, only 
		// allows class LL to use the Node class.
		class Node
		{
			// private fields
			Node nextNode; // reference to next element in list
			Drug data; // data node will hold

			// public properties
			public Node Next {get{return nextNode;} set{nextNode = value;}}
			public Drug Data {get{return data;} set{data = value;}}
			
			// constructor
			public Node( Drug data ) { this.data = data; }
		}
		
		// FIELDS - keep private
		Node head; // defaults to null
		Node tail; // defaults to null
		int count; // defaults to 0
		
		// METHODS
		public delegate string PrintFormat( Drug data  );
		// method to print the contents of LL to console
		public void PrintList( PrintFormat Writer )
		{
			Node currentNode = head;
			
			for( int i = 0; i < this.count; i++ )
			{
				// in Main: LL.PrintList( DetailedString );
				string line = Writer( currentNode.Data );
				WriteLine($"{i,5} { line }");
				currentNode = currentNode.Next;
			}
		}
		
		// method to add a new node to the end of the LL
		public void Append( Drug newData )
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
		public Drug Pop( )
		{
			
			// case 2: list is empty
			if( count == 0 ) return null;
			
			// case 1: only one node in list
			if( count == 1 ) tail = null;
			
			// copy data from first node
			Drug poppedData = head.Data;
			
			// remove popped node from LL
			head = head.Next;
			
			// decrease count
			count--;
			
			return poppedData;
			
		}
		
		// method to remove the first node that contains drugname
		public void Remove( string drugName )
		{
			// initialize two pointers
			Node currentNode = head;
			Node prevNode = null;
			
			// linear search to find node to remove
			while( currentNode != null && !currentNode.Data.Name.Contains( drugName ) )
			{
				// increment pointers
				prevNode = currentNode;
				currentNode = currentNode.Next;
			}
			
			// case 1: if none of the nodes have drugName or list is empty
			if( currentNode == null ) return;
			
			// case 2: if there is only one node in the list
			if( count == 1 )
			{
				head = null;
				tail = null;
			}
			// case 3: if node being removed is the head 
			else if( currentNode == head )
			{
				head = currentNode.Next;
			}
			// case 4: if node being removed is the tail
			else if( currentNode.Next == null )
			{
				tail = prevNode;
				prevNode.Next = null;
			}
			// case 5: default case
			else
			{
				prevNode.Next = currentNode.Next;
			}
			
			// decrease count
			count--;
		}
		
		// method to insert new data in order, assume list is already sorted
		public void AddInOrder( Drug newData )
		{
			// check if data is valid
			if( newData == null ) throw new ArgumentNullException( );
			
			// create new node
			Node newNode = new Node( newData );
			
			// initialize two pointers
			Node currentNode = head;
			Node prevNode = null;
			
			// case 1: if LL is empty
			if( count == 0 )
			{
				head = newNode;
				tail = newNode;
			}
			else 
			{
				// Locate where newData should be inserted (assume ascending order)
				while( currentNode != null && currentNode.Data.Compare( newData ) <= 0 )
				{
					//increment pointers
					prevNode = currentNode;
					currentNode = currentNode.Next;
				}
				
				// Insert newNode somewhere
				// case 2: Insert at beginning
				if( currentNode == head )
				{
					head = newNode;
				}
				// case 3: Insert at end
				else if( currentNode == null )
				{
					prevNode.Next = newNode;
					tail = newNode;
				}
				// case 4: default case
				else 
				{
					prevNode.Next = newNode;
					
				}
				//update next pointer of newNode
				newNode.Next = currentNode;
				
			}
			
			count++;
		}
		
		// method to sort LL via Insertion Sort
		public void InsertionSort( )
		{
			// initialize a new empty LL
			LL sortedLL = new LL( );
			
			// if this LL is empty or there's only 1 node
			if( this.count <= 1 ) return;
			
			// iterate through this LL
			while( this.head != null )
			{
				// 'take out' first node in unsorted LL
				Drug currentDrug = this.Pop( );
				
				// insert in sortedLL in order
				sortedLL.AddInOrder( currentDrug );
			}
			
			this.head = sortedLL.head;
			this.tail = sortedLL.tail;
			this.count = sortedLL.count;
		}
	}
	
    static class Program
    {
        static void Main( )
        {
			// declare new linked lists
            LL LLofDrugs = new LL( );
            LL emptyList = new LL( );
            
            // read file, test your Append method
            using( FileStream file = File.Open( "RXQT1503.txt", FileMode.Open, FileAccess.Read ) )
            using( StreamReader reader = new StreamReader( file ) )
            {
				for( int i = 0; i < 10; i++ )
				{
					LLofDrugs.AddInOrder( Drug.ParseFileLine( reader.ReadLine( ) ) );
				}
			}			
			
			//PrintFormat MyMethod = DetailedString;
			
			LLofDrugs.PrintList( DetailedString );
			WriteLine();
			LLofDrugs.PrintList( ShortString );
				
        }
        
        static string DetailedString( Drug data )
        {
			return data.ToFileLine();
		}
		
		static string ShortString( Drug data )
		{
			return data.ToString();
		}
        
    }
}
