using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoFiles
{
    class BinarySearchClass
    {
        // perform a binary search on array
        public static void BinarySearch(string[,] Data, string searchElement, int position, int First, int Second, int size)//call this one!!!!!!!!!!!!!!!
        {
            int OperationCount1 = 0; //counts the number of operations 
            int OperationCount = 0; //counts the number of operations 
            Class1.ChangeMonthsToInt(ref Data, size, 1); //chanages months to integers 
            HeapSortSortDataFiles hs = new HeapSortSortDataFiles(); //calls a new object
            hs.PerformHeapSort(ref Data, position, size, ref OperationCount1); //sorts the given array based off of what the user is searching makes searches (best case)
            int low = 0; // 0 is always going to be the first element
            int high = size - 1; // Find highest element
            int middle = (low + high + 1) / 2; // Find middle element
            int location = -1; // Return value -1 if not found
            do //Search for element
            {
                if (searchElement == Data[position, middle]) //checks the users search against all elements in the array
                {
                    //once one element is found
                    First = middle;
                    Second = middle;
                    //used for months
                    if (position ==1)
                    {
                        //finds the uperbound, goes back up array from the postion where the search has found a criteria to see if any more are found
                        for (int i = middle-1; i >= 0;i--)
                        {
                            if (searchElement == Data[position, i].Replace(" ", ""))
                            {
                                //OperationCount =i;//counts operations 
                                First = i;
                            }
                            else
                            {
                                //OperationCount++;//counts operations 
                                i = -1;
                            }
                        }
                        //finds the uperbound, goes down array from the postion where the search has found a criteria to see if any more are found
                        for (int i = middle + 1; i < size; i++)
                        {
                            if (searchElement == Data[position, i].Replace(" ", ""))
                            {
                                //OperationCount++;//counts operations 
                                Second = i;
                            }
                            else
                            {
                                //OperationCount++;//counts operations 
                                i = size;
                            }
                        }
                    }
                    //used for all other files 
                    else
                    {
                        //finds the uperbound, goes back up array from the postion where the search has found a criteria to see if any more are found
                        for (int i = middle - 1; i >= 0; i--)
                        {
                            if (searchElement == Data[position, i].Replace(",", ""))
                            {
                                //OperationCount++;//counts operations 
                                First = i;
                            }
                        }
                        //finds the uperbound, goes down array from the postion where the search has found a criteria to see if any more are found
                        for (int i = middle+1; i < size; i++)
                        {
                            if (searchElement == Data[position, i].Replace(",", ""))
                            {
                                //OperationCount++;//counts operations 
                                Second = i;
                            }
                        }
                    }
                    location = middle; // location is current middle
                }
                // middle element is too high
                //if the file being searched is not region do this
                else if (position != 8)
                {
                    if (Convert.ToDouble(searchElement.Replace(":", "")) < Convert.ToDouble(Data[position, middle].Replace(":", "")))  //all other elements can be converted to doubles for comparision
                    {
                        high = middle - 1; // eliminate lower half
                        //OperationCount++;
                    }
                    else // middle element is too low
                    {
                        low = middle + 1; // eleminate lower half
                        //OperationCount++;
                    }
                }
                //below is for region
                else
                {
                    if (0 > (searchElement.Replace(",", "").CompareTo(Data[position, middle].Replace(",", "")))) //compare to checks the values to see which is greater
                    {
                        high = middle - 1; // eliminate lower half
                    }
                    else // middle element is too low
                    {
                        low = middle + 1; // eleminate lower half
                    }
                }
                middle = (low + high + 1) / 2; // recalculate the middle  
                OperationCount++;
            } while ((low <= high) && (location == -1));
            int SizeofTemp;
            int FirstLoopIncrement;
            //no data was found error 
            if (Second == -1 && First == -1)
            {
                Console.WriteLine("ERRRO!! NO DATA WAS FOUND"); 
                Console.ReadLine();
            }
            //if data was found
            else
            {
                //calculate the temp arrays length for storeing all data found and how many times the below loops needs to loop
                if (Second == First)
                {
                    FirstLoopIncrement = Second + 1;
                    SizeofTemp = 1;
                }
                else
                {
                    FirstLoopIncrement = Second + 1;
                    SizeofTemp = (Second - First) + 1;
                }
                OperationCount = OperationCount + SizeofTemp;
                //new array used for holding all data found in main array
                string[,] TempHolder = new string[11, SizeofTemp];
                Class1.ChangeIntToMonth(ref Data, 1200); //changes ints back to months 
                //loops through assigning the new array array with the values found in main
                for (int i = First; i < FirstLoopIncrement; i++)
                {
                    for (int y = 0; y < 11; y++)
                    {
                        TempHolder[y, i - First] = Data[y, (i)];
                    }
                }
                Console.Clear();
                Class1.SendToHTML(TempHolder, (Second - First) + 1); //array send to .HTML file for output
                Console.ReadLine();
            }
            //outputs the number of operations needed to complete search
            Console.WriteLine("In this Binary Search, there were {0} Main operations!", OperationCount);
            Console.ReadLine();
        }
    }
}