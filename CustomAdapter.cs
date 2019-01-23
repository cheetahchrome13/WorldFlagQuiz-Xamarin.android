using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;// to access Assets folder
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WorldFlagQuiz
{
	class CustomAdapter : ArrayAdapter
	{
		private Context context;
		private readonly List<Question> pageData;
		private Game round;							
		private LayoutInflater inflater;
		private readonly int resource;
		private bool isCorrect;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="resource"></param>
		/// <param name="pageData"></param>
		/// <param name="round"></param>
		public CustomAdapter(Context context, int resource, List<Question> pageData, Game round) : base(context, resource, pageData)
		{
			this.context = context;
			this.resource = resource;
			this.round = round;
			this.pageData = pageData;
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

			Container container = new Container(convertView)
			{
				Answer1 = { Text = pageData[position].Answers[0] },
				Answer2 = { Text = pageData[position].Answers[1] },
				Answer3 = { Text = pageData[position].Answers[2] },
				Answer4 = { Text = pageData[position].Answers[3] },
				Correct = { Text = " " },
				//Correct = { Text = pageData[position].CorrectAnswer } <---CHEATER
			};

			container.FlagImage.SetImageResource(pageData[position].Image);

			// click handlers
			container.Answer1.Click += AnswerClick;
			container.Answer2.Click += AnswerClick;
			container.Answer3.Click += AnswerClick;
			container.Answer4.Click += AnswerClick;

			//// attempt at font
			Typeface tf = Typeface.CreateFromAsset(context.Assets, "exotwomedium.otf");
			container.Answer1.SetTypeface(tf, TypefaceStyle.Normal);
			container.Answer2.SetTypeface(tf, TypefaceStyle.Normal);
			container.Answer3.SetTypeface(tf, TypefaceStyle.Normal);
			container.Answer4.SetTypeface(tf, TypefaceStyle.Normal);
			container.Correct.SetTypeface(tf, TypefaceStyle.Normal);

			// Single click handler for all buttons
			void AnswerClick(object sender, EventArgs e)
			{
				// Re-cast sender to Button
				Button answer = sender as Button;

				isCorrect = answer.Text == pageData[position].CorrectAnswer;

				if (isCorrect)
				{
					container.Correct.SetTextColor(Android.Graphics.Color.Turquoise);
					container.Correct.SetText("CORRECT!", TextView.BufferType.Normal);
					int s = Convert.ToInt32(round.Score);
					s++;
					round.Score = s.ToString();
					GameActivity.wrongButton.Text = ((GameActivity.currentPage + 1) - Convert.ToInt32(round.Score)).ToString();
					GameActivity.rightButton.Text = round.Score;
					FX.WeighIn(context, isCorrect);
				}
				else
				{
					container.Correct.SetTextColor(Android.Graphics.Color.Rgb(255, 0, 102));
					container.Correct.SetText("INCORRECT!", TextView.BufferType.Normal);
					GameActivity.wrongButton.Text = (GameActivity.currentPage - Convert.ToInt32(round.Score) + 1).ToString();
					GameActivity.rightButton.Text = round.Score;
					FX.WeighIn(context, isCorrect);
				}

				if (GameActivity.currentPage != 9)
				{
					GameActivity.nextButton.Enabled = true;
				}
				else
				{
					GameActivity.finishButton.Enabled = true;
				}

				container.Answer1.Enabled = false;
				container.Answer2.Enabled = false;
				container.Answer3.Enabled = false;
				container.Answer4.Enabled = false;

				// Nested ternary logic for button background drawables and text colors
				//Answer1
				container.Answer1.SetTextColor(container.Answer1.Text == pageData[position].CorrectAnswer ?
					Android.Graphics.Color.Turquoise : Android.Graphics.Color.Rgb(255, 0, 102));
				container.Answer1.SetBackgroundResource(container.Answer1.Text == pageData[position].CorrectAnswer ?
					(answer == container.Answer1 ? Resource.Drawable.Xgreenclicked : Resource.Drawable.Xgreen) : 
					(answer == container.Answer1 ? Resource.Drawable.Xredclicked : Resource.Drawable.Xred));
				// Answer2
				container.Answer2.SetTextColor(container.Answer2.Text == pageData[position].CorrectAnswer ?
					Android.Graphics.Color.Turquoise : Android.Graphics.Color.Rgb(255, 0, 102));
				container.Answer2.SetBackgroundResource(container.Answer2.Text == pageData[position].CorrectAnswer ?
					(answer == container.Answer2 ? Resource.Drawable.Xgreenclicked : Resource.Drawable.Xgreen) : 
					(answer == container.Answer2 ? Resource.Drawable.Xredclicked : Resource.Drawable.Xred));
				//Answer3
				container.Answer3.SetTextColor(container.Answer3.Text == pageData[position].CorrectAnswer ?
					Android.Graphics.Color.Turquoise : Android.Graphics.Color.Rgb(255, 0, 102));
				container.Answer3.SetBackgroundResource(container.Answer3.Text == pageData[position].CorrectAnswer ?
					(answer == container.Answer3 ? Resource.Drawable.Xgreenclicked : Resource.Drawable.Xgreen) :
					(answer == container.Answer3 ? Resource.Drawable.Xredclicked : Resource.Drawable.Xred));
				// Answer4
				container.Answer4.SetTextColor(container.Answer4.Text == pageData[position].CorrectAnswer ?
					Android.Graphics.Color.Turquoise : Android.Graphics.Color.Rgb(255, 0, 102));
				container.Answer4.SetBackgroundResource(container.Answer4.Text == pageData[position].CorrectAnswer ?
					(answer == container.Answer4 ? Resource.Drawable.Xgreenclicked : Resource.Drawable.Xgreen) : 
					(answer == container.Answer4 ? Resource.Drawable.Xredclicked : Resource.Drawable.Xred));
			}

			// Listen for "next" button click
			GameActivity.nextButton.Click += delegate
			{
				container.Answer1.Enabled = true;
				container.Answer2.Enabled = true;
				container.Answer3.Enabled = true;
				container.Answer4.Enabled = true;
				container.Correct.SetText("", TextView.BufferType.Normal);
			};

			return convertView;
		}
	}
}