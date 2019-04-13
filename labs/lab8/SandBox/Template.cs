using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main()
        {
			string one = "one";
			string two = "two";
			
			Swap(ref one, ref two);
			
			WriteLine($"one: {one}, two: {two}");
			
			GiveMood(out string mood);
			WriteLine($"How I feel now: {mood}");
			WriteLine($"Length of mood: {mood.Length}");
        }
        
        static void Swap( ref string x, ref string y)
        {
			string temp = x;
			x = y;
			y = temp;
		}
		
		static void GiveMood(out string x)
		{
			Random rGen = new Random();
			int i = rGen.Next(5);
			
			switch( i )
			{
				case 0: x = "Happy"; break;
				case 1: x = "Sad"; break;
				case 2: x = "Calm"; break;
				case 3: x = "Annoyed"; break;
				case 4: x = "Angry"; break;
				default: x = "Confused"; break;
			}
		}
    }
}
