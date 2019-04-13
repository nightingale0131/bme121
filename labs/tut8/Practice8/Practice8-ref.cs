using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main()
        {
			// declare some strings
			string one = "Hello";
			string two = "Goodbye";
			
			WriteLine($"{one}");
			WriteLine($"{two}");
			
			AddEmoji( ref one, ref two);
			
			WriteLine($"{one}");
			WriteLine($"{two}");
		}
		
		// pass by reference method
		static void AddEmoji( ref string a, ref string b)
		{
			a = a + " :)";
			b = b + " :(";
		}
    }
}
