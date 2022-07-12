/* 
 * MIT License
 * 
 * Copyright (c) 2022 Samuel Mediani
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Connect4
{
    class Game
    {
        int counter;
        int r, c; // rows and columns
        bool player;
        int draw = 0;

        int[,] m;

        public Game()
        {
            counter = 0;
            r = 6;
            c = 7;
            m = new int[r, c];
            player = true; // true = player 1

            // matrix inizialization
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    m[i, j] = 0;

        }

        public int count()
        {
            counter++;
            return counter;
        }
    
        public int checkValidSlot(int c) // control function for disk position and matrix filling (take current column as parameter)
        {
 	        for (int i=0; i<r; i++) // loop through all the rows from the bottom
            {
                if (m[i, c] == 0) // an empty slot is found
                {
                    if (player)
                        m[i, c] = 1;
                    else
                        m[i, c] = 2;
                    player = !player; // player switching

                    return i;
                }
            }
            return -1;
        }

        public int victory() // check winning connection
        {
            draw++;

            // ROWS
            int k = 0, // rows
            countCols4 = 0; // count until the 4th column of the board
                            // (it is not necessary to go up to the seventh for the checks
                            // since it would go outside the matrix/board)

            while (k < 6)
            {
                // horizontal check for player 1
                for (int c = 0; c < 4; c++)
                    if (m[k, c] == 1 && m[k, c + 1] == 1 && m[k, c + 2] == 1 && m[k, c + 3] == 1)
                        return 1;

                // horizontal check for player 2
                for (int c = 0; c < 4; c++)
                    if (m[k, c] == 2 && m[k, c + 1] == 2 && m[k, c + 2] == 2 && m[k, c + 3] == 2)
                        return 2;

                countCols4++;

                if (countCols4 % 4 == 0)
                    k++;
            }

            // COLUMNS
            k = 0; // reset k
            int countRows3 = 0;
            while (k < 7)
            {
                // vertical check for player 1
                for (int c = 0; c < 4; c++)
                    if (m[c, k] == 1 && m[c + 1, k] == 1 && m[c + 2, k] == 1 && m[c + 3, k] == 1)
                        return 1;

                // vertical check for player 2
                for (int c = 0; c < 4; c++)
                    if (m[c, k] == 2 && m[c + 1, k] == 2 && m[c + 2, k] == 2 && m[c + 3, k] == 2)
                        return 2;

                countRows3++;

                if (countRows3 % 4 == 0)
                    k++;
            }

            #region Manual victory check for rows and columns (not recommended)

            /*if    (m[0, 0] == 1 && m[0, 1] == 1 && m[0, 2] == 1 && m[0, 3] == 1) //1 (player 1)
                return 1;
            else if (m[0, 1] == 1 && m[0, 2] == 1 && m[0, 3] == 1 && m[0, 4] == 1)
                return 1;
            else if (m[0, 2] == 1 && m[0, 3] == 1 && m[0, 4] == 1 && m[0, 5] == 1)
                return 1;
            else if (m[0, 3] == 1 && m[0, 4] == 1 && m[0, 5] == 1 && m[0, 6] == 1)
                return 1;
            else if (m[1, 0] == 1 && m[1, 1] == 1 && m[1, 2] == 1 && m[1, 3] == 1) //2
                return 1;
            else if (m[1, 1] == 1 && m[1, 2] == 1 && m[1, 3] == 1 && m[1, 4] == 1)
                return 1;
            else if (m[1, 2] == 1 && m[1, 3] == 1 && m[1, 4] == 1 && m[1, 5] == 1)
                return 1;
            else if (m[1, 3] == 1 && m[1, 4] == 1 && m[1, 5] == 1 && m[1, 6] == 1)
                return 1;
            else if (m[2, 0] == 1 && m[2, 1] == 1 && m[2, 2] == 1 && m[2, 3] == 1) //3
                return 1;
            else if (m[2, 1] == 1 && m[2, 2] == 1 && m[2, 3] == 1 && m[2, 4] == 1)
                return 1;
            else if (m[2, 2] == 1 && m[2, 3] == 1 && m[2, 4] == 1 && m[2, 5] == 1)
                return 1;
            else if (m[2, 3] == 1 && m[2, 4] == 1 && m[2, 5] == 1 && m[2, 6] == 1)
                return 1;
            else if (m[3, 0] == 1 && m[3, 1] == 1 && m[3, 2] == 1 && m[3, 3] == 1) //4
                return 1;
            else if (m[3, 1] == 1 && m[3, 2] == 1 && m[3, 3] == 1 && m[3, 4] == 1)
                return 1;
            else if (m[3, 2] == 1 && m[3, 3] == 1 && m[3, 4] == 1 && m[3, 5] == 1)
                return 1;
            else if (m[3, 3] == 1 && m[3, 4] == 1 && m[3, 5] == 1 && m[3, 6] == 1)
                return 1;
            else if (m[4, 0] == 1 && m[4, 1] == 1 && m[4, 2] == 1 && m[4, 3] == 1) //5
                return 1;
            else if (m[4, 1] == 1 && m[4, 2] == 1 && m[4, 3] == 1 && m[4, 4] == 1)
                return 1;
            else if (m[4, 2] == 1 && m[4, 3] == 1 && m[4, 4] == 1 && m[4, 5] == 1)
                return 1;
            else if (m[4, 3] == 1 && m[4, 4] == 1 && m[4, 5] == 1 && m[4, 6] == 1)
                return 1;
            else if (m[5, 0] == 1 && m[5, 1] == 1 && m[5, 2] == 1 && m[5, 3] == 1) //6
                return 1;
            else if (m[5, 1] == 1 && m[5, 2] == 1 && m[5, 3] == 1 && m[5, 4] == 1)
                return 1;
            else if (m[5, 2] == 1 && m[5, 3] == 1 && m[5, 4] == 1 && m[5, 5] == 1)
                return 1;
            else if (m[5, 3] == 1 && m[5, 4] == 1 && m[5, 5] == 1 && m[5, 6] == 1)
                return 1;                                                          //end rows check
            else
            if (m[0, 0] == 1 && m[1, 0] == 1 && m[2, 0] == 1 && m[3, 0] == 1) //1
                return 1;
            else if (m[1, 0] == 1 && m[2, 0] == 1 && m[3, 0] == 1 && m[4, 0] == 1)
                return 1;
            else if (m[2, 0] == 1 && m[3, 0] == 1 && m[4, 0] == 1 && m[5, 0] == 1)
                return 1;
            else if (m[0, 1] == 1 && m[1, 1] == 1 && m[2, 1] == 1 && m[3, 1] == 1) //2
                return 1;
            else if (m[1, 1] == 1 && m[2, 1] == 1 && m[3, 1] == 1 && m[4, 1] == 1)
                return 1;
            else if (m[2, 1] == 1 && m[3, 1] == 1 && m[4, 1] == 1 && m[5, 1] == 1)
                return 1;
            else if (m[0, 2] == 1 && m[1, 2] == 1 && m[2, 2] == 1 && m[3, 2] == 1) //3
                return 1;
            else if (m[1, 2] == 1 && m[2, 2] == 1 && m[3, 2] == 1 && m[4, 2] == 1)
                return 1;
            else if (m[2, 2] == 1 && m[3, 2] == 1 && m[4, 2] == 1 && m[5, 2] == 1)
                return 1;
            else if (m[0, 3] == 1 && m[1, 3] == 1 && m[2, 3] == 1 && m[3, 3] == 1) //4
                return 1;
            else if (m[1, 3] == 1 && m[2, 3] == 1 && m[3, 3] == 1 && m[4, 3] == 1)
                return 1;
            else if (m[2, 3] == 1 && m[3, 3] == 1 && m[4, 3] == 1 && m[5, 3] == 1)
                return 1;
            else if (m[0, 4] == 1 && m[1, 4] == 1 && m[2, 4] == 1 && m[3, 4] == 1) //5
                return 1;
            else if (m[1, 4] == 1 && m[2, 4] == 1 && m[3, 4] == 1 && m[4, 4] == 1)
                return 1;
            else if (m[2, 4] == 1 && m[3, 4] == 1 && m[4, 4] == 1 && m[5, 4] == 1)
                return 1;
            else if (m[0, 5] == 1 && m[1, 5] == 1 && m[2, 5] == 1 && m[3, 5] == 1) //6
                return 1;
            else if (m[1, 5] == 1 && m[2, 5] == 1 && m[3, 5] == 1 && m[4, 5] == 1)
                return 1;
            else if (m[2, 5] == 1 && m[3, 5] == 1 && m[4, 5] == 1 && m[5, 5] == 1)
                return 1;
            else if (m[0, 6] == 1 && m[1, 6] == 1 && m[2, 6] == 1 && m[3, 6] == 1) //7
                return 1;
            else if (m[1, 6] == 1 && m[2, 6] == 1 && m[3, 6] == 1 && m[4, 6] == 1)
                return 1;
            else if (m[2, 6] == 1 && m[3, 6] == 1 && m[4, 6] == 1 && m[5, 6] == 1)
                return 1;                                                          //end columns check
            else if (m[0, 0] == 2 && m[0, 1] == 2 && m[0, 2] == 2 && m[0, 3] == 2) //1 (player 2)
                return 2;
            else if (m[0, 1] == 2 && m[0, 2] == 2 && m[0, 3] == 2 && m[0, 4] == 2)
                return 2;
            else if (m[0, 2] == 2 && m[0, 3] == 2 && m[0, 4] == 2 && m[0, 5] == 2)
                return 2;
            else if (m[0, 3] == 2 && m[0, 4] == 2 && m[0, 5] == 2 && m[0, 6] == 2)
                return 2;
            else if (m[1, 0] == 2 && m[1, 1] == 2 && m[1, 2] == 2 && m[1, 3] == 2) //2
                return 2;
            else if (m[1, 1] == 2 && m[1, 2] == 2 && m[1, 3] == 2 && m[1, 4] == 2)
                return 2;
            else if (m[1, 2] == 2 && m[1, 3] == 2 && m[1, 4] == 2 && m[1, 5] == 2)
                return 2;
            else if (m[1, 3] == 2 && m[1, 4] == 2 && m[1, 5] == 2 && m[1, 6] == 2)
                return 2;
            else if (m[2, 0] == 2 && m[2, 1] == 2 && m[2, 2] == 2 && m[2, 3] == 2) //3
                return 2;
            else if (m[2, 1] == 2 && m[2, 2] == 2 && m[2, 3] == 2 && m[2, 4] == 2)
                return 2;
            else if (m[2, 2] == 2 && m[2, 3] == 2 && m[2, 4] == 2 && m[2, 5] == 2)
                return 2;
            else if (m[2, 3] == 2 && m[2, 4] == 2 && m[2, 5] == 2 && m[2, 6] == 2)
                return 2;
            else if (m[3, 0] == 2 && m[3, 1] == 2 && m[3, 2] == 2 && m[3, 3] == 2) //4
                return 2;
            else if (m[3, 1] == 2 && m[3, 2] == 2 && m[3, 3] == 2 && m[3, 4] == 2)
                return 2;
            else if (m[3, 2] == 2 && m[3, 3] == 2 && m[3, 4] == 2 && m[3, 5] == 2)
                return 2;
            else if (m[3, 3] == 2 && m[3, 4] == 2 && m[3, 5] == 2 && m[3, 6] == 2)
                return 2;
            else if (m[4, 0] == 2 && m[4, 1] == 2 && m[4, 2] == 2 && m[4, 3] == 2) //5
                return 2;
            else if (m[4, 1] == 2 && m[4, 2] == 2 && m[4, 3] == 2 && m[4, 4] == 2)
                return 2;
            else if (m[4, 2] == 2 && m[4, 3] == 2 && m[4, 4] == 2 && m[4, 5] == 2)
                return 2;
            else if (m[4, 3] == 2 && m[4, 4] == 2 && m[4, 5] == 2 && m[4, 6] == 2)
                return 2;
            else if (m[5, 0] == 2 && m[5, 1] == 2 && m[5, 2] == 2 && m[5, 3] == 2) //6
                return 2;
            else if (m[5, 1] == 2 && m[5, 2] == 2 && m[5, 3] == 2 && m[5, 4] == 2)
                return 2;
            else if (m[5, 2] == 2 && m[5, 3] == 2 && m[5, 4] == 2 && m[5, 5] == 2)
                return 2;
            else if (m[5, 3] == 2 && m[5, 4] == 2 && m[5, 5] == 2 && m[5, 6] == 2)
                return 2;                                                          //end rows check
            else if (m[0, 0] == 2 && m[1, 0] == 2 && m[2, 0] == 2 && m[3, 0] == 2) //1
                return 2;
            else if (m[1, 0] == 2 && m[2, 0] == 2 && m[3, 0] == 2 && m[4, 0] == 2)
                return 2;
            else if (m[2, 0] == 2 && m[3, 0] == 2 && m[4, 0] == 2 && m[5, 0] == 2)
                return 2;
            else if (m[0, 1] == 2 && m[1, 1] == 2 && m[2, 1] == 2 && m[3, 1] == 2) //2
                return 2;
            else if (m[1, 1] == 2 && m[2, 1] == 2 && m[3, 1] == 2 && m[4, 1] == 2)
                return 2;
            else if (m[2, 1] == 2 && m[3, 1] == 2 && m[4, 1] == 2 && m[5, 1] == 2)
                return 2;
            else if (m[0, 2] == 2 && m[1, 2] == 2 && m[2, 2] == 2 && m[3, 2] == 2) //3
                return 2;
            else if (m[1, 2] == 2 && m[2, 2] == 2 && m[3, 2] == 2 && m[4, 2] == 2)
                return 2;
            else if (m[2, 2] == 2 && m[3, 2] == 2 && m[4, 2] == 2 && m[5, 2] == 2)
                return 2;
            else if (m[0, 3] == 2 && m[1, 3] == 2 && m[2, 3] == 2 && m[3, 3] == 2) //4
                return 2;
            else if (m[1, 3] == 2 && m[2, 3] == 2 && m[3, 3] == 2 && m[4, 3] == 2)
                return 2;
            else if (m[2, 3] == 2 && m[3, 3] == 2 && m[4, 3] == 2 && m[5, 3] == 2)
                return 2;
            else if (m[0, 4] == 2 && m[1, 4] == 2 && m[2, 4] == 2 && m[3, 4] == 2) //5
                return 2;
            else if (m[1, 4] == 2 && m[2, 4] == 2 && m[3, 4] == 2 && m[4, 4] == 2)
                return 2;
            else if (m[2, 4] == 2 && m[3, 4] == 2 && m[4, 4] == 2 && m[5, 4] == 2)
                return 2;
            else if (m[0, 5] == 2 && m[1, 5] == 2 && m[2, 5] == 2 && m[3, 5] == 2) //6
                return 2;
            else if (m[1, 5] == 2 && m[2, 5] == 2 && m[3, 5] == 2 && m[4, 5] == 2)
                return 2;
            else if (m[2, 5] == 2 && m[3, 5] == 2 && m[4, 5] == 2 && m[5, 5] == 2)
                return 2;
            else if (m[0, 6] == 2 && m[1, 6] == 2 && m[2, 6] == 2 && m[3, 6] == 2) //7
                return 2;
            else if (m[1, 6] == 2 && m[2, 6] == 2 && m[3, 6] == 2 && m[4, 6] == 2)
                return 2;
            else if (m[2, 6] == 2 && m[3, 6] == 2 && m[4, 6] == 2 && m[5, 6] == 2)
                return 2;                                                          //end columns check  */
            /*else*/
            #endregion

            if (m[2, 0] == 1 && m[3, 1] == 1 && m[4, 2] == 1 && m[5, 3] == 1) //start player 1 diagonals
                return 1;
            else if (m[1, 0] == 1 && m[2, 1] == 1 && m[3, 2] == 1 && m[4, 3] == 1)
                return 1;
            else if (m[0, 0] == 1 && m[1, 1] == 1 && m[2, 2] == 1 && m[3, 3] == 1)
                return 1;
            else if (m[2, 1] == 1 && m[3, 2] == 1 && m[4, 3] == 1 && m[5, 4] == 1)
                return 1;
            else if (m[2, 2] == 1 && m[3, 3] == 1 && m[4, 4] == 1 && m[5, 5] == 1)
                return 1;
            else if (m[1, 1] == 1 && m[2, 2] == 1 && m[3, 3] == 1 && m[4, 4] == 1)
                return 1;
            else if (m[0, 1] == 1 && m[1, 2] == 1 && m[2, 3] == 1 && m[3, 4] == 1)
                return 1;
            else if (m[1, 2] == 1 && m[2, 3] == 1 && m[3, 4] == 1 && m[4, 5] == 1)
                return 1;
            else if (m[2, 3] == 1 && m[3, 4] == 1 && m[4, 5] == 1 && m[5, 6] == 1)
                return 1;
            else if (m[0, 2] == 1 && m[1, 3] == 1 && m[2, 4] == 1 && m[3, 5] == 1)
                return 1;
            else if (m[1, 3] == 1 && m[2, 4] == 1 && m[3, 5] == 1 && m[4, 6] == 1)
                return 1;
            else if (m[0, 3] == 1 && m[1, 4] == 1 && m[2, 5] == 1 && m[3, 6] == 1)
                return 1;
            else if (m[0, 3] == 1 && m[1, 2] == 1 && m[2, 1] == 1 && m[3, 0] == 1)
                return 1;
            else if (m[0, 4] == 1 && m[1, 3] == 1 && m[2, 2] == 1 && m[3, 1] == 1)
                return 1;
            else if (m[1, 3] == 1 && m[2, 2] == 1 && m[3, 1] == 1 && m[4, 0] == 1)
                return 1;
            else if (m[0, 5] == 1 && m[1, 4] == 1 && m[2, 3] == 1 && m[3, 2] == 1)
                return 1;
            else if (m[1, 4] == 1 && m[2, 3] == 1 && m[3, 2] == 1 && m[4, 1] == 1)
                return 1;
            else if (m[2, 3] == 1 && m[3, 2] == 1 && m[4, 1] == 1 && m[5, 0] == 1)
                return 1;
            else if (m[0, 6] == 1 && m[1, 5] == 1 && m[2, 4] == 1 && m[3, 3] == 1)
                return 1;
            else if (m[1, 5] == 1 && m[2, 4] == 1 && m[3, 3] == 1 && m[4, 2] == 1)
                return 1;
            else if (m[2, 4] == 1 && m[3, 3] == 1 && m[4, 2] == 1 && m[5, 1] == 1)
                return 1;
            else if (m[1, 6] == 1 && m[2, 5] == 1 && m[3, 4] == 1 && m[4, 3] == 1)
                return 1;
            else if (m[2, 5] == 1 && m[3, 4] == 1 && m[4, 3] == 1 && m[5, 2] == 1)
                return 1;
            else if (m[2, 6] == 1 && m[3, 5] == 1 && m[4, 4] == 1 && m[5, 3] == 1) //end player 1 diagonals
                return 1;
            else if (m[2, 0] == 2 && m[3, 1] == 2 && m[4, 2] == 2 && m[5, 3] == 2) //start player 2 diagonals
                return 2;
            else if (m[1, 0] == 2 && m[2, 1] == 2 && m[3, 2] == 2 && m[4, 3] == 2)
                return 2;
            else if (m[0, 0] == 2 && m[1, 1] == 2 && m[2, 2] == 2 && m[3, 3] == 2)
                return 2;
            else if (m[2, 1] == 2 && m[3, 2] == 2 && m[4, 3] == 2 && m[5, 4] == 2)
                return 2;
            else if (m[2, 2] == 2 && m[3, 3] == 2 && m[4, 4] == 2 && m[5, 5] == 2)
                return 2;
            else if (m[1, 1] == 2 && m[2, 2] == 2 && m[3, 3] == 2 && m[4, 4] == 2)
                return 2;
            else if (m[0, 1] == 2 && m[1, 2] == 2 && m[2, 3] == 2 && m[3, 4] == 2)
                return 2;
            else if (m[1, 2] == 2 && m[2, 3] == 2 && m[3, 4] == 2 && m[4, 5] == 2)
                return 2;
            else if (m[2, 3] == 2 && m[3, 4] == 2 && m[4, 5] == 2 && m[5, 6] == 2)
                return 2;
            else if (m[0, 2] == 2 && m[1, 3] == 2 && m[2, 4] == 2 && m[3, 5] == 2)
                return 2;
            else if (m[1, 3] == 2 && m[2, 4] == 2 && m[3, 5] == 2 && m[4, 6] == 2)
                return 2;
            else if (m[0, 3] == 2 && m[1, 4] == 2 && m[2, 5] == 2 && m[3, 6] == 2)
                return 2;
            else if (m[0, 3] == 2 && m[1, 2] == 2 && m[2, 1] == 2 && m[3, 0] == 2)
                return 2;
            else if (m[0, 4] == 2 && m[1, 3] == 2 && m[2, 2] == 2 && m[3, 1] == 2)
                return 2;
            else if (m[1, 3] == 2 && m[2, 2] == 2 && m[3, 1] == 2 && m[4, 0] == 2)
                return 2;
            else if (m[0, 5] == 2 && m[1, 4] == 2 && m[2, 3] == 2 && m[3, 2] == 2)
                return 2;
            else if (m[1, 4] == 2 && m[2, 3] == 2 && m[3, 2] == 2 && m[4, 1] == 2)
                return 2;
            else if (m[2, 3] == 2 && m[3, 2] == 2 && m[4, 1] == 2 && m[5, 0] == 2)
                return 2;
            else if (m[0, 6] == 2 && m[1, 5] == 2 && m[2, 4] == 2 && m[3, 3] == 2)
                return 2;
            else if (m[1, 5] == 2 && m[2, 4] == 2 && m[3, 3] == 2 && m[4, 2] == 2)
                return 2;
            else if (m[2, 4] == 2 && m[3, 3] == 2 && m[4, 2] == 2 && m[5, 1] == 2)
                return 2;
            else if (m[1, 6] == 2 && m[2, 5] == 2 && m[3, 4] == 2 && m[4, 3] == 2)
                return 2;
            else if (m[2, 5] == 2 && m[3, 4] == 2 && m[4, 3] == 2 && m[5, 2] == 2)
                return 2;
            else if (m[2, 6] == 2 && m[3, 5] == 2 && m[4, 4] == 2 && m[5, 3] == 2) //end player 2 diagonals
                return 2;
            else if (draw == 42) // reached max possible moves (7*6)
                return 3;
            else
                return 0; // no winner found

        }
    }
}
