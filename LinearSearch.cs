using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoFiles
{
    class LinearSearch
    {
        //Linear Search
        public static void SearchLinear(string[,]FileHolder, string SearchItem, int position, int size)
        {
            int OperationCount1 = 0;
            int OperationCount = 0;
            Class1.ChangeMonthsToInt(ref FileHolder, size, 1); // changes months to ints
            HeapSortSortDataFiles hs = new HeapSortSortDataFiles(); //new object 
            hs.PerformHeapSort(ref FileHolder, position, size,ref OperationCount1); // sorts array based on the position with is being searched 
            Class1.ChangeIntToMonth(ref FileHolder, size);// change ints to months 
            int First =-1;
            int Second=0;
            //checks search item against element 
            //finds uper and lower bound to work out temp array size
            for (int i = 0; i < size; i++)
            {
                //position is equal to months 
                if (position ==1)
                {
                    if (SearchItem == FileHolder[position, i].Replace(" ", ""))//checks search item against element 
                    {
                        if (First == -1)
                        {
                            //OperationCount++; //increments operation count 
                            First = i;
                        }
                    }
                }
                //position is any of the other files
                else
                {
                    if (SearchItem == FileHolder[position, i])//checks search item against element 
                    {
                        if (First == -1)
                        {
                            //OperationCount++; //increments operation count 
                            First = i;
                        }
                    }
                }

                if (SearchItem != FileHolder[position, i] && First>=0)
                {
                    //OperationCount++; //increments operation count 
                    Second = i - 1;
                    i = size; // closes for loop
                    
                }
                OperationCount++; //increments operation count 
                //Console.WriteLine(OperationCount);
                //Console.ReadLine();
            }
            //no data found based on search criteria 
            if (First == -1 && Second == 0)
            {
                Console.WriteLine("ERRRO!! NO DATA WAS FOUND");
                Console.ReadLine();
            }
            else
            {
                if((Second < First) && Second ==0)
                {
                    Second = 1199;
                }

                string[,] TempHolder = new string[11, (Second - First) + 1];    // temp array storage for web output
                //assigns the temp array with data found off of search
                for (int i = First; i < Second + 1; i++)
                {
                    for (int y = 0; y < 11; y++)
                    {
                        TempHolder[y, i - First] = FileHolder[y, i];
                    }
                }
                Class1.SendToHTML(TempHolder, (Second - First) + 1); // outputs to .HTML
                //outputs the number of operations for the search 
                Console.WriteLine("In this Linear Search, there were {0} Main operations!", OperationCount);
                Console.ReadLine();
            }
        }
    }
}
