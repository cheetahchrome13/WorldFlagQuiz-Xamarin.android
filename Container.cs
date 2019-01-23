using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;

namespace WorldFlagQuiz
{
	class Container
	{
		public ImageView FlagImage;
		public Button Answer1;
		public Button Answer2;
		public Button Answer3;
		public Button Answer4;
		public TextView Correct;
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="v"></param>
		public Container(View v)
		{
			FlagImage = v.FindViewById<ImageView>(Resource.Id.flagImage);
			Answer1 = v.FindViewById<Button>(Resource.Id.answer1);
			Answer2 = v.FindViewById<Button>(Resource.Id.answer2);
			Answer3 = v.FindViewById<Button>(Resource.Id.answer3);
			Answer4 = v.FindViewById<Button>(Resource.Id.answer4);
			Correct = v.FindViewById<TextView>(Resource.Id.correctAnswer);
		}
	}
}