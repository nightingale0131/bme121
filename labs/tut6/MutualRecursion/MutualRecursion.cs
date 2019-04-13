using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main( )
        {
			// Get user input
            WriteLine("Enter a integer: ");
            int number = int.Parse( ReadLine( ) );
            
            // Determine if it's even and if it's odd
            WriteLine("Is it even? {0}", IsEven( number ));
            WriteLine("Is it odd? {0}", IsOdd( number ));
        }
        
        static bool IsEven(int num)
        {
			if ( num == 0 )
				return true;
			else
				return IsOdd( num - 1 );
		}
		
		static bool IsOdd(int num)
		{
			if ( num == 0 )
				return false;
			else
				return IsEven( num - 1 );
		}
    }
}
