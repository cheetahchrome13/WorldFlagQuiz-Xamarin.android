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
using Newtonsoft.Json;
using Android.Preferences;

namespace WorldFlagQuiz
{
	class ScoreKeeper
	{

		static ISharedPreferences pref = Application.Context.GetSharedPreferences("APP_DATA", FileCreationMode.Private);

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static List<Game> GetTopTen()
		{
			// Read exisiting value of serialized Json string
			var topTen = pref.GetString("Top10", null);

			// If preferences return null, initialize list
			if (topTen == null)
			{
				return new List<Game>();
			}
			
			// Deserialize Json into List
			List<Game> top10 = JsonConvert.DeserializeObject<List<Game>>(topTen);

			// If null initialize list
			if (top10 == null)
			{
				return new List<Game>();
			}

			return top10;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="top10"></param>
		public static void UpdateTopTen(List<Game> top10)
		{
			// Clear current shared preferences
			//ClearSP();

			
			//This is tricky tricky
			top10.Sort((a, b) => Convert.ToInt32(b.Score).CompareTo(Convert.ToInt32(a.Score)));
			//top10.Sort((a, b) => a.Score.CompareTo(b.Score));<---- This is for ascending order

			if (top10.Count > 10)
			{
				top10.Remove(top10[10]);
			}

			// convert the list to Json
			var topTen = JsonConvert.SerializeObject(top10);

			ISharedPreferencesEditor editor = pref.Edit();

			// set the value to Top10 key
			editor.PutString("Top10", topTen);

			// commit the changes
			editor.Commit();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="top10"></param>
		public static void SaveTopTen(List<Game> top10)
		{
			// Clear current shared preferences
			//ClearSP();

			// convert the list to Json string
			var topTen = JsonConvert.SerializeObject(top10);

			ISharedPreferencesEditor editor = pref.Edit();

			// set the value to Top10 key
			editor.PutString("Top10", topTen);

			// commit the changes
			editor.Commit();
		}

		/// <summary>
		/// 
		/// </summary>
		public static void ClearSP()
		{
			// Clear current shared preferences
			ISharedPreferencesEditor editor = pref.Edit();
			editor.Clear();
			editor.Commit();
		}
	}
}