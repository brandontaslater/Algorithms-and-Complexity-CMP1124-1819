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
    class Program
    {
        static void Main(string[] args)
        { 
            //Defines and Asigns the Values inside the text files to a 2d array
            ////////////////////////////////////////////////////////////////////
            string[,] FileHolder1 = new string[11, 1200]; //Used to Store the Merged Data Sets
            Class1.ReadFile(ref FileHolder1,0); 
            string[,] FileHolder2 = new string[11, 600]; //Used to Store Data Set 2
            Class1.ReadFile(ref FileHolder2,11);
            string[,] FileHolder3 = new string[11, 600]; //Used to Store Data Set 1
            Class1.ReadFile(ref FileHolder3, 0);
            Class1.AddBothSets(ref FileHolder1, FileHolder2); //Used to Merge the two Data Sets
            ///////////////

            //Sorts All Three 2D Arrays into TimeStamp Sort
            HeapSortSortDataFiles hs = new HeapSortSortDataFiles();
            int CountOperations=0;
            //The 2 Merged Data Sets
            hs.PerformHeapSort(ref FileHolder1, 10, 1200, ref CountOperations);
            Class1.SwapValues(ref FileHolder1, 1200);
            //Data Set 2
            hs.PerformHeapSort(ref FileHolder2, 10, 600, ref CountOperations);
            Class1.SwapValues(ref FileHolder2, 600);
            //Data Set 1
            hs.PerformHeapSort(ref FileHolder3, 10, 600, ref CountOperations);
            Class1.SwapValues(ref FileHolder3, 600);

            //Applications Main Menu System
            bool Menu1 = false; //Bool check for the first While loop
            while (Menu1 == false)
            {
                //first Menu for user.
                //they chose the data set they wish to analyse 
                Console.Clear();
                int UserInput1;
                Console.WriteLine("Analysing Data:");
                Console.WriteLine(" ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾");
                Console.WriteLine("Enter the number 1 to Analyse Data Set 1: ");
                Console.WriteLine(" ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾");
                Console.WriteLine("Enter the number 2 to Analyse Data Set 2: ");
                Console.WriteLine(" ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾");
                Console.WriteLine("Enter the number 3 to Analyse Both Data Sets Together: ");
                Console.WriteLine(" ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾");
                Console.WriteLine("Please enter a Number from the choices layed out above:  ");
                Console.WriteLine(" ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾");
                try
                {
                    UserInput1 = Convert.ToInt32(Console.ReadLine()); //stores the users choice
                    //Second tier Menu
                    bool Menu2 = false; //Bool check for the Second While loop
                    while (Menu2 == false)
                    {
                        //Verifies that the correct Data has been enter (1, 2 or 3)
                        if (UserInput1 == 1 || UserInput1 == 2 || UserInput1 == 3)
                        {
                            //Second menus for user to choice which task 
                            Console.Clear();
                            int UserInput2;
                            Console.WriteLine("Enter the number 1 to sort the data into an ascending or Descending order!");
                            Console.WriteLine(" ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ");
                            Console.WriteLine("Enter the number 2 search using all data files!");
                            Console.WriteLine(" ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾");
                            Console.WriteLine("Enter the number 3 to search for data based on the month!");
                            Console.WriteLine(" ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾");
                            Console.WriteLine("Enter the number 4 to find the minimum and maximum Values for each file!");
                            Console.WriteLine(" ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾");
                            Console.WriteLine("Enter the number 5 to Search for specific Data in Individual Files!");
                            Console.WriteLine(" ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾  ‾  ‾ ");
                            Console.WriteLine("Enter the number 6 to output the Data Set you've choosen to Analyse!");
                            Console.WriteLine(" ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ");
                            Console.WriteLine("Enter the number 7 to Chose Another Data Set!");
                            Console.WriteLine(" ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ");
                            Console.WriteLine("Enter the number 8 to quit the application!");
                            Console.WriteLine(" ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ‾ ");
                            try
                            {
                                UserInput2 = Convert.ToInt32(Console.ReadLine()); //stores the users choice
                                
                                //Switch Statement Based off of Users choice from the above Displayed 
                                switch (UserInput2)
                                {
                                    //Descending Or Ascending
                                    case 1:
                                        //1: Uses Data Set 1
                                        if(UserInput1==1)
                                        {
                                            //Third tier Menu
                                            bool Menu3 = false; //Bool check for the Third tier loop
                                            while(Menu3 == false)
                                            {
                                                //Offers user choice on sort method
                                                Console.Clear();
                                                int UserInput3;
                                                Console.WriteLine("Sorts Avaliable: ");
                                                Console.WriteLine("1:   Bubble   ");
                                                Console.WriteLine("2:   Heap     ");
                                                Console.WriteLine("Please Enter 1 or 2");
                                                try
                                                {
                                                    UserInput3 = Convert.ToInt32(Console.ReadLine()); //stores the users choice
                                                    Task2_AscendingDescendingOrder.AsendingDesendingOrder(ref FileHolder3, 600, UserInput3, ref Menu3); //used for Acsending/Descending order
                                                }
                                                catch (System.FormatException e) //exception handling 
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Exception caught: {0}", e);
                                                    Console.WriteLine();
                                                }
                                            }
                                        }
                                        //2: Uses Data Set 2
                                        else if (UserInput1 == 2)
                                        {
                                            //Third tier Menu
                                            bool Menu3 = false; //Bool check for the Third tier loop
                                            while (Menu3 == false)
                                            {
                                                //Offers user choice on sort method
                                                Console.Clear();
                                                int UserInput3;
                                                Console.WriteLine("Sorts Avaliable: ");
                                                Console.WriteLine("1:   Bubble   ");
                                                Console.WriteLine("2:   Heap     ");
                                                try
                                                {
                                                    UserInput3 = Convert.ToInt32(Console.ReadLine()); //stores the users choice
                                                    Task2_AscendingDescendingOrder.AsendingDesendingOrder(ref FileHolder2, 600, UserInput3, ref Menu3); //used for Acsending/Descending order
                                                }
                                                catch (System.FormatException e) //exception handling 
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Exception caught: {0}", e);
                                                    Console.WriteLine();
                                                }
                                            }
                                        }
                                        //3: Uses Merged Data
                                        else if (UserInput1 == 3)
                                        {
                                            //Third tier Menu
                                            bool Menu3 = false; //Bool check for the Third tier loop
                                            while (Menu3 == false)
                                            {
                                                //Offers user choice on sort method
                                                Console.Clear();
                                                int UserInput3;
                                                Console.WriteLine("Sorts Avaliable: ");
                                                Console.WriteLine("1:   Bubble   ");
                                                Console.WriteLine("2:   Heap     ");
                                                try
                                                {
                                                    UserInput3 = Convert.ToInt32(Console.ReadLine()); //stores the users choice
                                                    Task2_AscendingDescendingOrder.AsendingDesendingOrder(ref FileHolder1, 1200, UserInput3, ref Menu3); //used for Acsending/Descending order
                                                }
                                                catch (System.FormatException e) //exception handling 
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Exception caught: {0}", e);
                                                    Console.WriteLine();
                                                }
                                            }
                                        }
                                        break;
                                    case 2:
                                        //1: Uses Data Set 1
                                        if (UserInput1 == 1)
                                        {
                                            Console.Clear();
                                            Task3_SearchAllData.LinearSearch(FileHolder3, 600); //used for search the given data set for a specific peice of data. using all file elements 
                                            Class1.SendToHTML(FileHolder3, 600); //Sends an array to .HTML file
                                        }
                                        //2: Uses Data Set 2
                                        else if (UserInput1 == 2)
                                        {
                                            Console.Clear();
                                            Task3_SearchAllData.LinearSearch(FileHolder2, 600); //used for search the given data set for a specific peice of data. using all file elements
                                            Class1.SendToHTML(FileHolder2, 600); //Sends an array to .HTML file
                                        }
                                        //3: Uses Merged Data
                                        else if (UserInput1 == 3)
                                        {
                                            Console.Clear();
                                            Task3_SearchAllData.LinearSearch(FileHolder1, 1200); //used for search the given data set for a specific peice of data. using all file elements
                                            Class1.SendToHTML(FileHolder1, 1200); //Sends an array to .HTML file
                                        }
                                        
                                        break;
                                    case 3:
                                        //1: Uses Data Set 1
                                        if (UserInput1 == 1)
                                        {
                                            bool Menu3 = false; //Bool check for the Third tier loop
                                            while (Menu3 == false)
                                            {
                                                //offers user a choice of search method
                                                Console.Clear();
                                                int UserInput3;
                                                Console.WriteLine("Sorts Avaliable: ");
                                                Console.WriteLine("1:   Binary   ");
                                                Console.WriteLine("2:   Linear     ");
                                                try
                                                {   //trys the below UserIntput3 for errors
                                                    UserInput3 = Convert.ToInt32(Console.ReadLine()); //stores the users choice
                                                    Task4_SearchMonth.SearchMonth(FileHolder3, 600, UserInput3); //searches month for a specific month
                                                    Menu3 = true;
                                                }
                                                catch (System.FormatException e) //exception handling 
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Exception caught: {0}", e);
                                                    Console.WriteLine();
                                                }
                                            }  
                                        }
                                        //2: Uses Data Set 2
                                        else if (UserInput1 == 2)
                                        {
                                            bool Menu3 = false; //Bool check for the Third tier loop
                                            while (Menu3 == false)
                                            {
                                                //offers user a choice of search method
                                                Console.Clear();
                                                int UserInput3;
                                                Console.WriteLine("Sorts Avaliable: ");
                                                Console.WriteLine("1:   Binary   ");
                                                Console.WriteLine("2:   Linear     ");
                                                try
                                                {   //trys the below UserIntput3 for errors
                                                    UserInput3 = Convert.ToInt32(Console.ReadLine()); //stores the users choice
                                                    Task4_SearchMonth.SearchMonth(FileHolder2, 600, UserInput3); //searches month for a specific month
                                                }
                                                catch (System.FormatException e) //exception handling 
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Exception caught: {0}", e);
                                                    Console.WriteLine();
                                                }
                                            }
                                        }
                                        //3: Uses Merged Data
                                        else if (UserInput1 == 3)
                                        {
                                            bool Menu3 = false; //Bool check for the Third tier loop
                                            while (Menu3 == false)
                                            {   //trys the below UserIntput3 for errors
                                                //offers user a choice of search method
                                                Console.Clear();
                                                int UserInput3;
                                                Console.WriteLine("Sorts Avaliable: ");
                                                Console.WriteLine("1:   Binary   ");
                                                Console.WriteLine("2:   Linear     ");
                                                try
                                                {
                                                    UserInput3 = Convert.ToInt32(Console.ReadLine()); //stores the users choice
                                                    Task4_SearchMonth.SearchMonth(FileHolder1, 1200, UserInput3); //searches month for a specific month
                                                }
                                                catch (System.FormatException e) //exception handling 
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Exception caught: {0}", e);
                                                    Console.WriteLine();
                                                }
                                            }
                                        }
                                        break;
                                    case 4:
                                        //1: Uses Data Set 1
                                        if (UserInput1 == 1)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Maximum For each File:");
                                            Task5_FindMinMaxVals.FindMaxData(FileHolder3, 600); //Finds the Max values in an array
                                            Console.ReadLine();
                                            Console.WriteLine("Minimum For each File:");
                                            Task5_FindMinMaxVals.FindMinData(FileHolder3, 600); //Finds the Min values in an array 
                                            Console.ReadLine();
                                        }
                                        //2: Uses Data Set 2
                                        else if (UserInput1 == 2)
                                        {
                                            Console.Clear();
                                            Task5_FindMinMaxVals.FindMaxData(FileHolder2, 600); //Finds the Max values in an array 
                                            Task5_FindMinMaxVals.FindMinData(FileHolder2, 600); //Finds the Min values in an array 
                                            //Class1.SendToHTML(FileHolder2, 600); //Sends an array to .HTML file
                                        }
                                        //3: Uses Merged Data
                                        else if (UserInput1 == 3)
                                        {
                                            Console.Clear();
                                            Task5_FindMinMaxVals.FindMaxData(FileHolder1, 1200); //Finds the Max values in an array 
                                            Console.WriteLine("HELLO");
                                            Console.ReadLine();
                                            Task5_FindMinMaxVals.FindMinData(FileHolder1, 1200); //Finds the Min values in an array 
                                            //Class1.SendToHTML(FileHolder1, 1200); //Sends an array to .HTML file
                                            Console.WriteLine("HELLO");
                                            Console.ReadLine();
                                        }
                                        break;
                                    case 5:
                                        {
                                            int SortChoice =-1;
                                            //1: Uses Data Set 1
                                            if (UserInput1 == 1)
                                            {
                                                //Third tier Menu
                                                bool Menu3 = false; //Bool check for the Third tier loop
                                                while(Menu3== false)
                                                {
                                                    //offers user a choice of search method
                                                    Console.Clear();
                                                    Console.WriteLine("Searches Avaliable: ");
                                                    Console.WriteLine("1:   Binary   ");
                                                    Console.WriteLine("2:   Linear     ");
                                                    Console.WriteLine("Please Enter 1 or 2");
                                                    try
                                                    {   //trys the below UserIntput3 for errors
                                                        SortChoice = Convert.ToInt32(Console.ReadLine()); //stores the users choice
                                                        Task6_SearchForIndividualData.SearchingIndividual(FileHolder3, 600, SortChoice, ref Menu3); //searchs a give file for all the data according to the search
                                                        Class1.SendToHTML(FileHolder3, 600); //Sends an array to .HTML file
                                                    }
                                                    catch (System.FormatException e) //exception handling 
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Exception caught: {0}", e);
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                            //2: Uses Data Set 2
                                            else if (UserInput1 == 2)
                                            {
                                                //Third tier Menu
                                                bool Menu3 = false; //Bool check for the Third tier loop
                                                while (Menu3 == false)
                                                {
                                                    //offers user a choice of search method
                                                    Console.Clear();
                                                    Console.WriteLine("Searches Avaliable: ");
                                                    Console.WriteLine("1:   Binary   ");
                                                    Console.WriteLine("2:   Linear     ");
                                                    Console.WriteLine("Please Enter 1 or 2");
                                                    try
                                                    {   //trys the below UserIntput3 for errors
                                                        SortChoice = Convert.ToInt32(Console.ReadLine()); //stores the users choice
                                                        Task6_SearchForIndividualData.SearchingIndividual(FileHolder2, 600, SortChoice, ref Menu3); //searchs a give file for all the data according to the search
                                                        Class1.SendToHTML(FileHolder2, 600); //Sends an array to .HTML file
                                                    }
                                                    catch (System.FormatException e) //exception handling 
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Exception caught: {0}", e);
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                            //3: Uses Merged Data
                                            else if (UserInput1 == 3)
                                            {
                                                //Third tier Menu
                                                bool Menu3 = false; //Bool check for the Third tier loop
                                                while (Menu3 == false)
                                                {
                                                    //offers user a choice of search method
                                                    Console.Clear();
                                                    Console.WriteLine("Searches Avaliable: ");
                                                    Console.WriteLine("1:   Binary   ");
                                                    Console.WriteLine("2:   Linear     ");
                                                    Console.WriteLine("Please Enter 1 or 2");
                                                    try
                                                    {   //trys the below UserIntput3 for errors
                                                        SortChoice = Convert.ToInt32(Console.ReadLine()); //stores the users choice
                                                        Task6_SearchForIndividualData.SearchingIndividual(FileHolder1, 1200, SortChoice, ref Menu3); //searchs a give file for all the data according to the search
                                                        Class1.SendToHTML(FileHolder2, 600); //Sends an array to .HTML file
                                                    }
                                                    catch (System.FormatException e) //exception handling 
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Exception caught: {0}", e);
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case 6:
                                        //1: Uses Data Set 1
                                        if (UserInput1 == 1)
                                        {
                                            Console.Clear();
                                            Class1.SendToHTML(FileHolder3, 600); //Sends an array to .HTML file
                                        }
                                        //2: Uses Data Set 2
                                        else if (UserInput1 == 2)
                                        {
                                            Console.Clear();
                                            Class1.SendToHTML(FileHolder2, 600); //Sends an array to .HTML file
                                        }
                                        //3: Uses Merged Data
                                        else if (UserInput1 == 3)
                                        {
                                            Console.Clear();
                                            Class1.SendToHTML(FileHolder1, 1200); //Sends an array to .HTML file
                                        }
                                        break;
                                    case 7:
                                        Menu2 = true;//Excits the second tier of menu system 
                                        break;
                                    case 8:
                                        Menu2 = true;//Excits entire program
                                        Menu1 = true;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            catch (System.FormatException e) //exception handling
                            {
                                Console.Clear();
                                Console.WriteLine("Exception caught: {0}", e);
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Menu2 = false;
                        }
                    }
                }
                catch (System.FormatException e) //exception handling
                {
                    Console.Clear();
                    Console.WriteLine("Exception caught: {0}", e);
                    Console.WriteLine();
                }
            }
        }
    }
}
