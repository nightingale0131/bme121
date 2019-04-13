// NewPatient class for BME 121 Lab 4
// Updated: Oct 12, 2018

using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main()
        {
            // declare new patient
            Patient patient1 = new Patient("Danny", "Rand", 60, "Spinal");
            
            // Print patient name
            WriteLine("Registering new patient: {0} {1}",patient1.firstName, patient1.lastName);
            
            // declare another patient with a different constructor
            Patient patient2 = new Patient();
            
            // Print patient2's name
            WriteLine("Registering new patient: {0} {1}",patient2.firstName, patient2.lastName);
            
            // print each instance
            // Note that ToString() is called in this case to literally turn
            //	the instance into a string, which is defined below in the
            //	ToString() method
            WriteLine();
            WriteLine("Patient1: {0}", patient1);
            WriteLine("Patient2: {0}", patient2);
            
            // Create an array of patients
            Patient[] patients = {
				new Patient("Danny", "Rand", 60, "Spinal"),
				new Patient("Robert", "Frost", 70, "General"),
				new Patient("Bruce", "Lee", 90, "General"),
				new Patient("Dave", "Button", 100, "Local"),
				new Patient("Colleen", "Wing", 60, "Local")
				};
            
            // Print out each patient
            WriteLine();
            WriteLine("Array of patients:");
            for(int p = 0; p < 5; p++)
            {
				WriteLine(patients[p]);
			}
            
        }
    }
    
    class Patient
    {
		// declare fields
		// it is not good practice to make fields public, but in this case
		//	I wanted to be able to initially access them in lines 14 & 20
		public string firstName;
		public string lastName;
		public double weight;
		string anestheticType; // can be "General", "Local", or "Spinal"
		
		public static string hospitalName = "Grand River";
		
		// constructor method
		public Patient(string initFName, string initLName, double initWeight, string aType)
		{
			firstName = initFName;
			lastName = initLName;
			weight = initWeight;
			anestheticType = aType;
		}
		
		// alternative constructor with no arguments
		public Patient()
		{
			firstName = "John";
			lastName = "Doe";
			weight = 60; //kg
			anestheticType = "General";
		}
		
		// what to print should the instance be an argument in Write() or WriteLine()
		public override string ToString()
		{
			string aType;
			if(anestheticType == "General")
			{
				aType = "G";
			}
			else if(anestheticType == "Local")
			{
				aType = "L";
			}
			else
			{
				aType = "S";
			}
			
			return $"{firstName} {lastName} {weight} {aType}";
		}
		
		// Alternative implementation with switch-case statement
		// Uncomment below and comment the ToString() method above
		//~ public override string ToString()
		//~ {
			//~ string aType;
			//~ switch(anestheticType)
			//~ {
				//~ case "General":
					//~ aType = "G";
					//~ break;
				//~ case "Local":
					//~ aType = "L";
					//~ break;
				//~ case "Spinal":
					//~ aType = "S";
					//~ break;
				//~ default:
					//~ aType = "?";
					//~ break;
			//~ }
			
			//~ return $"{firstName} {lastName} {weight} {aType}";
		//~ }
	}
}
