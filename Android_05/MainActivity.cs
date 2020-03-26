using System;
using System.Drawing;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Android_05
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            CheckBox checkbox = FindViewById<CheckBox>(Resource.Id.checkbox01);

            checkbox.Click += (o, e) => {
                if (checkbox.Checked)
                    Toast.MakeText(this, "Selected", ToastLength.Short).Show();
                else
                    Toast.MakeText(this, "Not selected", ToastLength.Short).Show();
            };

            ImageView imageview01 = FindViewById<ImageView>(Resource.Id.image01);

            VideoView videoView = FindViewById<VideoView>(Resource.Id.videoView1);
            var uri = Android.Net.Uri.Parse("https://file-examples.com/wp-content/uploads/2017/04/file_example_MP4_480_1_5MG.mp4");
            videoView.SetVideoURI(uri);
            videoView.Visibility = ViewStates.Visible;
            videoView.Start();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            

            Snackbar.Make(view, "Hey you clicked here", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

