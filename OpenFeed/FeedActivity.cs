using Android.App;
using Android.Widget;
using Android.OS;

namespace OpenFeed
{
	[Activity(Label = "OpenFeed", MainLauncher = true, Icon = "@drawable/icon")]
	public class FeedActivity : ListActivity
	{
		private RssItem[] _items;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			using (var client = new HttpClient())
			{
				var xmlFeed = await client.GetStringAsync("http://blog.xamarin.com/feed/");
				var doc = XDocument.Parse(xmlFeed);
				XNamespace dc = "http:/purl.org/dc/element/1.1/";

				_items =
			}
		}
	}
}


