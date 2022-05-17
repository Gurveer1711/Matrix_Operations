using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GurveerSinghMidterm
{
    internal class Creator
    {

        public char[][] matrix;
        public char[][] matrix2;
        public int size;

        public void generateMatrix(int size)
        {
            matrix = new char[size][];
            for(int i = 0; i < size; i++)
            {
                char[] row = new char[size];
                for(int j=0; j < size; j++)
                {
                    Random rnd = new Random();
                    char randomChar = (char)rnd.Next('a', 'z');
                    row[j] = randomChar;
                }
                matrix[i] = row;
            }

            

        }
        
        public String printmatrix(int size)
        {
            String output = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    output += matrix[i][j] + " ";
                }
                output += "\n";
            }
            return output;

        }
       
       

        public char[][] createTranspose(int size)
        {
            matrix2 = new char[size][];

            for (int i = 0; i < size; i++)
            {
                char[] row = new char[size];
                for (int j = 0; j < size; j++)
                {
                     row[j]= matrix[j][i];
                }
                matrix2[i] = row;
            }
            return matrix2;
        }

        

        public int checkString(String test, int size)
        {
            test = test.Replace(" ", String.Empty);
            char[] arr = test.ToCharArray();
            matrix2 = createTranspose(size);
            int check = 0;
            for (int i = 0; i < size; i++)
            {
                Array.Reverse(matrix[i]);
                if (matrix[i].SequenceEqual(arr))
                {
                    check++;
                }else if (matrix2[i].SequenceEqual(arr))
                {
                    check++;
                }
                Array.Reverse(matrix[i]);
            }

            return check;
        }

        public int checkString2(String test, int size)
        {
            test = test.Replace(" ", String.Empty);
            char[] arr = test.ToCharArray();
            matrix2 = createTranspose(size);
            int check = 0;
            for (int i = 0; i < size; i++)
            {
               
                if (matrix[i].SequenceEqual(arr))
                {
                    check++;
                }
                else if (matrix2[i].SequenceEqual(arr))
                {
                    check++;
                }
            }

            return check;
        }


        public String checkMatrix(int size)
        {
            createTranspose(size);
            String MaxOccur = "";
            String arr, arr2;
            int max_count=0;
            int equal = 0;
            for(int i = 0; i < size; i++)
            {
                arr = new string(matrix[i]);
                arr2 = new string(matrix2[i]);
                if(checkString2(arr, size) > max_count)
                {
                    
                    max_count = checkString2(arr, size);
                    MaxOccur = arr;

                }
                if(checkString2(arr2 , size) > max_count)
                {
                    max_count = checkString2(arr2, size);
                    MaxOccur = arr2;
                    
                }
                if (arr.Equals(arr2))
                {
                    equal++;
                }

            }
            if((max_count+equal) == 1)
            {
                return "No string appears more than once";
            }
            else
            {
                return MaxOccur + " comes " + (max_count+equal) + " times in the Matrix";
            }
            

        }

    }
}
