using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FISTA16.Demo.UITests
{
	[TestFixture (Platform.Android)]
	[TestFixture (Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests (Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest ()
		{
			app = AppInitializer.StartApp (platform);
		}

		[Test]
		public void TakeScreenshot ()
		{
			AppResult[] results = null;

			if (platform==Platform.Android) 
			{
				results = app.WaitForElement (c => c.Marked ("User Profile Form"));
			} 
			else 
			{
				results = app.WaitForElement(c=>c.Class("UINavigationBar").Marked("User Profile Form"));
			}

			app.Screenshot ("Welcome screen.");

			Assert.IsTrue (results.Any ());
		}

		[Test]
		public void CallREPL ()
		{
			app.Repl ();
		}
	}
}

