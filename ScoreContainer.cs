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
	class ScoreContainer
	{
		public TextView Player;
		public TextView Score;

		public ScoreContainer(View v)
		{
			this.Player = v.FindViewById<TextView>(Resource.Id.player);
			this.Score = v.FindViewById<TextView>(Resource.Id.score);
		}
	}
}