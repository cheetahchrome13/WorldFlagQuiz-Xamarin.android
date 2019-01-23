using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WorldFlagQuiz
{
	class ScoreboardAdapter : ArrayAdapter
	{
		private Context context;
		private List<Game> top10;
		private LayoutInflater inflater;
		private readonly int resource;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="resource"></param>
		/// <param name="top10"></param>
		public ScoreboardAdapter(Context context, int resource, List<Game> top10) : base(context, resource, top10)
		{
			this.context = context;
			this.resource = resource;
			this.top10 = top10;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="position"></param>
		/// <param name="convertView"></param>
		/// <param name="parent"></param>
		/// <returns></returns>
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			if (inflater == null)
			{
				inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
			}

			if (convertView == null)
			{
				convertView = inflater.Inflate(resource, parent, false);
			}

			ScoreContainer scoreContainer = new ScoreContainer(convertView)
			{
				Player = { Text = top10[position].Player },
				Score = { Text = top10[position].Score }
			};

			Typeface tf = Typeface.CreateFromAsset(context.Assets, "exotwomedium.otf");
			scoreContainer.Player.SetTypeface(tf, TypefaceStyle.Normal);
			scoreContainer.Score.SetTypeface(tf, TypefaceStyle.Normal);

			return convertView;
		}
	}
}