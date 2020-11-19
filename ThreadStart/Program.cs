using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadStart
{
	public class CounterThread
	{
		public static void run()
		{
			
			for (int i = 0; i < 10000; i++)
			{
				Console.WriteLine("Count:  " + i);			
			}
		}

		public static void Main(string[] args)
		{
			
			Thread ct = new Thread(run);

			//Console.WriteLine("It has started");

			//Thread.Sleep(1000);
			
			ct.Start();
			
			//Console.WriteLine("It has ended");

			Console.ReadLine();

			
		}
	}
}
