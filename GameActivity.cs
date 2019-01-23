using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace WorldFlagQuiz
{
	[Activity(Label = "GameActivity")]
	class GameActivity : Activity
	{
		private Random random = new Random();
		private const int Count = 4;
		private const int GameCount = 10;
		private const int Min = 0;
		private const int Max = 250;
		private const int TotalPages = Paginator.TotalQuestions;
		private CustomAdapter adapter;
		private ListView lv;
		private TextView title;
		public static Button nextButton, finishButton, rightButton, wrongButton;
		private readonly Paginator paginator = new Paginator();
		private MasterList master = new MasterList();
		private Game game;
		public static int currentPage = 0;

		internal List<Question> Round { get; set; }

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.activity_game);

			// use custom font
			Typeface tf = Typeface.CreateFromAsset(Assets, "exotwomedium.otf");

			// Get a random List of 10 unique random integers 0-9
			List<int> seedList = GetRandomList();

			// Use seedList to get the correct answer List
			List<string> correct = GetCorrectList(seedList);

			// Use seedList to get the image List
			List<int> image = GetImageList(seedList);

			this.InitializeViews();

			// Create a game round
			Round = CreateRound(correct, seedList, image);
			string player = this.Intent.GetStringExtra("player");
			string score = "0";
			game = new Game(player, score);//Round, 

			//  
			finishButton.SetTypeface(tf, TypefaceStyle.Normal);
			nextButton.SetTypeface(tf, TypefaceStyle.Normal);
			title.SetTypeface(tf, TypefaceStyle.Normal);
			wrongButton.SetTypeface(tf, TypefaceStyle.Normal);
			rightButton.SetTypeface(tf, TypefaceStyle.Normal);
			title.Text = "Question " + (currentPage + 1);
			wrongButton.Text = currentPage.ToString();
			rightButton.Text = currentPage.ToString();

			// Bind first page and use Lists to create a List<Question> of 10 Question objects
			adapter = new CustomAdapter(this, Resource.Layout.row_template, paginator.GeneratePage(currentPage, Round), game);
			lv.Adapter = adapter;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="correct"></param>
		/// <param name="seed"></param>
		/// <param name="image"></param>
		/// <returns></returns>
		private List<Question> CreateRound(List<string> correct, List<int> seed, List<int> image)
		{
			Round = new List<Question>()
			{
				new Question(correct[0], GetAnswerList(seed[0]), image[0]),
				new Question(correct[1], GetAnswerList(seed[1]), image[1]),
				new Question(correct[2], GetAnswerList(seed[2]), image[2]),
				new Question(correct[3], GetAnswerList(seed[3]), image[3]),
				new Question(correct[4], GetAnswerList(seed[4]), image[4]),
				new Question(correct[5], GetAnswerList(seed[5]), image[5]),
				new Question(correct[6], GetAnswerList(seed[6]), image[6]),
				new Question(correct[7], GetAnswerList(seed[7]), image[7]),
				new Question(correct[8], GetAnswerList(seed[8]), image[8]),
				new Question(correct[9], GetAnswerList(seed[9]), image[9])	
			};
	
			return Round;
		}

		/// <summary>
		/// 
		/// </summary>
		private void InitializeViews()
		{
			nextButton = FindViewById<Button>(Resource.Id.nextButton);
			finishButton = FindViewById<Button>(Resource.Id.prevButton);
			title = FindViewById<TextView>(Resource.Id.appTitle1);
			wrongButton = FindViewById<Button>(Resource.Id.scoreNegative);
			rightButton = FindViewById<Button>(Resource.Id.scorePositive);
			lv = FindViewById<ListView>(Resource.Id.listView1);
			finishButton.Enabled = false;
			finishButton.Visibility = ViewStates.Gone;
			nextButton.Enabled = false;
			wrongButton.Enabled = false;
			rightButton.Enabled = false;

			// Button clicks
			nextButton.Click += NextBtn_Click;
			finishButton.Click += FinishBtn_Click;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void FinishBtn_Click(object sender, System.EventArgs e)
		{
			currentPage = 0;
			List<Game> top10 = ScoreKeeper.GetTopTen();
			top10.Add(game);
			ScoreKeeper.UpdateTopTen(top10);
			//var scores = JsonConvert.SerializeObject(top10);

			//open the second activity
			var finish = new Intent(this, typeof(FinishActivity));
			StartActivity(finish);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void NextBtn_Click(object sender, System.EventArgs e)
		{
			currentPage += 1;
			lv.Adapter = new CustomAdapter(this, Resource.Layout.row_template, paginator.GeneratePage(currentPage, Round), game);
			title.Text = "Question " + (currentPage + 1);
			wrongButton.Text = (currentPage - Convert.ToInt32(game.Score)).ToString();
			rightButton.Text = game.Score;
			ToggleButtons();
		}

		/// <summary>
		/// 
		/// </summary>
		public void ToggleButtons()
		{
			if (currentPage == TotalPages - 1)
			{
				nextButton.Enabled = false;
				nextButton.Visibility = ViewStates.Gone;
				finishButton.Visibility = ViewStates.Visible;
			}
			else
				if (currentPage >= 0 && currentPage < TotalPages - 1)
			{
				nextButton.Enabled = false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="current"></param>
		/// <returns></returns>
		public List<string> GetAnswerList(int current)
		{
			List<string> answerList = new List<string>();

			List<int> randomList = GetRandomList(current);

			for (int i = 0; i < Count; i++)
			{
				answerList.Add(master.Names[randomList[i]]);
			}

			return answerList;
		}


		/// <summary>
		///  Overloaded GetRandomList method
		/// </summary>
		/// <param name="current"></param>
		/// <returns></returns>
		public List<int> GetRandomList(int current)
		{
			// create a hash set
			HashSet<int> hash = new HashSet<int>
			{
				// add current index to hash set
				current
			};

			while (hash.Count < Count)
			{
				hash.Add(random.Next(Min, Max));
			}

			// load them in to a list, to sort
			List<int> result = hash.ToList();

			// shuffle the results
			for (int i = result.Count - 1; i > 0; i--)
			{
				int k = random.Next(i + 1);
				int tmp = result[k];
				result[k] = result[i];
				result[i] = tmp;
			}

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private List<int> GetRandomList()
		{
			// create a hash set
			HashSet<int> hash = new HashSet<int>();

			while (hash.Count < GameCount)
			{
				hash.Add(random.Next(Min, Max));
			}

			// load them in to a list, to sort
			List<int> result = hash.ToList();

			// shuffle the results
			for (int i = result.Count - 1; i > 0; i--)
			{
				int k = random.Next(i + 1);
				int tmp = result[k];
				result[k] = result[i];
				result[i] = tmp;
			}

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="seedList"></param>
		/// <returns></returns>
		public List<string> GetCorrectList(List<int> seedList)
		{
			List<string> correctList = new List<string>();

			for (int i = 0; i < GameCount; i++)
			{
				correctList.Add(master.Names[seedList[i]]);
			}

			return correctList;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="seedList"></param>
		/// <returns></returns>
		public List<int> GetImageList(List<int> seedList)
		{
			List<int> imageList = new List<int>();

			for (int i = 0; i < GameCount; i++)
			{
				imageList.Add(master.Images[seedList[i]]);
			}

			return imageList;
		}
	}
}

