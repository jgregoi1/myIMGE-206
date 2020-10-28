using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Die
{
    public enum Edirection
    {
        north,
        south,
        east,
        west
    }
    class Program
    {
        Edirection north = Edirection.north;
        Edirection south = Edirection.south;
        Edirection east = Edirection.east;
        Edirection west = Edirection.west;
        static int[,] mCosts = new int[,]
        {
            {0, 2, -1, -1 },  //a
            {-1, 2, 3, -1},   //b
            {2, 20, -1, -1}, //c
            {2, 5, 4, 3},    //d
            {-1, 3, -1, -1}, //e
            {-1, -1, 1, -1}, //f
            {0, 2, -1, -1},  //g
            {-1, -1, -1, -1} //h
        };

        static Edirection[,] mDirection = new Edirection[,]
        {
            {Edirection.north, Edirection.south, Edirection.east, Edirection.west}, //a
            {Edirection.north, Edirection.south, Edirection.east, Edirection.west}, //b
            {Edirection.north, Edirection.south, Edirection.east, Edirection.west}, //c
            {Edirection.north, Edirection.south, Edirection.east, Edirection.west}, //d
            {Edirection.north, Edirection.south, Edirection.east, Edirection.west}, //e
            {Edirection.north, Edirection.south, Edirection.east, Edirection.west}, //f
            {Edirection.north, Edirection.south, Edirection.east, Edirection.west}, //g
            {Edirection.north, Edirection.south, Edirection.east, Edirection.west}  //h
        };

        int[][] lCost = new int[][]
        {
            new int[] {0, 2},
            new int[] {2, 3},
            new int[] {2, 20},
            new int[] {2, 5, 4, 3},
            new int[] {3},
            new int[] {1},
            new int[] {0, 2},
            new int[] { }
        };
        static void Main(string[] args)
        {
        }
    }
}
