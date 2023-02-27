using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matrix_algerba
{
    public class Matrix
    {
        private int[,] values;

        public Matrix(int n, int m)
        {
            values = new int[n, m];
        }

        public int this[int i, int j]
        {
            get { return values[i, j]; }
            set { values[i, j] = value; }
        }

        public int Rows
        {
            get { return values.GetLength(0); }
        }

        public int Columns
        {
            get { return values.GetLength(1); }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new ArgumentException("Матриці мають різні розміри.");

            Matrix result = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new ArgumentException("Матриці мають різні розміри.");

            Matrix result = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Columns != b.Rows)
                throw new ArgumentException("Кількість стовпців першої матриці має співпадати з кількістю рядків другої матриці.");

            Matrix result = new Matrix(a.Rows, b.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < a.Columns; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        public static Matrix GenerateRandomMatrix(int rows, int cols, int minValue, int maxValue)
        {
            if(minValue > maxValue)
            {
                throw new ArgumentException("Некоректні межі генеруавання");
            }
            Matrix result = new Matrix(rows, cols);
            Random rand = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = rand.Next(minValue, maxValue);
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    sb.Append(this[i, j] + " ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public static Matrix ReadMatrixFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            string[] sizeStr = lines[0].Split(' ');
            int rows = int.Parse(sizeStr[0]);
            int cols = int.Parse(sizeStr[1]);

            Matrix result = new Matrix(rows, cols);

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                string[] valuesStr = lines[i].Split(' ');
                for (int j = 0; j < cols; j++)
                {
                    int value = int.Parse(valuesStr[j]);
                    result[i - 1, j] = value;

                }
            }

            return result;
        }

        public void WriteMatrixToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"{Rows} {Columns}");

                for (int i = 0; i < Rows; i++)
                {
                    string[] rowValues = new string[Columns];
                    for (int j = 0; j < Columns; j++)
                    {
                        rowValues[j] = this[i, j].ToString();
                    }
                    writer.WriteLine(string.Join(" ", rowValues));
                }
            }
        }

        public static double EuclideanNorm(Matrix matrix)
        {
            double norm = 0;

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    double element = matrix[i, j];
                    norm += element * element;
                }
            }

            norm = Math.Sqrt(norm);

            return norm;
        }

        public static void WriteEuclideanNormToFile(Matrix matrix, string fileName)
        {
            double norm = EuclideanNorm(matrix);

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"Euclidean norm of matrix {matrix.Rows}x{matrix.Columns}: {norm}");
            }
            
        }
    }

    public class Vector
    {
        private readonly double[] _data;

        public int Length => _data.Length;

        public Vector(int length)
        {
            _data = new double[length];
        }

        public Vector(double[] data)
        {
            _data = data;
        }

        public double this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        public static Vector operator +(Vector left, Vector right)
        {
            if (left.Length != right.Length)
            {
                throw new ArgumentException("Vectors must have the same length.");
            }

            Vector result = new Vector(left.Length);

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = left[i] + right[i];
            }

            return result;
        }

        public static Vector operator -(Vector left, Vector right)
        {
            if (left.Length != right.Length)
            {
                throw new ArgumentException("Vectors must have the same length.");
            }

            Vector result = new Vector(left.Length);

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = left[i] - right[i];
            }

            return result;
        }

        public static double operator *(Vector left, Vector right)
        {
            if (left.Length != right.Length)
            {
                throw new ArgumentException("Vectors must have the same length.");
            }

            double result = 0;

            for (int i = 0; i < left.Length; i++)
            {
                result += left[i] * right[i];
            }

            return result;
        }
    }

    public class LinearEquationsSystem
    {
        private Matrix A;
        private Matrix b;
        private Vector x;

        public LinearEquationsSystem(Matrix A, Matrix b)
        {
            this.A = A;
            this.b = new Matrix(A.Columns, 1);
        }

    }

    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
