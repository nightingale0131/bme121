// Purpose: Method overloading exercises

using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main()
        {
			// You'll need to write the isFifty methods
            WriteLine("Enter a number: ");
            string input = ReadLine();
            
            // trys to parse a number from the string
            bool success = Int32.TryParse(input, out int number);
            if( success )
				isMatch = isFifty( number ); // check if it's 50
			else
				isMatch = isFifty( input ); // check if it's "fifty"
				
			if( isMatch ) WriteLine("You entered a fifty.");
			else WriteLine("You did not enter a fifty.");
			
			
        }
        
        // Write 2 isFifty methods that overload each other
        bool isFifty( int a )
        {
			if( a == 50 ) return true;
			return false;
		}
		
		bool isFifty( string a )
		{
			if( a == "fifty" ) return true;
			return false;
		}	

    }
    
	class Rectangle
	{
		// FIELDS
		public double length;
		public double width;
		
		// CONSTRUCTORS
		// Write 2 constructors
		public Rectangle( double side )
		{
			this.length = side;
			this.width = side;
		}
		
		public Rectangle( double length, double width )
		{
			this.length = length;
			this.width = width;
		}
	}
}
