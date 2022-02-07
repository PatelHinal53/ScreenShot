using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.IO;
using Xamarin.Essentials;

namespace ScreenshotDemo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class ScreenshotActivity : AppCompatActivity
    {
        private Button _Screenshotbutton;
        private ImageView _imageView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            UIReferences();
            UIClickEvents();
        }

        private void UIReferences()
        {
            _Screenshotbutton = FindViewById<Button>(Resource.Id.Screenshotbutton);
            _imageView = FindViewById<ImageView>(Resource.Id.imageView);
        }

        private void UIClickEvents()
        {
            _Screenshotbutton.Click += Screenshotbutton_Click;
            
        }

        private async void Screenshotbutton_Click(object sender, EventArgs e)
        {
            var screenshot = await Screenshot.CaptureAsync();
            var stream = await screenshot.OpenReadAsync();
            _imageView.SetImageBitmap(BitmapFactory.DecodeStream(stream));
            
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}