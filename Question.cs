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
	class Question
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="correctAnswer"></param>
		/// <param name="answers"></param>
		/// <param name="image"></param>
		public Question(string correctAnswer, List<string> answers, int image)
		{
			this.CorrectAnswer = correctAnswer;
			this.Answers = answers;
			this.Image = image;
		}

		/// <summary>
		/// 
		/// </summary>
		public string CorrectAnswer { get; private set; }
		public List<string> Answers { get; private set; }
		public int Image { get; private set; }
	}
}