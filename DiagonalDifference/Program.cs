/*
 * Purpose: Given a square matrix of size N x N , calculating the absolute difference between the sums of its diagonals.
 * Programmer: Oleksii Butakov
 * Written: August 8, 2017
 */

using System;
using System.IO;


namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int diagonalSum1 = 0,
                diagonalSum2 = 0,
                diagonalDifference;

            string line;
            string filename = "matrix.txt";
            string path = Path
                .GetDirectoryName(System.IO.Directory.GetCurrentDirectory())
                .Substring(0, Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()).Length - 4) 
                + "\\" + filename;

            //path = path.Substring(0, path.Length - 4) + "\\" + filename;

            StreamReader file = new StreamReader(path);

            // Reading 1st line, which is N-number (number of elements in each row/column)
            Int16 nElements = Convert.ToInt16(file.ReadLine());

            // Declaring N x N matrix 
            int[,] matrix = new int[nElements, nElements];

            // this array will be used as a delimeter in the future
            string[] tokens;
            
            // Reading file and initialing matrix
            for (int i = 0; i < nElements; i++)
            {
                line = file.ReadLine();
                tokens = line.Split(' '); // setting "whitespace" delimeter
                int[] numbers = Array.ConvertAll(tokens, int.Parse); // Converting string of integers into the int array
                
                for(int j = 0; j < nElements; j++)
                    matrix[i, j] = numbers[j];
            }
           
            // Calculating the diagonals 
            for(int i = 0, j = 0, k = nElements - 1; i < nElements; i++, j++, k--)
            {
                diagonalSum1 += matrix[i, j];
                diagonalSum2 += matrix[k, j];
            }

            // Calculating Absolute Sum
            diagonalDifference = diagonalSum1 - diagonalSum2;

            if (diagonalDifference < 0)
                diagonalDifference = diagonalDifference * (-1);
            
            // Displaying the Results
            Console.WriteLine("Diagonal Sum 1:  " + diagonalSum1);
            Console.WriteLine("Diagonal Sum 2:  " + diagonalSum2);
            Console.WriteLine("Absolute Diagonal Difference: " + diagonalDifference);

            // Freezing the screen
            Console.ReadLine();
        }
    }
}
