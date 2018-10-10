using System;
using Ninject.Modules;
using TripLog.Droid.Services;
using TripLog.Services;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TripLog.Droid.Modules
{
    public class TripLogPlatformModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILocationService>().To<LocationService>().InSingletonScope();
        }
    }
}