using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using Utility_Library;
using System.Drawing;

namespace ica18_jake_wilkins
{
    class Program
    {         
        static void Main(string[] args)
        {
            //variables
            Random rng = new Random();
            int[] iArray1 = new int[20];
            int[] iArray2;
            int search = 0;
            int found = 0;

            //assigning random values 1-29 to each spot in the first array
            for (int i = 0; i < iArray1.Length; i++)
                iArray1[i] = rng.Next(1, 30);            
            Draw(iArray1, "iArray1, Original Contents");

            //clone array1 then gives array2 a set value of 0 in a particular spot
            iArray2 = (int[])iArray1.Clone();
            iArray2.SetValue(0, 1);
            Draw(iArray2, "iArray2");
            Draw(iArray1, "iArray1");

            //creating array with 40 int values for array2, copy contents of array 1 starting at index10
            iArray2 = new int[40];
            Array.Copy(iArray1, 0, iArray2, 9, 20);
            Draw(iArray2, "iArray2");

            //clearing array2
            Array.Clear(iArray2, 9, 10);
            Draw(iArray2, "iArray2 Cleared");

            //sorting array1
            Array.Sort(iArray1);
            Draw(iArray1, "Sorted iArray1");

            //search array1 for a number between 1-29 to see if it got generated or not
            search = Utilities.GetInt("Enter an integer from 1 to 29: ", 1, 29);
            found = Array.BinarySearch(iArray1, search);
            if (found > 0)                        
                Draw(iArray1, "Sorted iArray1", found, search);           
            else
                Draw(iArray1, "Value could not be found");

            //reverse array1
            Array.Reverse(iArray1);
            Draw(iArray1, "iArray1 reversed");                     
        }
        static public void Draw(int[] iArray, string sMessage)
        {
            CDrawer gdi = new CDrawer();
            gdi.Scale = 20;

            for (int i = 0; i < iArray.Length; i++)
                gdi.AddLine(i, 0, i, iArray[i], Color.YellowGreen, 10);
            gdi.AddText(sMessage, 24, Color.LightGray);
            Utilities.Pause("Press any key to continue...");
            Console.Clear();
        }
        static public void Draw(int[] iArray, string sMessage, int location, int size)
        {
            CDrawer gdi = new CDrawer();
            gdi.Scale = 20;
            iArray[location] = 0;

            for (int i = 0; i < iArray.Length; i++)
                gdi.AddLine(i, 0, i, iArray[i], Color.YellowGreen, 10);
            gdi.AddText(sMessage, 24, Color.LightGray);
            gdi.AddLine(location, 0, location, size, Color.Red, 10);
            Utilities.Pause("Press any key to continue...");
            Console.Clear();
        }
    }
}
