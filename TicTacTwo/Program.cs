using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    // Adjacency Matrix (19,683 x 19,683)  (512 x 512) 

    static class Program
    {
        // Adjacency List (strength, next moves = List<state>)
        static (int, List<int>)[] aList;

        // 111000000 = 448
        // 000111000 = 56
        // 000000111 = 7
        // 100100100 = 292
        // 010010010 = 146
        // 001001001 = 73
        // 100010001 = 273
        // 001010100 = 84

        static int[][] aWinStates = new int[][]
        {
            new int[] {448, 292, 273},
            new int[] {448, 146},
            new int[] {448, 73, 84},
            new int[] {56, 292},
            new int[] {56, 146, 273, 84},
            new int[] {56, 73},
            new int[] {7, 292, 84},
            new int[] {7, 146},
            new int[] {7, 73, 273}
        };

        static int[] strengths = new int[9];
        static int[] winStates = new int[8];

        static Random random = new Random();

        static void Main(string[] args)
        {
            bool[] grid = new bool[9];

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
            winStates[0] = 448; // 111000000 = 448
            winStates[1] = 56;  // 000111000 = 56
            winStates[2] = 7;   // 000000111 = 7
            winStates[3] = 292; // 100100100 = 292
            winStates[4] = 146; // 010010010 = 146
            winStates[5] = 73;  // 001001001 = 73
            winStates[6] = 273; // 100010001 = 273
            winStates[7] = 84;  // 001010100 = 84

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


                while (nWinner == 0 && ((p1 | p2) != Math.Pow(2, 9) - 1))
                {
                    if (nPlayer == 1)
                    {
                        if (nPlayers == 1)
                        {
                            int nMove = 0;
                            do
                            {
                                Console.Write("Player 1 Move (1-9): ");
                            } while (!int.TryParse(Console.ReadLine(), out nMove));

                            p1 |= 1 << (8 - nMove + 1);
                        }
                        else
                        {
                            if (!bFirst)
                            {
                                SetNextMove(ref p1, p2);
                            }
                            else
                            {
                                p1 = 1 << random.Next(0, 9);
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
                            p2 = 1 << random.Next(0, 9);
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

            for (int i = 0; i < 9; ++i)
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

                if ((i + 1) % 3 == 0)
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
            bool[] grid = new bool[9];
            int strength = 0;

            aList = new (int, List<int>)[512];

            Dictionary<int, bool> dWinStates = new Dictionary<int, bool>();

            for (i = 0; i < 8; ++i)
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

            for (i = 0; i < 8; ++i)
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
            for (i = 0; i < Math.Pow(2, 9); ++i)
            {
                // (Item1, Item2, Item3)
                (grid, nCnt, strength) = IntToGrid(i, dWinStates);

                if (nCnt <= 5)
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

                for (int g = 0; g < 9; ++g)
                {
                    bool[] neighbor = new bool[9];
                    Array.Copy(grid, neighbor, 9);

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

            for (int i = 0; i < 9; ++i)
            {
                if (g[i])
                {
                    r += (1 << (8 - i));
                }
            }

            return (r);
        }

        // convert current state c to (boolean grid, move count, strength)
        public static (bool[], int, int) IntToGrid(int c, Dictionary<int, bool> dWinStates = null)
        {
            bool[] bCell = new bool[9];
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

            for (i = 0; i < 9 && nCnt <= 5; ++i)
            {
                if (((1 << i) & c) != 0)
                {
                    if (nMaxStrength < 1000)
                    {
                        nMaxStrength += strengths[8 - i];
                    }

                    bCell[8 - i] = true;
                    ++nCnt;
                }
                else
                {
                    bCell[8 - i] = false;
                }
            }

            // if only 2 cells taken and the 2 optimal configurations
            if ((nCnt == 2) &&
                ((bCell[0] && bCell[5] && strengths[0] > 0 && strengths[5] > 0) ||
                  (bCell[3] && bCell[8] && strengths[3] > 0 && strengths[8] > 0) ||
                  (bCell[2] && bCell[3] && strengths[2] > 0 && strengths[3] > 0) ||
                  (bCell[5] && bCell[6] && strengths[5] > 0 && strengths[6] > 0) ||
                  (bCell[6] && bCell[1] && strengths[6] > 0 && strengths[1] > 0) ||
                  (bCell[7] && bCell[2] && strengths[7] > 0 && strengths[2] > 0) ||
                  (bCell[0] && bCell[7] && strengths[0] > 0 && strengths[7] > 0) ||
                  (bCell[1] && bCell[8] && strengths[1] > 0 && strengths[8] > 0) ||

                  (bCell[0] && bCell[8] && strengths[0] > 0 && strengths[8] > 0) ||
                  (bCell[2] && bCell[6] && strengths[2] > 0 && strengths[6] > 0)))
            {
                nMaxStrength += 50;

                if ((bCell[0] && bCell[8]) ||
                   (bCell[2] && bCell[6]))
                {
                    nMaxStrength += 20;
                }
            }
            else if (nMaxStrength < 1000)
            {
                for (i = 0; i < 9; ++i)
                {
                    if (bCell[i])
                    {
                        // if 2 cells are part of a winning solution
                        foreach (int winstate in aWinStates[i])
                        {
                            for (j = 0; j < 9; ++j)
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
                                    if (((1 << (8 - j)) & winstate) != 0)
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

