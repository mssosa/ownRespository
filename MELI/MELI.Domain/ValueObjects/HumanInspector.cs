using MELI.Domain.Humans;
using System;
using System.Collections.Generic;
using System.Text;

namespace MELI.Domain.ValueObjects
{
    public class HumanInspector
    {
        public static bool IsMutant(Human human)
        {
            var dna = human.DnaArray;
            ///CAMBIAR!
            int valor = dna[0].Length;
            char[,] arrayBorrar = new char[valor, valor];
            int i = 0;
            int j = 0;
            foreach (var item in dna)
            {
                var charArray = item.ToCharArray();
                foreach (var ch in charArray)
                {
                    if (ch != ',')
                    {
                        arrayBorrar[i, j] = ch;

                    }
                    j++;
                }
                j = 0;
                i++;
            }
            //horizaontal
            int countIsMutant = 0;
            #region OLD CODE
            var h = ReadHorizontal(ref arrayBorrar, valor);
            if (h > 0)
                countIsMutant += h;
            //If there are 2 horizontal pattern is Mutant and doesn't need to follow trying to determinated
            if (countIsMutant < 2)
            {
                //vertical
                var v = ReadVertical(ref arrayBorrar, valor);
                if (v > 0)
                    countIsMutant += v;
            }
            // if we have 2 counts is already  mutant and doesn't need to follow trying to determinated
            if (countIsMutant < 2)
            {
                //oblicuo
                var o = ReadObliquos(ref arrayBorrar, valor);
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
        private static int ReadObliquos(ref char[,] arrayBorrar, int valor)
        {
            int IsMutant = 0;
            int countA = 0;
            int countT = 0;
            int countC = 0;
            int countG = 0;
            //Cover bottom half
            for (int x = 0; x < valor; x++)
            {
                countA = 0;
                countT = 0;
                countC = 0;
                countG = 0;
                int z = x;
                for (int y = 0; y < valor; y++)
                {

                    if (x < valor && y < valor)
                    {
                        switch (arrayBorrar[x, y])
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
            for (int y = 1; y < valor; y++)
            {
                countA = 0;
                countT = 0;
                countC = 0;
                countG = 0;
                int z = y;
                for (int x = 0; x < valor; x++)
                {

                    if (x < valor && y < valor)
                    {
                        switch (arrayBorrar[x, y])
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
        private static int ReadVertical(ref char[,] arrayBorrar, int valor)
        {
            int IsMutant = 0;
            int countA = 0;
            int countT = 0;
            int countC = 0;
            int countG = 0;
            for (int x = 0; x < valor; x++)
            {
                countA = 0;
                countT = 0;
                countC = 0;
                countG = 0;
                for (int y = 0; y < valor; y++)
                {
                    switch (arrayBorrar[x, y])
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
        private static int ReadHorizontal(ref char[,] arrayBorrar, int valor)
        {
            int IsMutant = 0;
            int countA = 0;
            int countT = 0;
            int countC = 0;
            int countG = 0;
            for (int y = 0; y < valor; y++)
            {
                //reinicio
                countA = 0;
                countT = 0;
                countC = 0;
                countG = 0;
                for (int x = 0; x < valor; x++)
                {
                    switch (arrayBorrar[x, y])
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
