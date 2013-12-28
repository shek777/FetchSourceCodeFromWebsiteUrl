/* 
 * 
Date: December 28, 2013

Modified by @andydipro

File edited with MonoDevelop 4.2.2 on Linux
Compiled using gmcs via Terminal
eq. $ gmcs SourceCode.cs
Executed using mono
eq. $ mono SourceCode.exe
Remember to install MonoDevelop, and gmcs on your Linux distro

By faith all things are possible!

*/


using System;
using System.Net;
using System.IO;
using System.Threading;
 
namespace SouceCodeProject
{
    class SourceCode
    {
        public static void Main(string[]args)
        {
            GetSourceCode();
        }
 
        public static void GetSourceCode()
        {
			try{

	            string url = AskTheUserForURL();
	            StreamReader theSourceCode = HTTPRequest(url);
	 
	            int count = 0;
	 
	            while(!theSourceCode.EndOfStream && !Console.KeyAvailable)
	            {
	                count++;
	                if(count % 2 == 0)
	                {
	                    Console.ForegroundColor = ConsoleColor.Yellow;
	                }else
	                {
	                    Console.ForegroundColor = ConsoleColor.Green;
	                }
	                Console.CursorVisible = false;
	                Thread.Sleep(10);
	                Console.WriteLine(theSourceCode.ReadLine().ToString());
	            }
	 
	            Console.CursorVisible = true;
	            Console.WriteLine();

			}catch(Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(ex.Message);
				Thread.Sleep(1000);
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("End Program!!!");
			}
 
        }
 
        public static string AskTheUserForURL()
        {
			Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the name of the url");
            Console.WriteLine("Remember press any key to stop the program");
			Console.WriteLine("Remember you can only use urls with html extensions!");
            Console.WriteLine("Now tell me what url source you want!");
			Console.ForegroundColor = ConsoleColor.Blue;
 
            string url =  Console.ReadLine();
            Console.ResetColor();
            return url;
        }
 
        public static StreamReader HTTPRequest(string url)
        {
            HttpWebRequest myCall = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse theResponse = (HttpWebResponse)myCall.GetResponse();
            StreamReader source = new StreamReader(theResponse.GetResponseStream());
            return source;
        }
    }
}
