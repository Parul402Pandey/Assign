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
                                program.filelist.Add(fileName);
                                

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
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
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
            public System.IO.StreamWriter file;
            public void SolutionOfAQuestion(String fileNameForRead)
            {
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
                
                
                if(line.Contains("and"))
                {
                    
                    char[] charArr = line.ToCharArray();
                    for(int i=0;i<charArr.Length;i++)
                    {
                        if(charArr[0]=='a')
                        {
                            file.Write("Invalid Operator");
                            break;
                        }
                    }
                }
                Console.Write("\n");
            }
            file.Close();
            
        }
        
      

        }
  }

