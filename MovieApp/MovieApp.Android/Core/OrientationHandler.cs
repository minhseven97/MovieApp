using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MovieApp.Core;
using MovieApp.Droid.Core;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(OrientationHandler))]
namespace MovieApp.Droid.Core
{
    public class OrientationHandler : IOrientationHandler
    {
        [Obsolete]
        public void ForceLandscape()
        {
            ((Activity)Forms.Context).RequestedOrientation = ScreenOrientation.Landscape;
        }

        [Obsolete]
        public void ForcePortrait()
        {
            ((Activity)Forms.Context).RequestedOrientation = ScreenOrientation.Portrait;
        }
    }
}