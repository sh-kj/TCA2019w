using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06
{
	class Program
	{
		static void Main(string[] args)
		{

			Player player = new Player("俺",1,0,50,3,5);

			while (true)
			{
				Enemy enemy = new Enemy("敵だよ君",10,1,0,10);
				Console.WriteLine(           "〇〇〇〇〇〇〇〇〇〇〇〇○○");
				Console.WriteLine("○"+enemy.Name+"がスポーンした。○");
				Console.WriteLine(           "〇〇〇〇〇〇〇〇〇〇〇〇〇〇");
				Battle battle = new Battle(player,enemy);
				bool BattleEND = false;
				while (!BattleEND)
				{

					//ターン開始
					//プレーヤーの行動入力（何も受ける情報はない）
					Console.WriteLine("EnterでターンEND");
					Console.ReadLine();
					BattleEND = battle.AdvanceTurn();



				}
			}

			Console.WriteLine("press return to quit.");
			Console.ReadLine();
		}
	}
}
