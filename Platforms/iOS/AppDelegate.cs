using Foundation;
using Microsoft.Extensions.Logging;
using UIKit;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace MauiWindowingTest
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public override bool FinishedLaunching(UIApplication app, NSDictionary? options) => 
            base.FinishedLaunching(app, options);
    }
}
