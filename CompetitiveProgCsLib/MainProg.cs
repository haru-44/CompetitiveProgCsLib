using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitiveProgCsLib
{
	class MainProg
	{
		static int In => int.Parse(Console.ReadLine());
		static int[] Ins => Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
		static void Out(bool b) => Console.WriteLine(b ? "Yes" : "No");

		static void Main(string[] args)
		{
		}
	}
}
