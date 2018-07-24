using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marupeke
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] area = {
				0, 0, 0,
				0, 0, 0,
				0, 0, 0
			};
			string[,] areastr = {
				{"〇", "×", "×"},
				{"〇", "×", "〇"},
				{"×", "〇", "〇"},
			};

			// 表示
			Console.WriteLine($"{areastr[0,0]}｜{areastr[0,1]}｜{areastr[0,2]}");
			Console.WriteLine("―――――");
			Console.WriteLine($"{areastr[1,0]}｜{areastr[1,1]}｜{areastr[1,2]}");
			Console.WriteLine("―――――");
			Console.WriteLine($"{areastr[2,0]}｜{areastr[2,1]}｜{areastr[2,2]}");
		}
	}
}
