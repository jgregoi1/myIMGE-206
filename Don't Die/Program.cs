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
        west,
        none
    }
    class Program
    {
        Edirection north = Edirection.north;
        Edirection south = Edirection.south;
        Edirection east = Edirection.east;
        Edirection west = Edirection.west;
        static int[,] mCosts = new int[,]
        {
            {0, 2, -1, -1, -1, -1, -1, -1},  //a
            {-1, -1, 2, 3, -1, -1, -1, -1},   //b
            {-1, 2, -1, -1, -1, -1, -1, 20}, //c
            {-1, 3, 5, -1, 2, 4, -1, -1},    //d
            {-1, -1, -1, -1, -1, 3, -1, -1}, //e
            {-1, -1, -1, -1, -1, -1, 1, -1}, //f
            {-1, -1, -1, -1, 0 , -1, -1, 2},  //g
            {-1, -1, -1, -1, -1, -1, -1, -1} //h
        };
                

        static Edirection[,] mDirection = new Edirection[,]
        {
            {Edirection.none, Edirection.south, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none}, //a
            {Edirection.none, Edirection.none, Edirection.none, Edirection.south, Edirection.east, Edirection.none,Edirection.none, Edirection.none}, //b
            {Edirection.none, Edirection.north, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.south}, //c
            {Edirection.none, Edirection.west, Edirection.south, Edirection.none, Edirection.north, Edirection.east, Edirection.none, Edirection.none}, //d
            {Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.south, Edirection.none,Edirection.none}, //e
            {Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.east, Edirection.none}, //f
            {Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.north, Edirection.none, Edirection.none, Edirection.south}, //g
            {Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none}  //h
        };

        static int[][] lCost = new int[][]
        {
            new int[] {0, 2, -1, -1, -1, -1, -1, -1},
            new int[] {-1, -1, 2, 3, -1, -1, -1, -1},
            new int[] {-1, 2, -1, -1, -1, -1, -1, 20},
            new int[] {-1, 3, 5, -1, 2, 4, -1, -1},
            new int[] {-1, -1, -1, -1, -1, 3, -1, -1},
            new int[] {-1, -1, -1, -1, -1, -1, 1, -1},
            new int[] {-1, -1, -1, -1, 0, -1, -1, 2},
            new int[] {-1, -1, -1, -1, -1, -1, -1, -1}
        };

        static Edirection[][] lDirection = new Edirection[][]
        {
            new Edirection[] {Edirection.none, Edirection.south, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none},
            new Edirection[] {Edirection.none, Edirection.none, Edirection.none, Edirection.south, Edirection.east, Edirection.none,Edirection.none, Edirection.none}, 
            new Edirection[] {Edirection.none, Edirection.north, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.south}, 
            new Edirection[] {Edirection.none, Edirection.west, Edirection.south, Edirection.none, Edirection.north, Edirection.east, Edirection.none, Edirection.none},
            new Edirection[] {Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.south, Edirection.none,Edirection.none},
            new Edirection[] {Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.east, Edirection.none},
            new Edirection[] {Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.north, Edirection.none, Edirection.none, Edirection.south},
            new Edirection[] {Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none, Edirection.none}  
        };
        static void Main(string[] args)
        {
        }
    }
}
