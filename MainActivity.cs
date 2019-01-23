using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android.Views;
using Android.Graphics;

namespace WorldFlagQuiz
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]//"@style/AppTheme"
	public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
			base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.activity_main);

			Typeface tf = Typeface.CreateFromAsset(Assets, "exotwomedium.otf");

			var nameLabel = FindViewById<TextView>(Resource.Id.nameLabel);
			nameLabel.SetTypeface(tf, TypefaceStyle.Normal);

			Button startButton = FindViewById<Button>(Resource.Id.startButton);
			startButton.SetTypeface(tf, TypefaceStyle.Normal);
			startButton.Enabled = false;

			EditText playerName = FindViewById<EditText>(Resource.Id.nameBox);
			playerName.SetTypeface(tf, TypefaceStyle.Normal);
			//
			playerName.TextChanged += delegate
			{
				startButton.Enabled = true;
			};

			//
			startButton.Click += delegate
			{
				Intent secondIntent = new Intent(this, typeof(GameActivity));
				secondIntent.PutExtra("player", playerName.Text);
				StartActivity(secondIntent);
			};
		}
	}
}