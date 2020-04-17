using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix1;
            int[,] matrix2;
            int[,] matrix3 = new int[0, 0];

            string choose = "1";
            matrixs(out matrix1, out matrix2);

            while (choose != "0")
            {
                Console.WriteLine("Chose:\n" +
                    "0: Exit\n" +
                    "1: Show \n" +
                    "2: Multiplication \n" +
                    "3: Sum \n" +
                    "4: Subtraction \n" +
                    "5: Transpose first matrix \n" +
                    "6: Transpose second matrix\n" +
                    "7: Determinant first matrix\n" +
                    "8: Determinant second matrix\n" +
                    "9: Multiplication first matrix by number\n" +
                    "10: Multiplication second matrix by number\n");
                choose = Console.ReadLine();
                choose = choose.Replace(" ", string.Empty);
                //Console.Clear();

                switch (choose)
                {
                    case "1":
                        {
                            Console.WriteLine("1st matrix: ");

                            Show(matrix1);

                            Console.WriteLine();

                            Console.WriteLine("2nd matrix: ");

                            Show(matrix2);

                            Console.WriteLine();
                        }
                        break;

                    case "2":
                        {
                            Mult(matrix1, matrix2, matrix3);
                        }
                        break;

                    case "3":
                        {
                            Sum(matrix1, matrix2, matrix3);
                        }
                        break;

                    case "4":
                        {
                            Sub(matrix1, matrix2, matrix3);
                        }
                        break;

                    case "5":
                        {
                            Tran(matrix1, matrix3);
                        }
                        break;

                    case "6":
                        {
                            Tran(matrix2, matrix3);
                        }
                        break;

                    case "7":
                        {
                            int det = Det(matrix1);
                            Console.WriteLine("\nDeterminant(1): " + det + "\n");
                        }
                        break;

                    case "8":
                        {
                            int det = Det(matrix2);
                            Console.WriteLine("\nDeterminant(2): " + det + "\n");
                        }
                        break;

                    case "9":
                        {
                            string factor;
                            Console.WriteLine("Set number(factor): ");

                            factor = Console.ReadLine();

                            choose = choose.Replace(" ", string.Empty);

                            int num = 0;

                            if (CheckS(factor, num) == true)
                            {
                                MultChar(matrix1, factor, matrix3);
                            }
                            else
                            {
                                Console.WriteLine("\nThis is a string\n");
                            }
                        }
                        break;

                    case "10":
                        {
                            string factor;
                            Console.WriteLine("Set number(factor): ");

                            factor = Console.ReadLine();

                            choose = choose.Replace(" ", string.Empty);
                            int num = 0;

                            if (CheckS(factor, num) == true)
                            {
                                MultChar(matrix2, factor, matrix3);
                            }
                            else
                            {
                                Console.WriteLine("\nThis is a string\n");
                            }
                        }
                        break;
                    default: break;
                }

            }
        }

        static void matrixs(out int[,] matrix1, out int[,] matrix2)
        {
            string FirstFile = "C:/Users/SNou/Desktop/1matrix.txt";
            string SecondFile = "C:/Users/SNou/Desktop/2matrix.txt";
            if (!System.IO.File.Exists(FirstFile)
                ||
                !System.IO.File.Exists(SecondFile))
            {
                Console.WriteLine("File doesn't exist.");
                Environment.Exit(0);
            }

            string[] lines1 = File.ReadAllLines(FirstFile);
            string[] lines2 = File.ReadAllLines(SecondFile);
            if (lines1.Length == 0
                ||
                lines2.Length == 0)
            {
                Console.WriteLine("File is empty.");
                Environment.Exit(0);
            }

            matrix1 = new int[lines1.Length, lines1[0].Split(' ').Length];
            matrix2 = new int[lines2.Length, lines2[0].Split(' ').Length];
            for (int i = 0; i < lines1.Length; i++)
            {
                string[] temp = lines1[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                    try
                    {
                        matrix1[i, j] = Convert.ToInt32(temp[j]);
                    }
                    catch
                    {
                        Console.WriteLine("Only integers should be in the file.");
                        Environment.Exit(0);
                    }
            }
            for (int i = 0; i < lines2.Length; i++)
            {
                string[] temp = lines2[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                    try
                    {
                        matrix2[i, j] = Convert.ToInt32(temp[j]);
                    }
                    catch
                    {
                        Console.WriteLine("Only integers should be in the file.");
                        Environment.Exit(0);
                    }
            }
        }
        static bool CheckComp(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool SizeCheck(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) ||
                matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                Console.WriteLine("Different order of matrices");
                Console.ReadKey();
                return false;
            }
            else
            {
                return true;
            }

        }

        static bool CheckS(string str, int num)
        {
            bool isNum = int.TryParse(str, out num);
            if (isNum)
                return true;
            else

                return false;
        }



        static void Show(int[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    Console.Write(matrix[i, j] + " ");

                }

                Console.WriteLine();

            }
        }

        static void Mult(int[,] matrix1, int[,] matrix2, int[,] matrix3)
        {

            if (CheckComp(matrix1, matrix2))
            {
                matrix3 = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        for (int t = 0; t < matrix1.GetLength(1); t++)
                        {
                            matrix3[i, t] += matrix1[i, t] * matrix2[t, j];
                        }
                    }
                }
            }
            else if (CheckComp(matrix2, matrix1))
            {
                matrix3 = new int[matrix2.GetLength(0), matrix1.GetLength(1)];

                for (int i = 0; i < matrix2.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        for (int t = 0; t < matrix2.GetLength(1); t++)
                        {
                            matrix3[i, t] += matrix2[i, t] * matrix1[t, j];
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Matrices are not consistent");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("3rd matrix: ");
            Show(matrix3);
            Console.ReadKey();
        }

        static void Sum(int[,] matrix1, int[,] matrix2, int[,] matrix3)
        {
            if (SizeCheck(matrix1, matrix2))
            {
                matrix3 = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        matrix3[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }

                Console.WriteLine("3rd matrix: ");
                Show(matrix3);
                Console.ReadKey();
            }

        }

        static void Sub(int[,] matrix1, int[,] matrix2, int[,] matrix3)
        {
            if (SizeCheck(matrix1, matrix2))
            {
                matrix3 = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        matrix3[i, j] = matrix1[i, j] - matrix2[i, j];
                    }
                }

                Console.WriteLine("3rd matrix: ");
                Show(matrix3);
                Console.ReadKey();
            }

        }

        static void Tran(int[,] matrix, int[,] matrixTran)
        {
            matrixTran = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrixTran[i, j] = matrix[j, i];
                }
            }
            Console.WriteLine("Transposed: ");
            Show(matrixTran);
            Console.ReadKey();
        }

        static int Det(int[,] matrix)
        {
            int det = 0;
            if (matrix.Length == 1)
            {
                det = matrix[0, 0];
            }
            else if (matrix.Length == 4)
            {
                det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                int sign = 1;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int[,] minor = Minor(matrix, i, 0);
                    det += sign * matrix[0, i] * Det(minor);
                    sign *= -1;
                }

            }
            return det;
        }

        static int[,] Minor(int[,] matrix, int colomn, int line)
        {
            int[,] result = new int[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            for (int i = 0, a = 0; a < matrix.GetLength(0) - 1; i++)
            {
                if (i == line)
                {
                    continue;
                }
                for (int j = 0, b = 0; j < matrix.GetLength(0); j++)
                {
                    if (j == colomn)
                        continue;
                    result[a, b] = matrix[i, j];
                    b++;
                }
                a++;
            }
            return result;
        }

        static void MultChar(int[,] matrix, string factor, int[,] multMatrix)
        {
            int a = Convert.ToInt32(factor);
            multMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    multMatrix[i, j] = matrix[i, j] * a;
                }
            }
            Console.WriteLine("New matrix: ");
            Show(multMatrix);
            Console.ReadKey();
        }

    }
}