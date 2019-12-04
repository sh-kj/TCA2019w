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
			Console.WriteLine("ゲームスタート");
			Player _Daisuke = new Player("大介", 1, 0, 20, 10, 5);
			Player _okuty = new Player("おくてぃ～", 1, 0, 1, 1, 1);

			while (_Daisuke.IsAlive)
			{
				Enemy enemy = new Enemy("プランナー", 10, 10, 5, 15);
				Console.WriteLine(enemy.Name + "が現れた！");

				Battle battle = new Battle( _Daisuke
					, enemy);
				bool battleisEnd = false;
				while (!battleisEnd)
				{

					Console.WriteLine("コマンド？");
					Console.ReadLine();

					battleisEnd = battle.AdvanceTrum();

					Console.WriteLine(_Daisuke.Name + "のHP：" + _Daisuke.HP);


				}

				Console.ReadLine();
			}
		}
	}
}
