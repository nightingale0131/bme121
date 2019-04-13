// Solution for Practice 4
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
            items.Sort( );
            
            // display items to confirm they are sorted, comment out
            WriteLine("Items in file in alphabetical order: ");
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
