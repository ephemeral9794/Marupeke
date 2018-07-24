using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marupeke
{
	class Program
	{
		static void PrintDesc()
		{
			string[,] desc = {
				{"１", "２", "３"},
				{"４", "５", "６"},
				{"７", "８", "９"},
			};
			Console.WriteLine("「Tic Tac Toe（三目並べ）」 on C#");
			Console.WriteLine("―――――――");
			Console.WriteLine($"｜{desc[0,0]}｜{desc[0,1]}｜{desc[0,2]}｜");
			Console.WriteLine("｜―――――｜");
			Console.WriteLine($"｜{desc[1,0]}｜{desc[1,1]}｜{desc[1,2]}｜");
			Console.WriteLine("｜―――――｜");
			Console.WriteLine($"｜{desc[2,0]}｜{desc[2,1]}｜{desc[2,2]}｜");
			Console.WriteLine("―――――――");
			Console.WriteLine();

		}

		static void FillAreaString(ref string[] areastr, int[] area)
		{
			if (areastr.Length != area.Length) {
				return;
			}
			for (int i = 0; i < areastr.Length; i++) {
				switch (area[i])
				{
					case 1:
						areastr[i] = "〇";
						break;
					case -1:
						areastr[i] = "×";
						break;
					default:
						areastr[i] = "　";
						break;
				}
			}
		}

		static IEnumerable<int[]> GetLineIndexes() {
            yield return new int[] { 0, 1, 2 };	// 横1段目
            yield return new int[] { 3, 4, 5 };	// 横2段目
            yield return new int[] { 6, 7, 8 };	// 横3段目
            yield return new int[] { 0, 3, 6 };	// 縦1列目
            yield return new int[] { 1, 4, 7 };	// 縦2列目
            yield return new int[] { 2, 5, 8 };	// 縦3列目
            yield return new int[] { 0, 4, 8 };	// 右下ななめ
            yield return new int[] { 2, 4, 6 };	// 左下ななめ
        }
		static int ClearJudgment(int[] area)
		{
			foreach (var index in GetLineIndexes()) {
				if (index.All(x => area[x] == 1))	// 〇
                    return 1;
                if (index.All(x => area[x] == -1))	// ×
                    return -1;
			}
			return 0;
		}

		static void Main(string[] args)
		{
			// 判定領域(〇:1, ×:-1, 空:0)
			int[] area = {
				0, 0, 0,
				0, 0, 0,
				0, 0, 0
			};
			string[] areastr = {
				"〇", "×", "×",
				"〇", "×", "〇",
				"×", "〇", "〇",
			};
			// 手番
			bool turn = false;

			// 説明表示
			PrintDesc();

			int i = 0, judge = 0;
			while(i < area.Length) {
				if (turn) {
					Console.WriteLine("プレイヤー[〇]の手番です。");
				} else {
					Console.WriteLine("プレイヤー[×]の手番です。");
				}

				// 入力
				Console.Write("どこを埋めますか？：");
				string instr = Console.ReadLine();
				if (instr == "") {
					Console.WriteLine("何も入力されていません。");
					Console.WriteLine();
					continue;
				}
				int input = int.Parse(instr);
				int n = input < 1 ? 0 : input > 10 ? 8 : input - 1;
				if (area[n] != 0) {
					Console.WriteLine("すでに入力済みです。");
					Console.WriteLine();
					continue;
				}
				area[n] = turn ? 1 : -1;
				FillAreaString(ref areastr, area);

				// 表示
				Console.WriteLine($"{areastr[0]}｜{areastr[1]}｜{areastr[2]}");
				Console.WriteLine("―――――");
				Console.WriteLine($"{areastr[3]}｜{areastr[4]}｜{areastr[5]}");
				Console.WriteLine("―――――");
				Console.WriteLine($"{areastr[6]}｜{areastr[7]}｜{areastr[8]}");
				Console.WriteLine();

				// 判定
				judge = ClearJudgment(area);
				if (judge != 0) {
					if (judge == 1) {
						Console.WriteLine();
						Console.WriteLine("プレイヤー[〇]の勝利です。");
					} else if (judge == -1) {
						Console.WriteLine();
						Console.WriteLine("プレイヤー[×]の勝利です。");
					}
					break;
				}

				turn = !turn;	// 手番交代
				i++;
			}

			if (judge == 0) {
				Console.WriteLine();
				Console.WriteLine("引き分けです。");
			}
		}
	}
}
