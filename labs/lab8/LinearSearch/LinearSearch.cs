/* Solution for practice #1
 * Purpose: Given a file with a list of items, see if the item you want 
 * 			is in there
 *          Quick review of filestream, linear search, and using the 
 *          nullable type
*/
using System;
using System.IO;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main( )
        {            
            string[] items = ExtractItems( "inventory.txt", 100 );
            
            int? index = FindItem( items );
            
            if( index != null )
				WriteLine("Item is in line: {0}", index + 1);
			else
				WriteLine("Item is not in the file!");
            
        }
        
        // method to read file and extract items into a string array
        static string[] ExtractItems( string path, int size )
        {
			// size indicates number of items in the file
			string[] items = new string[size];
			
			// constants for code simplicity
			const FileMode open = FileMode.Open;
			const FileAccess read = FileAccess.Read;
			
			// open file for reading
			using( FileStream file = new FileStream(path, open, read) )
			{
				using( StreamReader reader = new StreamReader(file) )
				{
					// Assumptions about file:
					// - every word is in a separate line
					// - no extra white spaces
					for ( int i = 0; i < size; i++)
					{
						items[i] = reader.ReadLine( );
					}
				}
			}
			
			return items;
		}
		
		// Linear search method to determine if target is in list of 
		// items and returns index if it is there
		// If returning a nullable type, remember to indicate that!
		static int? FindItem( string[] items )
		{
			// if the array is empty, return null
			if( items == null ) return null;
			
			for( int i = 0; i < items.Length; i++  )
			{
				if( IsTarget( items[i] ) ) return i;
			}
			return null;
		}
		
		// Predicate method to decide if the item matches the target
		static bool IsTarget( string item )
		{
			if( item == "desk") return true;
			else return false;
		}
    }
}
