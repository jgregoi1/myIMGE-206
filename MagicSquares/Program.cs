using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    //This probably doesnt work, and I don't understand it enough to fix it properly
    //But I gave it my best shot and got the code as far along as I could.
    static class Program
    {
        // Adjacency List (strength, next moves = List<state>)
        static (int, List<int>)[] aList;

        //see word doc

        static int[][] aWinStates = new int[][]
        {
            new int[] {30720, 34952, 33825, 36873, 52224, 33345, 41120, 49155, 34833, 33153, 40965},
            new int[] {30720, 17476, 24582, 52224, 20560},
            new int[] {30720, 8738, 24582, 13056, 41120, 10258, 12300, 40965},
            new int[] {30720, 4369, 36873, 13056, 5160, 20560, 12300, 4488, 20490, 6168},
            new int[] {3840, 34952, 2448, 52224, 2570, 10258, 34833, 6168},
            new int[] {3840, 17476, 33825, 1632, 52224, 5160, 1285},
            new int[] {3840, 8738, 4680, 1632, 13056, 33345, 2570},
            new int[] {3840, 4369, 2448, 13056, 1285, 16770, 4488, 33153},
            new int[] {240, 34952, 2448, 204, 41120, 16770, 4488, 33153},
            new int[] {240, 17476, 4680, 1632, 204, 33345, 20560},
            new int[] {240, 8738, 33825, 1632, 51, 5160, 41120},
            new int[] {240, 4369, 2448, 51, 20560, 10258, 34833, 6168},
            new int[] {15, 34952, 4680, 36873, 204, 5160, 2570, 12300, 4488,20490},
            new int[] {15, 17476, 24582, 204, 1285, 12300, 40965},
            new int[] {15, 8738, 24582, 51, 2570, 16770, 10258, 49155, 20495},
            new int[] {15, 4369, 33825, 36873, 51, 33357, 1258, 49155, 34388, 33153, 40965}
        };
        
        static int[] strengths = new int[16];
        static int[] winStates = new int[34];

        static Random random = new Random();

        static void Main(string[] args)
        {
            bool[] grid = new bool[16];

            // p1 and p2 are the integer representations of the players game boards
            // using the lowest 9 bits to indicate their chosen spaces
            int p1 = 0;
            int p2 = 0;

            int nWinner = 0;
            int nPlayer = 1;

            // bit 8 corresponds to the top left space of the game board
            // bit 7 corresponds to the top center space
            // ...
            // bit 0 (the least significant bit) corresponds to the bottom right space
            winStates[0] = 30720; 
            winStates[1] = 3840;  
            winStates[2] = 240;   
            winStates[3] = 15; 
            winStates[4] = 34952; 
            winStates[5] = 17476;  
            winStates[6] = 8738; 
            winStates[7] = 4369;
            winStates[8] = 33825;
            winStates[9] = 4680;
            winStates[10] = 36873;
            winStates[11] = 1632;
            winStates[12] = 24582;
            winStates[13] = 2448;
            winStates[14] = 52224;
            winStates[15] = 13056;
            winStates[16] = 204;
            winStates[17] = 51;
            winStates[18] = 33345;
            winStates[19] = 5160;
            winStates[20] = 20560;
            winStates[21] = 2571;
            winStates[22] = 41120;
            winStates[23] = 1285;
            winStates[24] = 16770;
            winStates[25] = 10258;
            winStates[26] = 49155;
            winStates[27] = 12300;
            winStates[28] = 34833;
            winStates[29] = 4488;
            winStates[30] = 33153;
            winStates[31] = 20490;
            winStates[32] = 40965;
            winStates[33] = 6168;



            for (int j = 0; j < 100; ++j)
            {
                nPlayer = 1;
                nWinner = 0;

                p1 = 0;
                p2 = 0;

                bool bFirst = false;

                int nPlayers = 0;
                do
                {
                    Console.Write("How many human players (0-1): ");
                } while (!int.TryParse(Console.ReadLine(), out nPlayers));

                if (nPlayers == 1)
                {
                    Console.Write("Do you want to go first?: ");

                    if (Console.ReadLine().ToLower().StartsWith("n"))
                    {
                        nPlayer = 2;
                        bFirst = true;
                    }
                }
                else
                {
                    bFirst = true;
                }


                while (nWinner == 0 && ((p1 | p2) != Math.Pow(2, 16) - 1))
                {
                    if (nPlayer == 1)
                    {
                        if (nPlayers == 1)
                        {
                            int nMove = 0;
                            do
                            {
                                Console.Write("Player 1 Move (1-16): ");
                            } while (!int.TryParse(Console.ReadLine(), out nMove));

                            p1 |= 1 << (34 - nMove + 1);
                        }
                        else
                        {
                            if (!bFirst)
                            {
                                SetNextMove(ref p1, p2);
                            }
                            else
                            {
                                p1 = 1 << random.Next(0, 16);
                            }
                        }

                        nPlayer = 2;
                        bFirst = false;
                    }
                    else
                    {
                        if (!bFirst)
                        {
                            SetNextMove(ref p2, p1);
                        }
                        else
                        {
                            p2 = 1 << random.Next(0, 16);
                        }

                        nPlayer = 1;
                        bFirst = false;
                    }

                    PrintBoard(p1, p2);

                    nWinner = Winner(p1, p2);
                }

                switch (nWinner)
                {
                    case 0:
                        Console.WriteLine("Cat's game.  Meow!");
                        break;
                    case 1:
                        Console.WriteLine("Player 1 wins!");
                        break;
                    case 2:
                        Console.WriteLine("Player 2 wins!");
                        break;
                }

                Console.WriteLine($"--------- Game: {j} ----------------");

            }
        }

        static int Winner(int p1, int p2)
        {
            int nWinner = 0;
            int i;

            for (i = 0; i < winStates.Length; ++i)
            {
                if ((p1 & winStates[i]) == winStates[i])
                {
                    nWinner = 1;
                }
                else if ((p2 & winStates[i]) == winStates[i])
                {
                    nWinner = 2;
                }
            }

            return (nWinner);
        }


        static void PrintBoard(int p1, int p2)
        {
            bool[] p1G;
            bool[] p2G;
            int nCnt;
            int strength;

            (p1G, nCnt, strength) = IntToGrid(p1);
            (p2G, nCnt, strength) = IntToGrid(p2);

            for (int i = 0; i < 16; ++i)
            {
                if (p1G[i])
                {
                    Console.Write(" X ");
                }
                else if (p2G[i])
                {
                    Console.Write(" O ");
                }
                else
                {
                    Console.Write("   ");
                }

                if ((i + 1) % 4 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine("-------------------------");
        }


        static void SetNextMove(ref int a, int b)
        {
            int aMove = 0;
            int bMove = 0;
            int aStrength = 0;
            int bStrength = 0;

            CalculateGraph(a);
            // get best move for player b
            (bMove, bStrength) = GetNextMove(b, a);

            CalculateGraph(b);
            // get best move for player a
            (aMove, aStrength) = GetNextMove(a, b);

            // if the first move for a and b already moved
            if (a == 0 && b != 0)
            {
                // counter attack b
                bStrength = aStrength + 1;
            }

            // if b has a better move, then block
            if (bStrength > aStrength)
            {
                a |= (bMove ^ b);
            }
            else
            {
                a = aMove;
            }
        }

        // return the move and the strength of the move
        static (int, int) GetNextMove(int a, int b)
        {
            int nStrength = 0;
            int moveBit = 0;
            int nMove = 0;

            foreach (int n in aList[a].Item2)
            {
                // fetch only the new bit in the next move
                moveBit = (n ^ a);

                // ensure that spot is available
                if ((moveBit & b) == 0)
                {
                    nStrength = aList[n].Item1;
                    nMove = n;
                    break;
                }
            }

            return (nMove, nStrength);
        }


        private static void CalculateGraph(int a)
        {
            int i;
            int j;
            int nCnt;
            bool[] grid = new bool[16];
            int strength = 0;

            aList = new (int, List<int>)[65536];

            Dictionary<int, bool> dWinStates = new Dictionary<int, bool>();

            for (i = 0; i < 34; ++i)
            {
                if (((winStates[i] ^ a) & winStates[i]) == winStates[i])
                {
                    dWinStates[winStates[i]] = true;
                }
                else
                {
                    dWinStates[winStates[i]] = false;
                }
            }

            for (i = 0; i < 16; ++i)
            {
                strengths[i] = 0;

                for (j = 0; j < aWinStates[i].Length; ++j)
                {
                    if (dWinStates[aWinStates[i][j]])
                    {
                        ++strengths[i];
                    }
                }
            }

            // populate all possible board states for 1 player
            // there are a theoretical 2^9 possible states
            // but a smaller practical limit
            for (i = 0; i < Math.Pow(2, 16); ++i)
            {
                // (Item1, Item2, Item3)
                (grid, nCnt, strength) = IntToGrid(i, dWinStates);

                if (nCnt <= 5) //<-- figure out what this does and adjust it.
                {
                    // aList[0].Item1 = strength
                    // aList[0].Item2 = List<int> (weighted list of neighbors)
                    aList[i] = (strength, new List<int>());
                }
                else
                {
                    aList[i] = (0, null);
                }
            }

            for (i = 0; i < aList.Length; ++i)
            {
                if (aList[i].Item1 == 0)
                {
                    continue;
                }

                (grid, nCnt, strength) = IntToGrid(i);

                for (int g = 0; g < 16; ++g)
                {
                    bool[] neighbor = new bool[16];
                    Array.Copy(grid, neighbor, 16);

                    if (!neighbor[g])
                    {
                        neighbor[g] = true;
                        aList[i].Item2.Add(GridToInt(neighbor));
                    }
                }

                // sort the neighbors by their strengths in descending order
                aList[i].Item2.Sort(
                    // the following 4 expressions are equivalent
                    delegate (int m, int n)
                    {
                        return aList[n].Item1.CompareTo(aList[m].Item1);
                    });

                //(int m, int n) =>
                //{
                //    return aList[n].Item1.CompareTo(aList[m].Item1);
                //});

                //(m,n) =>
                //{
                //    return aList[n].Item1.CompareTo(aList[m].Item1);
                //});

                // (m, n) => aList[n].Item1.CompareTo(aList[m].Item1));
            }
        }

        public static int GridToInt(bool[] g)
        {
            int r = 0;

            for (int i = 0; i < 16; ++i)
            {
                if (g[i])
                {
                    r += (1 << (34 - i));
                }
            }

            return (r);
        }

        // convert current state c to (boolean grid, move count, strength)
        public static (bool[], int, int) IntToGrid(int c, Dictionary<int, bool> dWinStates = null)
        {
            bool[] bCell = new bool[16];
            int nCnt = 0;
            int nMaxStrength = 1;
            int i = 0;
            int j = 0;

            // check for a winning move
            for (i = 0; i < winStates.Length; ++i)
            {
                if ((dWinStates != null) && !dWinStates[winStates[i]])
                {
                    continue;
                }

                // winning move in this state
                if ((c & winStates[i]) == winStates[i])
                {
                    // we want this move!
                    nMaxStrength = 1000;
                }
            }

            for (i = 0; i < 16 && nCnt <= 5; ++i)
            {
                if (((1 << i) & c) != 0)
                {
                    if (nMaxStrength < 1000)
                    {
                        nMaxStrength += strengths[15 - i];
                    }

                    bCell[15 - i] = true;
                    ++nCnt;
                }
                else
                {
                    bCell[15 - i] = false;
                }
            }

            // if only 2 cells taken and the 2 optimal configurations
            //if ((nCnt == 2) &&
            //    ((bCell[0] && bCell[5] && strengths[0] > 0 && strengths[5] > 0) ||
            //      (bCell[3] && bCell[8] && strengths[3] > 0 && strengths[8] > 0) ||
            //      (bCell[2] && bCell[3] && strengths[2] > 0 && strengths[3] > 0) ||
            //      (bCell[5] && bCell[6] && strengths[5] > 0 && strengths[6] > 0) ||
            //      (bCell[6] && bCell[1] && strengths[6] > 0 && strengths[1] > 0) ||
            //      (bCell[7] && bCell[2] && strengths[7] > 0 && strengths[2] > 0) ||
            //      (bCell[0] && bCell[7] && strengths[0] > 0 && strengths[7] > 0) ||
            //      (bCell[1] && bCell[8] && strengths[1] > 0 && strengths[8] > 0) ||
            //
            //      (bCell[0] && bCell[8] && strengths[0] > 0 && strengths[8] > 0) ||
            //      (bCell[2] && bCell[6] && strengths[2] > 0 && strengths[6] > 0)))
            //{
            //    nMaxStrength += 50;
            //
            //    if ((bCell[0] && bCell[8]) ||
            //       (bCell[2] && bCell[6]))
            //    {
            //        nMaxStrength += 20;
            //    }
            //}
            if (nMaxStrength < 1000)
            {
                for (i = 0; i < 16; ++i)
                {
                    if (bCell[i])
                    {
                        // if 2 cells are part of a winning solution
                        foreach (int winstate in aWinStates[i])
                        {
                            for (j = 0; j < 16; ++j)
                            {
                                if (j == i)
                                {
                                    continue;
                                }

                                if ((dWinStates != null) && !dWinStates[winstate])
                                {
                                    continue;
                                }

                                if (bCell[j])
                                {
                                    if (((1 << (34 - j)) & winstate) != 0)
                                    {
                                        nMaxStrength += 30;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return (bCell, nCnt, nMaxStrength);
        }
    }
}

