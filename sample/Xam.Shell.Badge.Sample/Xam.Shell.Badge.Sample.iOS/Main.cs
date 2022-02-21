using UIKit;

namespace Xam.Shell.Badge.Sample.iOS
{
    public class Application
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        protected Application() { }

        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));
        }
    }
}