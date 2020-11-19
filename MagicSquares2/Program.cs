using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquares2
{
    class Program
    {
        public static int[][] lTiles = new int[][]
        {
            new int[]{16, 3, 2, 13},
            new int[]{5, 10, 11, 8},
            new int[]{9, 6, 7, 12},
            new int[]{4, 15, 14, 1}
        };

        static void Main(string[] args)
        {
            int moves = 4;
            int row = 0;
            int colum = 0;
            int Capture1 = 0;
            int Capture2 = 0;
            int Capture3 = 0;
            int Capture4 = 0;
            printBoard(lTiles);

            while(moves > 0)
            {


            }
            if(Capture1 + Capture1 + Capture3 + Capture4 == 34)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("You lost!");
            }

        }

        public static void printBoard(int[][] tileMap)
        {
            for (int i = 0; i < 4; i++)
            {
                
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(tileMap[i][j].ToString() + " ");
                }
                Console.WriteLine();
            }
        }
    }
    
}
