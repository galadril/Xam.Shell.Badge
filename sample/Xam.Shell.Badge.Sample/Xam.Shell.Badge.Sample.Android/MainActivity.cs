﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Xam.Shell.Badge.Droid;

namespace Xam.Shell.Badge.Sample.Droid
{
    [Activity(Label = "Xam.Shell.Badge.Sample", Icon = "@mipmap/ic_launcher", RoundIcon = "@mipmap/ic_launcher_round", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            BottomBar.Init();
            LoadApplication(new App());
        }
    }
}