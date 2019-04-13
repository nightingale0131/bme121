// Circle class for BME 121 Tut 4
// Updated: Oct 3, 2018
using System;
using static System.Console;
using static System.Math;

namespace Bme121
{
    static class Test
    {
		// METHODS (belong in a class!)
		// Main() is a method!
        static void Main()
        {
            // creating instance of Circle
            Circle smallCircle = new Circle(2.25);
            
            // display the radius
            double dispRadius = smallCircle.GetRadius();
            WriteLine($"The radius of smallCircle is: {dispRadius}" );
            
            // calculate and display the area
            double dispArea = smallCircle.Area();
            WriteLine($"The area of smallCircle is: {dispArea,4:F2}");
            
            // IGNORE THIS COMMENTED BLOCK
            // use a static method
            //~ dispArea = Circle.GeneralArea(2.25);
            //~ WriteLine($"The area is: {dispArea,4:F2}" );
            
        }
    }
    
    // Classes belong in a namespace!
    class Circle
    {
		// FIELDS (don't make them public)
		double radius;
		
		// METHODS (belong in a class!)
		
		// constructor method
		public Circle(double radius)
		{
			this.radius = radius;
		}
		
		// return radius method
		public double GetRadius()
		{
			return radius;
		}
		
		// calculate area of circle method
		public double Area()
		{
			double area = PI*Pow(radius, 2);
			
			return area;
		}
	}
}
