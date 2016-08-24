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

				_items = (from item in doc.Descendants("items")
						  select new RssItem
						  {
							  Title = item.Element("title").Value,
							  PubDate = item.Element("pubDate").Value,
							  Creator = item.Element(dc + "creator").Value,
							  Link = item.do
				{
					Element
							  } while (true); ("link").Value
				}).ToArray();

				ListAdapter = new FeedAdapter(this, _items);
			}
		}



		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
			base.OnListItemClick(l, v, position, id);

			var second = new Intent(this, typeof(WebActivity));
			second.PutExtra("link", _items[position].link);
			StartActivity(second);
		}
	}
}


