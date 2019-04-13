// BME 121 Tut 6 Practice

using System;
using static System.Console;
using static System.Math;

namespace Bme121
{
    static class Program
    {
        static void Main()
        {
            // instantiate Patient class
            Patient patient1 = new Patient("John", "Doe", "Prolixin",
											100, 12, 2);
            
            // Test TimeBeforeRefill property
            // Note that it is used like a field!
            WriteLine("Time before refill: {0}", patient1.TimeBeforeRefill);
            
            // Retrieving the property causes 'get' to be called
            WriteLine("Medication left: {0:F1} oz", patient1.Quantity);
            
            // Assigning a value to the property causes 'set' 
            //  to be called
            patient1.Quantity = 500;
            
            // Setting the auto-implemented property IdNumber
            patient1.IdNumber = 123456;
            
            // Getting the auto-implemented property IdNumber
            WriteLine("ID Number is {0}", patient1.IdNumber);
        }
    }
    
    class Patient
    {
		// Declare Fields, remember to keep them private!
		string fName, lName, medication;
		double quantity, perDose; // mL
		int dosage; // number of doses/day
		
		// Constructor
		public Patient(string fName, string lName, string medication, 
						double quantity, double perDose, int dosage)
		{
			this.fName = fName;
			this.lName = lName;
			this.medication = medication;
			this.quantity = quantity;
			this.perDose = perDose;
			this.dosage = dosage;
		}
		
		// Properties
		public double Quantity
		{
			get
			{
				// We want to display the quantity in oz
				return quantity/30.0;
			}
			set
			{
				// Adding data validation and an exception
				if ( value < 0 )
				{
					// throw the best fit exception if input is not valid
					throw new ArgumentOutOfRangeException( );
				}
				else
				{
					// user is entering the value in oz, so we must convert it back to mL
					quantity = value*30; // use the value keyword to set the field
				}
			}
		}
		
		// read-only property that returns number of days before refill 
		// is needed
		public string TimeBeforeRefill
		{
			get
			{
				// Floor is a method in Math that always rounds up
				double daysLeft = Floor(quantity/(perDose*dosage));
				return $"{daysLeft:F0} days";
			}
			
			// No set because it's a read-only property
		}
		
		// Auto-implemented property
		// Note that no field variable is used, yet we can assign and read
		//  values from it in Main( )
		public int IdNumber{ get; set; }
		
	}
}
