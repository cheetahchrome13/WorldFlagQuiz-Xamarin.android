using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Newtonsoft.Json;
using Android.Graphics;

namespace WorldFlagQuiz
{
	[Activity(Label = "FinishActivity")]
	public class FinishActivity : Activity
	{
		private ISharedPreferences pref = Application.Context.GetSharedPreferences("APP_DATA", FileCreationMode.Private);

		List<Game> top10 = ScoreKeeper.GetTopTen();

		private ScoreboardAdapter adapter;
		private ListView topTen;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="savedInstanceState"></param>
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.activity_finish);

			// Custom typeface
			Typeface tf = Typeface.CreateFromAsset(Assets, "exotwomedium.otf");

			topTen = FindViewById<ListView>(Resource.Id.topTen);
			adapter = new ScoreboardAdapter(this, Resource.Layout.score_row_template, top10);
			topTen.Adapter = adapter;
			Button resetButton = FindViewById<Button>(Resource.Id.resetButton);
			Button newButton = FindViewById<Button>(Resource.Id.newButton);
			resetButton.SetTypeface(tf, TypefaceStyle.Normal);
			newButton.SetTypeface(tf, TypefaceStyle.Normal);
			var title = FindViewById<TextView>(Resource.Id.appTitle);
			title.SetTypeface(tf, TypefaceStyle.Normal);

			newButton.Click += delegate
			{
				ScoreKeeper.SaveTopTen(top10);
				var newGame = new Intent(this, typeof(MainActivity));
				StartActivity(newGame);
			};

			resetButton.Click += delegate
			{
				ScoreKeeper.ClearSP();
				var refresh = new Intent(this, typeof(FinishActivity));
				StartActivity(refresh);
			};
		}
	}
}