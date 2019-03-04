using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace AssignmentFirst
{
    class Program
    {
       public  List<String> filelist = new List<String>();
        static void Main(string[] args)
        {
            
            TextFileShowing tf=new TextFileShowing();
            tf.ShowingQuestionFiles();
            Console.ReadKey();
        }
    }
    class TextFileShowing
    {
        Program program = new Program();
        ProvideSolutionToParticularQuestion pv = new ProvideSolutionToParticularQuestion();
        public void ShowingQuestionFiles()
        {
            Console.WriteLine("Please enter a valid Document Path");
            try
            {
                String str = Console.ReadLine(); ;
                String path = @"C: \Users\craterzone\Desktop\Assignment";
                if (str.Contains(@"C: \Users\craterzone\Desktop\Assignment"))
                {
                    string[] fileEntries = Directory.GetFiles(path);
                    foreach (string fileName in fileEntries)
                    {
                        if (fileName.StartsWith(@"C: \Users\craterzone\Desktop\Assignment\quest"))
                        {

                            if (fileName.EndsWith(".txt"))
                            {
                                Console.WriteLine(Path.GetFileName(fileName));
                              // program.filelist.Add(fileName);
                                

                            }
                        }


                    }
                    
                    String fileNameForRead = MenuForSolution();
                    pv.SolutionOfAQuestion(fileNameForRead);
                   
                }
                else
                {
                    Console.WriteLine("NO Quest.Txt Exist");
                }
            } catch (Exception e)
            {
                Console.WriteLine("hello"+e.Message);
            }
          //  Console.ReadKey();
        }
        public String MenuForSolution()
        {
            Program program = new Program();
            Console.Write("Which File Solution Wants To Get: ");
            String fileName=Console.ReadLine();
            return fileName;
            

        }

    }
            class ProvideSolutionToParticularQuestion
        {
        int count = 0;
            public System.IO.StreamWriter file;
            public  int sum=0;
            public void SolutionOfAQuestion(String fileNameForRead)
            {
              
            Char[] operators = new char[] { '+','-','/','%','*' };
             file =
            new System.IO.StreamWriter(@"C: \Users\craterzone\Desktop\Assignment\" + "solved_" + fileNameForRead + ".txt", true);
            string[] lines = System.IO.File.ReadAllLines(@"C: \Users\craterzone\Desktop\Assignment\"+fileNameForRead+".txt");

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of file");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);

                //writing to a a file

                if (!string.IsNullOrEmpty(line))
                {
                    
                    if (line.Contains("and"))
                    {
                       if (line[0] == 'a')
                        {
                            
                            file.Write( " Invalid Operand"+Environment.NewLine);
                            

                        }
                       if(line[0]=='-')
                        {
                            file.Write(" Invalid operator" +Environment.NewLine);
                        }
                       if(line[0]!='a'&&line[0]!='-')
                        {
                            String pattern = @"and";
                            String[] elements = Regex.Split(line, pattern);
                            
                            String[] arr = elements[0].Split('+');
                            int a = int.Parse(arr[0]);
                            int b = int.Parse(arr[1]);
                            int sum = a + b;
                            // Console.Write(sum);
                            //file.Write(sum);
                            String[] arr1 = elements[1].Split('-');
                            int c = int.Parse(arr1[0]);
                            int d = int.Parse(arr1[1]);
                            int diff = c - d;
                            // Console.Write(diff);
                            file.Write(sum + "and" + diff+Environment.NewLine);
                        }

                    }
                   

                    if (!line.Contains("and"))
                    {
                        if(line[0]=='-')
                        {
                            count++;
                            file.Write(" Invalid operAND"+Environment.NewLine);
                        }

                        
                        if (!line.Contains("*") && !line.Contains("+") && !line.Contains("-") && !line.Contains("%") && !line.Contains('/'))
                        {
                            count++;
                            file.Write(" Invalid instruction"+Environment.NewLine);

                        }
                        if (line.Contains("+"))
                        {
                            String[] arr = line.Split('+');
                            int a=int.Parse(arr[0]);
                            int b = int.Parse(arr[1]);
                            int sum = a + b;
                           // Console.Write(sum);
                            file.Write(" "+sum+Environment.NewLine);

                        }

                    }
                    
                       
                }

                else
                {
                    file.Write("fail");
                }
               
            }
            Console.Write("\n");
            file.Close();
            
        }
        
      

        }
  }

