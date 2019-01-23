using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WorldFlagQuiz
{
	class Game
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="round"></param>
		/// <param name="player"></param>
		/// <param name="score"></param>
		public Game(string player, string score)// int 
		{
			//this.Round = round;
			this.Player = player;
			this.Score = score;
		}

		/// <summary>
		/// 
		/// </summary>
		//public List<Question> Round { get; private set; }
		public string Player { get; set; }
		public string Score { get; set; } = "0";
	}
}