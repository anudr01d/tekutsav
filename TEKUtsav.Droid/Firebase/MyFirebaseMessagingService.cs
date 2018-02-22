using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Util;
using Firebase.Messaging;
using System.Collections.Generic;
using Android.OS;
using Xamarin.Forms;
using Android.Graphics;

namespace TEKUtsav.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";
        public override void OnMessageReceived(RemoteMessage message)
        {

            IDictionary<String, String> data = message.Data;
            String title = data["title"];

            Log.Debug(TAG, "From: " + message.From);
            Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);
            SendNotification(title, message.GetNotification().Body, message.Data);
        }

        void SendNotification(string messageFrom, string messageBody, IDictionary<string, string> data)
        {
            /*
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);

            Bundle bundle = new Bundle();
            bundle.PutString("pageParameter", "01");
            intent.PutExtras(bundle);

            foreach (string key in data.Keys)
            {
                intent.PutExtra(key, data[key]);
            }
            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

            var notificationBuilder = new Notification.Builder(this)
                .SetSmallIcon(Resource.Drawable.ic_stat_ic_notification)
                .SetContentTitle(messageFrom)
                .SetContentText(messageBody)
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent);

            var notificationManager = NotificationManager.FromContext(this);
            notificationManager.Notify(0, notificationBuilder.Build());
            */

            Notification.Builder builder = new Notification.Builder(this);
            Intent intent = new Intent(this, typeof(MainActivity));

            Bundle bundle = new Bundle();
            bundle.PutString("pageParameter", "01");
            intent.PutExtras(bundle);

            PendingIntent pIntent = PendingIntent.GetActivity(this, 0, intent, 0);
            builder.SetContentTitle(messageFrom)
                   .SetLargeIcon(BitmapFactory.DecodeResource(Resources, Resource.Drawable.ic_launcher))
                   .SetSmallIcon(Resource.Drawable.ic_stat_ic_notification)
                .SetContentText(messageBody)
                   .SetAutoCancel(true);

            var notificationManager = NotificationManager.FromContext(this);
            notificationManager.Notify(0, builder.Build());
            //var manager = (NotificationManager)this.GetSystemService("notification");
            //manager.Notify(1, builder.Build());

        }
    }
}
