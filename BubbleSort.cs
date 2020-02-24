using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoFiles
{
    class BubbleSort
    {
        //bubble sort 
        public static void SortBubble(ref string[,] FileHolder,int Size, int position)
        {
            int OperationCount=0; // counts the operations 
            Class1.ChangeMonthsToInt(ref FileHolder, Size,1); //changes the months to ints
            int Endcount = 1;
            while (Endcount >0) //only stops if the array is in order 
            {
                Endcount = 0; //each loop has a fresh 0 count to see if in order
                for (int i = 0; i < Size - 1; i++)
                {
                    if (position == 8 || position == 3) // used for Regions and Time
                    {
                        if (0 < (FileHolder[position, 1 + i].CompareTo(FileHolder[position, i]))) //checks to see if the first element is greater than the second
                        {
                            OperationCount++; //increments the number of operations
                            string[] TempHolder = new string[11]; // 1d array to hold a sinlge entry of data whists being swapped around 
                            //swaps elements around
                            for(int y = 0; y< 11 ;y++)
                            {
                                TempHolder[y] = FileHolder[y,i];
                                FileHolder[y, i] = FileHolder[y, 1 + i];
                                FileHolder[y, 1+i] = TempHolder[y];
                                Endcount++;
                            }
                        }
                    }
                    //used for all other files
                    else
                    {
                        if (Convert.ToDouble(FileHolder[position, i]) < Convert.ToDouble(FileHolder[position, 1 + i]))//checks to see if the second element is greater than the second
                        {
                            OperationCount++; //increments the number of operations
                            string[] TempHolder = new string[11];// 1d array to hold a sinlge entry of data whists being swapped around
                            //swaps elements around
                            for (int y = 0; y < 11; y++)
                            {
                                TempHolder[y] = FileHolder[y, i];
                                FileHolder[y, i] = FileHolder[y, 1 + i];
                                FileHolder[y, 1+i] = TempHolder[y];
                                Endcount++;
                            }
                        }
                    }
                }
            }
            Class1.ChangeIntToMonth(ref FileHolder, Size); //changes ints back to months
            //outputs the number of operations needs to complete sort
            Console.WriteLine("In this bubble sort, there were {0} operations in chnaging data!",OperationCount);
            Console.ReadLine();
        }
    }
}
