using MELI.Domain.Humans;
using System;
using System.Collections.Generic;
using System.Text;

namespace MELI.Domain.ValueObjects
{
    /// <summary>
    /// Class especialized for inspect and dected mutants
    /// </summary>
    public class HumanInspector
    {
        /// <summary>
        /// Public method for know if a human is mutant
        /// only with his/her DNA (as string)
        /// </summary>
        /// <param name="human">Human for evaluate</param>
        /// <returns></returns>
        public static bool IsMutant(Human human)
        {
            var dna = human.DnaArray;
            ///CAMBIAR!
            int size = dna[0].Length;
            char[,] arrayToEvaluate = new char[size, size];
            int i = 0;
            int j = 0;
            foreach (var item in dna)
            {
                var charArray = item.ToCharArray();
                foreach (var ch in charArray)
                {
                    if (ch != ',')
                    {
                        arrayToEvaluate[i, j] = ch;

                    }
                    j++;
                }
                j = 0;
                i++;
            }
            //horizaontal
            int countIsMutant = 0;
            #region OLD CODE
            var h = ReadHorizontal(ref arrayToEvaluate, size);
            if (h > 0)
                countIsMutant += h;
            //If there are 2 horizontal pattern is Mutant and doesn't need to follow trying to determinated
            if (countIsMutant < 2)
            {
                //vertical
                var v = ReadVertical(ref arrayToEvaluate, size);
                if (v > 0)
                    countIsMutant += v;
            }
            // if we have 2 counts is already  mutant and doesn't need to follow trying to determinated
            if (countIsMutant < 2)
            {
                //oblicuo
                var o = ReadObliquos(ref arrayToEvaluate, size);
                if (o > 0)
                    countIsMutant += o;

            }
            #endregion



            ///CAMBIAR!

            if (countIsMutant > 1)
            {
                human.IsMutant = true;

            }
            else
            {
                human.IsMutant = false;

            }



            //CALCULATE
            return (bool)human.IsMutant;
        }
        /// <summary>
        /// Method for read OBLIQUOSLY in array of DNA
        /// </summary>
        /// <param name="arrayToEvaluate">Array to evaluate</param>
        /// <param name="size">size of array</param>
        /// <returns>mutant pattern detected</returns>
        private static int ReadObliquos(ref char[,] arrayToEvaluate, int size)
        {
            int IsMutant = 0;
            int countA = 0;
            int countT = 0;
            int countC = 0;
            int countG = 0;
            //Cover bottom half
            for (int x = 0; x < size; x++)
            {
                countA = 0;
                countT = 0;
                countC = 0;
                countG = 0;
                int z = x;
                for (int y = 0; y < size; y++)
                {

                    if (x < size && y < size)
                    {
                        switch (arrayToEvaluate[x, y])
                        {
                            case 'A':
                                countA++;
                                countT = 0;
                                countC = 0;
                                countG = 0;
                                break;
                            case 'T':
                                countT++;
                                countA = 0;
                                countC = 0;
                                countG = 0;
                                break;
                            case 'C':
                                countC++;
                                countA = 0;
                                countT = 0;
                                countG = 0;
                                break;
                            case 'G':
                                countG++;
                                countA = 0;
                                countT = 0;
                                countC = 0;
                                break;
                            default:
                                break;
                        }
                        ///Reviso si alguno esta OK bien sino reinicio valores
                        if (countA >= 4 || countT > 4 || countC >= 4 || countG >= 4)
                        {
                            IsMutant++;
                        }

                    }
                    x++;
                }
                x = z;//return value to its befero value
            }

            //Cover top half -- y==1 becaus y=0 its just covered
            for (int y = 1; y < size; y++)
            {
                countA = 0;
                countT = 0;
                countC = 0;
                countG = 0;
                int z = y;
                for (int x = 0; x < size; x++)
                {

                    if (x < size && y < size)
                    {
                        switch (arrayToEvaluate[x, y])
                        {
                            case 'A':
                                countA++;
                                countT = 0;
                                countC = 0;
                                countG = 0;
                                break;
                            case 'T':
                                countT++;
                                countA = 0;
                                countC = 0;
                                countG = 0;
                                break;
                            case 'C':
                                countC++;
                                countA = 0;
                                countT = 0;
                                countG = 0;
                                break;
                            case 'G':
                                countG++;
                                countA = 0;
                                countT = 0;
                                countC = 0;
                                break;
                            default:
                                break;
                        }
                        ///Reviso si alguno esta OK bien sino reinicio valores
                        if (countA >= 4 || countT > 4 || countC >= 4 || countG >= 4)
                        {
                            IsMutant++;
                        }

                    }
                    y++;
                }
                y = z;//return value to its befero value
            }
            //no encontrado
            return IsMutant;
        }
        /// <summary>
        /// Method for read VERTICALY in array of DNA
        /// </summary>
        /// <param name="arrayToEvaluate">Array to evaluate</param>
        /// <param name="size">size of array</param>
        /// <returns>mutant pattern detected</returns>
        private static int ReadVertical(ref char[,] arrayToEvaluate, int size)
        {
            int IsMutant = 0;
            int countA = 0;
            int countT = 0;
            int countC = 0;
            int countG = 0;
            for (int x = 0; x < size; x++)
            {
                countA = 0;
                countT = 0;
                countC = 0;
                countG = 0;
                for (int y = 0; y < size; y++)
                {
                    switch (arrayToEvaluate[x, y])
                    {
                        case 'A':
                            countA++;
                            //reinicio
                            countT = 0;
                            countC = 0;
                            countG = 0;
                            break;
                        case 'T':
                            countT++;
                            //reinicio
                            countA = 0;
                            countC = 0;
                            countG = 0;
                            break;
                        case 'C':
                            countC++;
                            //reinicio
                            countA = 0;
                            countT = 0;
                            countG = 0;
                            break;
                        case 'G':
                            countG++;
                            //reinicio
                            countA = 0;
                            countT = 0;
                            countC = 0;
                            break;
                        default:
                            break;
                    }
                    if (countA >= 4 || countT > 4 || countC >= 4 || countG >= 4)
                        IsMutant++;
                }
            }
            //NO encontrado
            return IsMutant;

        }
        /// <summary>
        /// Method for read HORIZONTALY in array of DNA
        /// </summary>
        /// <param name="arrayToEvaluate">Array to evaluate</param>
        /// <param name="size">size of array</param>
        /// <returns>mutant pattern detected</returns>
        private static int ReadHorizontal(ref char[,] arrayToEvaluate, int size)
        {
            int IsMutant = 0;
            int countA = 0;
            int countT = 0;
            int countC = 0;
            int countG = 0;
            for (int y = 0; y < size; y++)
            {
                //reinicio
                countA = 0;
                countT = 0;
                countC = 0;
                countG = 0;
                for (int x = 0; x < size; x++)
                {
                    switch (arrayToEvaluate[x, y])
                    {
                        case 'A':
                            countA++;
                            //reinicio
                            countT = 0;
                            countC = 0;
                            countG = 0;
                            break;
                        case 'T':
                            countT++;
                            //reinicio
                            countA = 0;
                            countC = 0;
                            countG = 0;
                            break;
                        case 'C':
                            countC++;
                            //reinicio
                            countA = 0;
                            countT = 0;
                            countG = 0;
                            break;
                        case 'G':
                            countG++;
                            //reinicio
                            countA = 0;
                            countT = 0;
                            countC = 0;
                            break;
                        default:
                            break;
                    }
                    if (countA >= 4 || countT > 4 || countC >= 4 || countG >= 4)
                        IsMutant++;
                }
            }


            return IsMutant;

        }

    }
}
