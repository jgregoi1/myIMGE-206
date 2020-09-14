using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSorter
{
    class Program
    {
        delegate string sortingFunction(string[] a);
        static void Main(string[] args)
        {
            Console.WriteLine("please enter a sentence.");
            string input = Console.ReadLine();

            string[] unSorted;
            string[] sorted;

            int unSortedLength = 0;
            int sortedLength = 0;

            sortingFunction findHiLow;

            string[] splitUp = input.Split(' ');

            foreach (string sThisString in splitUp)
            {
                if(sThisString.Length == 0)
                {
                    continue;
                }

                unSortedLength++;
            }

            unSorted = new string[unSortedLength];
            unSortedLength = 0;

            foreach (string sThisString in splitUp)
            {
                if(sThisString.Length == 0)
                {
                    continue;
                }

                unSorted[unSortedLength] = sThisString;

                unSortedLength++;
            }

            sorted = new string[unSortedLength];

            Console.Write("Ascending or Descending? ");
            string sDirection = Console.ReadLine();

            if (sDirection.ToLower().StartsWith("a"))
            {
                findHiLow = new sortingFunction(FindLowestValue);
            }
            else
            {
                findHiLow = new sortingFunction(FindHighestValue);
            }

            sortedLength = 0;

            while( unSorted.Length > 0)
            {
                sorted[sortedLength] = findHiLow(unSorted);

                RemoveUnsortedValue(sorted[sortedLength], ref unSorted);

                sortedLength++;
            }

            Console.WriteLine("The sorted list is: ");
            foreach (string thisNum in sorted)
            {
                Console.Write($"{thisNum} ");
            }

            Console.WriteLine();
        }

           
        static string FindLowestValue(string[] array)
        {
            string returnWord;

            returnWord = array[0];

            foreach(string word in array)
            {
                if (word.CompareTo(returnWord) == -1)
                {
                    returnWord = word;
                }                

            }

            return returnWord;

        }
        
        static string FindHighestValue(string[] array)
        {
            string returnWord;

            returnWord = array[0];

            foreach(string word in array)
            {
                if (word.CompareTo(returnWord) == 1)
                {
                    returnWord = word;
                }

            }

            return returnWord;

        }

        static void RemoveUnsortedValue(string removeValue, ref string[] array)
        {
            // allocate a new array to hold 1 less value than the source array
            string[] newArray = new string[array.Length - 1];

            // we need a separate counter to index into the new array, 
            // since we are skipping a value in the source array
            int dest = 0;

            // the same value may occur multiple times in the array, so skip subsequent occurrences
            bool bAlreadyRemoved = false;

            // iterate through the source array
            foreach (string srcString in array)
            {
                // if this is the number to be removed and we didn't remove it yet
                if (srcString == removeValue && !bAlreadyRemoved)
                {
                    // set the flag that it was removed
                    bAlreadyRemoved = true;

                    // and skip it (ie. do not add it to the new array)
                    continue;
                }

                // insert the source number into the new array
                newArray[dest] = srcString;

                // increment the new array index to insert the next number
                ++dest;
            }

            // set the ref array equal to the new array, which has the target number removed
            // this changes the variable in the calling function (aUnsorted in this case)
            array = newArray;
        }
    }
}
