using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Resources;
using System.Text.RegularExpressions;
namespace MergeTwoFiles
{
    class Task2_AscendingDescendingOrder
    {
        //Sorts in Ascending or Descending Order
        public static void AsendingDesendingOrder(ref string[,] FileHolder1, int size, int SortChoice, ref bool Menu3)
        {
            string[] FilePaths = Class1.SortArrayBubble(); // assigns array all file paths from folder
            bool ExitFirstWhile = false; // used for first whils loop
            bool TF2 = false; // used for two while loop 
            bool TF3 = false; //used for thrid while loop
            int PositionToOrder = -1;
            while (ExitFirstWhile == false)
            {
                //output all files avaliable for sorting
                Console.Clear();
                Console.WriteLine("Below Shows all Avaliable  file Titles:    ");
                for (int i = 0; i < 11; i++)
                {
                    FilePaths[i] = Regex.Replace(Path.GetFileNameWithoutExtension(FilePaths[i]), @"[\d-]", string.Empty).Replace("_", "");// displays the file names for user to chose from 
                    Console.WriteLine(FilePaths[i]);
                }
                Console.WriteLine("Please Enter the File you Wish to sort:  ");
                string UserChoice = Console.ReadLine();// user input data 
                bool EnterCorrect = false;
                for (int i = 0; i < 11; i++)
                {
                    if (UserChoice == FilePaths[i]) // checks if the user has input a valid file path name
                    {
                        EnterCorrect = true;
                        PositionToOrder = i;
                    }
                }
                try
                {
                    if (EnterCorrect == true)
                    {
                        while (TF2 == false)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Please Enter A for ascending or D for Descending:    ");
                            char UserInput;
                            try
                            {   //checks the following statements for errors
                                UserInput = Convert.ToChar(Console.ReadLine());
                                if ((UserInput == 'd' || UserInput == 'D' || UserInput == 'a' || UserInput == 'A')) //checks the user entered a valid letter for either choice Descending or Ascending
                                {
                                    int Choice = -1;
                                    if (UserInput == 'd' || UserInput == 'D') //Descending
                                    {
                                        Choice = 0;//Descending = 0 
                                        if (SortChoice == 1) //bubble sort
                                        {
                                            BubbleSort.SortBubble(ref FileHolder1, size, PositionToOrder); //bubble sorts the array given
                                            Class1.SendToHTML(FileHolder1, size); //outputs to .HTML file
                                        }
                                        else if(SortChoice == 2)//heap sort
                                        {
                                            int OperationCount = 0;
                                            HeapSortSortDataFiles hs = new HeapSortSortDataFiles();
                                            Class1.ChangeMonthsToInt(ref FileHolder1, size, 1); //changes months to ints
                                            hs.PerformHeapSort(ref FileHolder1, PositionToOrder, size,ref OperationCount); //performs a heap sort
                                            Class1.ChangeIntToMonth(ref FileHolder1, size); // changes int to months 
                                            Class1.SwapValues(ref FileHolder1, size); // swaps values for descending
                                            Class1.SendToHTML(FileHolder1, size); //outputs to .HTML file
                                            //outputs the number of operations takesn for the sort
                                            Console.WriteLine("In this Heap sort, there were {0} operations in changing data!", OperationCount);
                                            Console.ReadLine();
                                        }
                                        
                                    }
                                    else if (UserInput == 'a' || UserInput == 'A') //Ascending
                                    {
                                        Choice = 1;//Descending = 0 
                                        if (SortChoice == 1) //bubble sort
                                        {
                                            BubbleSort.SortBubble(ref FileHolder1, size, PositionToOrder);//bubble sorts the array given
                                            Class1.SwapValues(ref FileHolder1, size); //swaps values becuase descending was chose
                                            Class1.SendToHTML(FileHolder1, size);//outputs to .HTML file
                                        }

                                        else if (SortChoice == 2) //heap sort
                                        {
                                            int OperationCount = 0;
                                            HeapSortSortDataFiles hs = new HeapSortSortDataFiles();
                                            Class1.ChangeMonthsToInt(ref FileHolder1, size, 1); //changes months to ints
                                            hs.PerformHeapSort(ref FileHolder1, PositionToOrder, size, ref OperationCount); //performs a heap sort
                                            Class1.ChangeIntToMonth(ref FileHolder1, size); // changes int to months 
                                            Class1.SendToHTML(FileHolder1, size); //outputs to .HTML file
                                            //outputs the number of operations takesn for the sort
                                            Console.WriteLine("In this Heap sort, there were {0} operations in changing data!", OperationCount);
                                            Console.ReadLine();
                                        }
                                    }
                                }                            
                                TF2 = true;
                            }
                            catch (System.FormatException e)//Exception handling
                            {
                                Console.WriteLine("Exception caught: {0}", e);
                                Console.WriteLine();
                            }
                        }
                        while (TF3 == false)
                        {
                            Console.WriteLine("Would you like to sort another file? Enter Y/N     ");
                            string UserExitInput;
                            try
                            {   //checks user input
                                UserExitInput = Console.ReadLine();
                                if (UserExitInput == "y" || UserExitInput == "Y") //checks if user enter YES
                                {
                                    TF3 = true;
                                    TF2 = true;
                                    ExitFirstWhile = true;
                                }
                                //if they didnt enter YES
                                else
                                {
                                    TF3 = true;
                                    TF2 = true;
                                    ExitFirstWhile = true;
                                    Menu3 = true;
                                }
                            }
                            catch (System.FormatException e)//Exception handling
                            {
                                Console.WriteLine("Exception caught: {0}", e);
                                Console.WriteLine();
                            }
                        }
                    }
                }
                catch (System.FormatException e) //Exception handling
                {
                    Console.WriteLine("Exception caught: {0}", e);
                    Console.WriteLine();
                }
                Class1.WriteToFile(FileHolder1, size); //writes to .CSV file
            }
        }
    }
}
