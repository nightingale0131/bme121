// Solution for Practice 4,5,6
using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;

namespace Bme121
{
    static class Program
    {
        static void Main( )
        {          
            // modify string[] declaration to use List
            List<string> items = ExtractItems( "inventory.txt" );
            //List<string> items = new List<string>(ExtractItems("inventory.txt"))
            
            // sort list of items alphabetically
            SelectionSort( items );
            
            // display items to confirm they are sorted, comment out
            WriteLine("Items in file in alphabetical order: ");
            foreach( string item in items )
				WriteLine(item);
			
			// Request for a new item to be added	
			WriteLine("Enter an item to add: ");
			string newItem = ReadLine( );
			
			// Check if item is in the list already
			int result = BinarySearch( items, newItem );
			
			// Decide if item should be added or not
			if( result < 0)
				WriteLine("Item is already in the list!");
			else
			{
				// use Insert method from List class
				items.Insert( result, newItem );
				
				WriteLine("Inserted {0} into the list.", newItem); 
			}
			
			// Display items to confirm item was added or not added
            WriteLine("Updated item list: ");
            foreach( string item in items )
				WriteLine(item);
        }
        
        // change method to return List instead of String
        static List<string> ExtractItems( string path )
        {
			// Don't need to specify size anymore!
			List<string> items = new List<string>( );
			
			// constants for code simplicity
			const FileMode open = FileMode.Open;
			const FileAccess read = FileAccess.Read;
			
			// open file for reading
			using( FileStream file = new FileStream(path, open, read) )
			{
				using( StreamReader reader = new StreamReader(file) )
				{
					// Can actually just use the EndOfStream indicator
					//  without worrying that you didn't allocate enough
					// 	space to the array
					while(! reader.EndOfStream)
					{
						items.Add( reader.ReadLine( ));
					}
				}
			}
			
			return items;
		}
		
		static int BinarySearch( List<string> list, string target )
		{
			// can basically use the same code from previous problem,
			//		with some modifications
			
			// if list is empty, just return the beginning of the list
			if( list == null ) return 0;
			
			int first = 0;
			int last = list.Count - 1;
			
			while( first <= last )
			{
				int middle = ( first + last )/2;
				
				int result = target.CompareTo( list[ middle ] );
				
				// you may have needed to modify this area
				if( result < 0 )
					last = middle - 1;
				else if( result > 0 )
					first = middle + 1;
				else
					return -1; // if found return -1
			}
			
			// return first so we have know where to insert the new item
			return first;
		}
		
		static void SelectionSort( List<string> list )
		{
			
			// loop through unsorted part of the list
			for( int unsortedStart = 0; unsortedStart < list.Count; unsortedStart++)
			{
				int minIndex = unsortedStart;
				// find minimum of unsorted part
				for( int i = unsortedStart; i < list.Count; i++ )
				{
					if( list[ i ].CompareTo( list[ minIndex ] ) < 0 )
					{
						minIndex = i;
					}
				}
				
				// swap minimum with element at the beginning of the unsorted array
				string tmp = list[ minIndex ];
				list[ minIndex ] = list[ unsortedStart ];
				list [unSortedStart ] = tmp;
			}
		}
		
    }
}
