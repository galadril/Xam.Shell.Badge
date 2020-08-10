using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Xam.Shell.Badge.Sample.iOS
{
   public class Application
   {
      #region Constructor & Destructor

      /// <summary>
      /// Default constructor
      /// </summary>
      protected Application()
      { }

      #endregion

      // This is the main entry point of the application.
      static void Main(string[] args)
      {
         // if you want to use a different Application Delegate class from "AppDelegate"
         // you can specify it here.
         UIApplication.Main(args, null, "AppDelegate");
      }
   }
}
