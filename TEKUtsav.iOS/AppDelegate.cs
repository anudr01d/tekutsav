using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Foundation;
using TEKUtsav.Infrastructure.CookieStorage;
using TEKUtsav.Infrastructure.Logging;
using TEKUtsav.Infrastructure.Settings;
using TEKUtsav.iOS.DeviceImpl;
using UIKit;
using Firebase.CloudMessaging;
using Firebase.InstanceID;
using UserNotifications;
using Firebase.Core;
using CarouselView.FormsPlugin.iOS;


namespace TEKUtsav.iOS
{
	[Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate,IUNUserNotificationCenterDelegate, IMessagingDelegate
	{
        public event EventHandler<UserInfoEventArgs> NotificationReceived;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
            UIApplication.SharedApplication.RegisterForRemoteNotifications();

			global::Xamarin.Forms.Forms.Init();
            CarouselViewRenderer.Init();

            var x = typeof(Behaviors.EventHandlerBehavior);

			//Azure services
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

			//Zxing barcode scanning lib
			global::ZXing.Net.Mobile.Forms.iOS.Platform.Init();

			TimeZoneInfo.GetSystemTimeZones();
			var builder = new ContainerBuilder();

			RegisterDeviceSpecificImpl(builder);
			var TEKUtsavApp = new App(builder);

            // Monitor token generation
            InstanceId.Notifications.ObserveTokenRefresh(TokenRefreshNotification); 
            ////Firebase implementation////
             // get permission for notification
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                // iOS 10
                var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
                UNUserNotificationCenter.Current.RequestAuthorization(authOptions, (granted, error) =>
                {
                    Console.WriteLine(granted);
                });

                // For iOS 10 display notification (sent via APNS)
                UNUserNotificationCenter.Current.Delegate = this;
            }
            else
            {

                var allNotificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
                var settings = UIUserNotificationSettings.GetSettingsForTypes(allNotificationTypes, null);


                UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            }

            UIApplication.SharedApplication.RegisterForRemoteNotifications();

            // Firebase component initialize
            Firebase.Core.App.Configure();

            Firebase.InstanceID.InstanceId.Notifications.ObserveTokenRefresh((sender, e) =>
            {
                var newToken = Firebase.InstanceID.InstanceId.SharedInstance.Token;
                // if you want to send notification per user, use this token
                System.Diagnostics.Debug.WriteLine(newToken);

                connectFCM();
            });
            //////
			LoadApplication(TEKUtsavApp);

			CurrentDomain_UnhandledException(App.AppLogger);

			return base.FinishedLaunching(app, options);
		}
        public override void DidEnterBackground(UIApplication application)         {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
            Messaging.SharedInstance.Disconnect();             System.Diagnostics.Debug.WriteLine("Disconnected from FCM");         }
        public override void OnActivated(UIApplication uiApplication)
        {
            connectFCM();
            base.OnActivated(uiApplication);
        }
        public void DidRefreshRegistrationToken(Messaging messaging, string fcmToken)
        {
            throw new NotImplementedException();
        }
        private void connectFCM()
        {
            Messaging.SharedInstance.Connect((error) =>
            {
                if (error == null)
                {
                    //TODO: Change Topic to what is required
                    Messaging.SharedInstance.Subscribe("/topics/news");
                }
                System.Diagnostics.Debug.WriteLine(error != null ? "error occured" : "connect success");
            });
        }         public override void WillEnterForeground(UIApplication application)         {             ConnectToFCM(this.Window.RootViewController);         }
        // To receive notifications in foregroung on iOS 9 and below.         // To receive notifications in background in any iOS version         public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)         {             // If you are receiving a notification message while your app is in the background,             // this callback will not be fired 'till the user taps on the notification launching the application.              // If you disable method swizzling, you'll need to call this method.              // This lets FCM track message delivery and analytics, which is performed             // automatically with method swizzling enabled.             //Messaging.GetInstance ().AppDidReceiveMessage (userInfo);             if (NotificationReceived == null)                 return;              var e = new UserInfoEventArgs { UserInfo = userInfo };             NotificationReceived(this, e);              if (application.ApplicationState == UIApplicationState.Active)             {                 System.Diagnostics.Debug.WriteLine(userInfo);                 var aps_d = userInfo["aps"] as NSDictionary;                 var alert_d = aps_d["alert"] as NSDictionary;                 var body = alert_d["body"] as NSString;                 var title = alert_d["title"] as NSString;                  System.Diagnostics.Debug.WriteLine($"---> push title={title} , body{body} ");             }         }          public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
#if DEBUG
            Firebase.InstanceID.InstanceId.SharedInstance.SetApnsToken(deviceToken, Firebase.InstanceID.ApnsTokenType.Sandbox);
#endif
#if RELEASE
            Firebase.InstanceID.InstanceId.SharedInstance.SetApnsToken(deviceToken, Firebase.InstanceID.ApnsTokenType.Prod);
#endif
        }
          // To receive notifications in foreground on iOS 10 devices.         [Export("userNotificationCenter:willPresentNotification:withCompletionHandler:")]         public void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)         {             if (NotificationReceived == null)                 return;              var e = new UserInfoEventArgs { UserInfo = notification.Request.Content.UserInfo };             NotificationReceived(this, e);              var title = notification.Request.Content.Title;             var body = notification.Request.Content.Body;                          System.Diagnostics.Debug.WriteLine($"---> push title={title} , body{body} " );         }          /// WORKAROUND         #region Workaround for handling notifications in background for iOS 10          [Export("userNotificationCenter:didReceiveNotificationResponse:withCompletionHandler:")]         public void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)         {             if (NotificationReceived == null)                 return;              var e = new UserInfoEventArgs { UserInfo = response.Notification.Request.Content.UserInfo };             NotificationReceived(this, e);                          System.Diagnostics.Debug.WriteLine("--->get message " + response.Notification.Date);         }          #endregion         /// END OF WORKAROUND                   void TokenRefreshNotification(object sender, NSNotificationEventArgs e)         {             // This method will be fired everytime a new token is generated, including the first             // time. So if you need to retrieve the token as soon as it is available this is where that             // should be done.             //var refreshedToken = InstanceId.SharedInstance.Token;              ConnectToFCM();              // TODO: If necessary send token to application server.         }          public static void ConnectToFCM(UIViewController fromViewController)         {             Messaging.SharedInstance.Connect(error =>             {                 if (error != null)                 {                     System.Diagnostics.Debug.WriteLine("---> Unable to connect to FCM: " + error.LocalizedDescription);                 }                 else                 {                     System.Diagnostics.Debug.WriteLine("--->  Success! Connected to FCM");                     System.Diagnostics.Debug.WriteLine($"Token: {InstanceId.SharedInstance.Token} ");                      //TODO: Change Topic to what is required                     Messaging.SharedInstance.Subscribe("/topics/news");                 }             });         }          public static void ConnectToFCM()         {             Messaging.SharedInstance.Connect(error =>             {                 if (error != null)                 {                     System.Diagnostics.Debug.WriteLine("Unable to connect to FCM " + error.LocalizedDescription);                 }                 else                 {                     System.Diagnostics.Debug.WriteLine("Success! Connected to FCM");                     System.Diagnostics.Debug.WriteLine($"Token: {InstanceId.SharedInstance.Token} ");                      //TODO: Change Topic to what is required                     Messaging.SharedInstance.Subscribe("/topics/news");                 }             });         }         public class UserInfoEventArgs : EventArgs
        {
            public NSDictionary UserInfo { get; set; }
        } 
		private void CurrentDomain_UnhandledException(ILogger logger)
		{
			AppDomain.CurrentDomain.UnhandledException += (object sender, UnhandledExceptionEventArgs e) =>
			{
				var exception = e.ExceptionObject as Exception;
				logger.LogUnhandledExceptionAsync(exception);
			};

			TaskScheduler.UnobservedTaskException += (object sender, UnobservedTaskExceptionEventArgs e) =>
			{
				var exception = e.Exception as Exception;
				logger.LogUnhandledExceptionAsync(exception);
			};
		}

		private void RegisterDeviceSpecificImpl(ContainerBuilder builder)
		{
			builder.RegisterType<SettingProviderIos>().As<ISettings>();
			builder.RegisterType<IOSCookieStore>().As<IPlatformCookieStore>();

		}
	}
}
