using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WorldFlagQuiz
{
	class FX
	{
		protected static MediaPlayer player;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="isCorrect"></param>
		public static void WeighIn(Context context, bool isCorrect)
		{
			if (isCorrect)
			{
				if (player == null)
				{
					player = MediaPlayer.Create(context, Resource.Raw.taDa);
					player.Start();
				}
				else
				{
					player.Reset();
					player = MediaPlayer.Create(context, Resource.Raw.taDa);
					player.Start();
				}
			}
			else
			{
				if (player == null)
				{
					player = MediaPlayer.Create(context, Resource.Raw.sadTrombone);
					player.Start();
				}
				else
				{
					player.Reset();
					player = MediaPlayer.Create(context, Resource.Raw.sadTrombone);
					player.Start();
				}
			}
		}
	}
}