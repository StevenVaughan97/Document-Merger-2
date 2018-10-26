using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DocumentMerger2
{
    class Program
    {
        static void Main(string[] args)
        {
            String newContent = "";
            int argumentCount;

            if (args.Length < 3)
            {
                Console.WriteLine("DocumentMerger2 <input_file_1> <input_file_2> ... <input_file_n> <output_file>");
                Console.WriteLine("Supply a list of text files to merge followed by the name of the resulting merged text file as command line arguments.");
            }
            else
            {
                argumentCount = args.Length;
                for(int i=0; i<args.Length-1; i++)
                {
                    Console.WriteLine("File to merge: "+args[i]);
                    while (!File.Exists(args[i]))
                    {
                        Console.WriteLine("File "+args[i] +" not found. Please enter valid files");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    try
                    {
                        newContent += System.IO.File.ReadAllText(args[i]);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        Environment.Exit(0);
                    }
                }
                Console.WriteLine("New File: "+args[argumentCount-1]);
                try
                {
                    using (StreamWriter sw = new StreamWriter(args[argumentCount - 1]))
                    {
                        sw.WriteLine(newContent);
                    }
                }
                catch (Exception x) 
                {
                    Console.WriteLine(x.ToString());
                    Environment.Exit(0);
                }
            }
            Console.WriteLine("Your new file "+ args[args.Length - 1] + " has been created.");
            Console.ReadLine();
        }
    }
}