using System;

using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HelloWorld
{
	[BroadcastReceiver(Label = "Hello World")]
	[IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
	[MetaData("android.appwidget.provider", Resource = "@xml/widget_provider")]
	public class AppWidget : AppWidgetProvider
	{
		private static int count = 0;

		public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
		{
			ComponentName me = new ComponentName(context, Java.Lang.Class.FromType(typeof(AppWidget)).Name);

			appWidgetManager.UpdateAppWidget(me, BuildUpdate(context, appWidgetIds));
		}

		private RemoteViews BuildUpdate(Context context, int[] appWidgetIds)
		{
			RemoteViews updateViews = new RemoteViews(context.PackageName, Resource.Layout.widget);

			Intent i = new Intent(context, typeof(AppWidget));
			i.SetAction(AppWidgetManager.ActionAppwidgetUpdate);
			i.PutExtra(AppWidgetManager.ExtraAppwidgetIds, appWidgetIds);

			PendingIntent pi = PendingIntent.GetBroadcast(context, 0, i, PendingIntentFlags.UpdateCurrent);

			count = count + 1;
			string strCount = count.ToString();
			updateViews.SetTextViewText(Resource.Id.textView1, strCount);
			updateViews.SetOnClickPendingIntent(Resource.Id.background, pi);

			return (updateViews);
		}
	}
}