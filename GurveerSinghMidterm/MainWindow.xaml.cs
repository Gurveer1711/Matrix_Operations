using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;

namespace GurveerSinghMidterm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Creator creator = new Creator();


        private void submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int matrixSize = Convert.ToInt32(size.Text);
                if (matrixSize >= 3)
                {
                    creator.size = matrixSize;
                    creator.generateMatrix(matrixSize);

                    printer.Content = "Matrix successfully created";

                    String output = creator.printmatrix(matrixSize) + "\n\n";

                    using (StreamWriter writer = new StreamWriter("MidTerm.txt"))
                    {
                        writer.WriteLine(output);
                    }
                }
                else
                {
                    MessageBox.Show("The length of the matrix should be more than 3");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Check Your Inputs");
            }



        }



        

        private void check_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int matrixSize = Convert.ToInt32(size.Text);
                if (matrixSize > 2)
                {
                    int result = creator.checkString(entry.Text, matrixSize);
                    if (result > 0)
                    {
                        printer.Content = "The entered string exist in the Matrix";
                    }
                    else
                    {
                        printer.Content = "The entered string doesn't exist in the Matrix";
                    }
                }
                else
                {
                    MessageBox.Show("Matrix Doesn't Exist");
                }

            }catch (Exception ex)
            {
                MessageBox.Show("Please create the matrix First !!!!");
            }
            


        }

        private void searchFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String fileName = f_name.Text;

                using (StreamReader file = new StreamReader(fileName))
                {
                    int counter = 0;
                    string ln;
                    String output = "";
                    int checker = 0;
                    int matrixSize = Convert.ToInt32(file.ReadLine());
                    if (matrixSize >= 3)
                    {
                        int num_lines = File.ReadLines(fileName).Count(line => !string.IsNullOrWhiteSpace(line)) - 1;

                        if (num_lines < matrixSize)
                        {
                            MessageBox.Show("The matrix in the text file is not a square matrix");
                        }

                        else
                        {
                            creator.matrix = new char[matrixSize][];
                            while (counter < matrixSize)
                            {
                                ln = file.ReadLine();
                                if (!String.IsNullOrEmpty(ln))
                                {
                                    ln = ln.Replace(" ", String.Empty);
                                    if (ln.Length < matrixSize)
                                    {
                                        MessageBox.Show("The matrix in the text file is not a square matrix");
                                        checker++;
                                        break;


                                    }
                                    else
                                    {
                                        creator.matrix[counter] = ln.ToCharArray();
                                        counter++;
                                    }

                                }
                                else
                                {
                                    continue;
                                }
                            }
                            file.Close();

                            if (checker == 0)
                            {
                                printer.Content = creator.checkMatrix(matrixSize);
                            }

                        }


                    }
                    else
                    {
                        MessageBox.Show("The matrix length is less tham 3");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("File not Found or it is not defined according to the defined standards!!!");
            }

        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", "MidTerm.txt");
        }

    }
}
