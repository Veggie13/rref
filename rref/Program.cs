using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Mehroz;

namespace rref
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"C:\temp\matrix.txt");
            string[] line = reader.ReadLine().Split('\t');
            int nvars = line.Length - 1;
            bool done = reader.EndOfStream;
            double[,] matrix = new double[nvars, nvars + 1];
            int row = 0;
            double[] parsed = Array.ConvertAll<string, double>(line, delegate(string s)
            {
                return Double.Parse(s);
            });
            for (int c = 0; c < matrix.GetLength(1); c++)
                matrix[row, c] = parsed[c];
            do
            {
                line = reader.ReadLine().Split('\t');
                done = reader.EndOfStream;
                row++;
                parsed = Array.ConvertAll<string, double>(line, delegate(string s)
                {
                    return Double.Parse(s);
                });
                for (int c = 0; c < matrix.GetLength(1); c++)
                    matrix[row, c] = parsed[c];
            } while (!done);

            Matrix mat = new Matrix(matrix);
            Console.Write(mat.ReducedEchelonForm());
            Console.ReadLine();
        }
    }
}
