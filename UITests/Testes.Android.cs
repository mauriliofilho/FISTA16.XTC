using NUnit.Framework;
using Xamarin.UITest;

namespace FISTA16.Demo.UITests
{
	[TestFixture (Platform.Android)]
	public class Tests_Android
	{
		IApp app;
		Platform platform;

		public Tests_Android (Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest ()
		{
			app = AppInitializer.StartApp (platform);
		}

		//[Test]
		public void InvokeREPL()
		{
			// Invoke the REPL so that we can explore the user interface
			app.Repl();
		}

		[Test]
		public void ScreenshotSample ()
		{
			app.Screenshot ("First screen.");
		}

		[Test]
		public void VerifyUserProfile_UserValid()
		{
			app.WaitForElement(c => c.Marked("action_bar_title").Text("User Profile Form"));

			app.EnterText(c => c.Marked("NameEntry"),"Sara Silva");

			app.EnterText(c => c.Marked("MobileNumberEntry"),"123456789");

			app.Tap(c=>c.Marked("CheckUser"));

			app.WaitForElement(c => c.Marked("FeedbackLabel").Text("User valid!"));
		}

		[Test]
		public void VerifyUserProfile_MobileNumberIsTooLong()
		{

			app.WaitForElement(c => c.Marked("action_bar_title").Text("User Profile Form"));

			app.EnterText(c => c.Marked("NameEntry"),"Sara Silva");

			app.EnterText(c => c.Marked("MobileNumberEntry"),"1234567890");

			app.Tap(c=>c.Marked("CheckUser"));

			//var query= app.Query(c => c.Marked("FeedbackLabel"));

			app.WaitForElement(c => c.Marked("FeedbackLabel").Text("The mobile number is too long."));
		}

		[Test]
		public void VerifyUserProfile_MobileNumberIsTooShort()
		{

			app.WaitForElement(c => c.Marked("action_bar_title").Text("User Profile Form"));

			app.EnterText(c => c.Marked("NameEntry"),"Sara Silva");

			app.EnterText(c => c.Marked("MobileNumberEntry"),"12345678");

			app.Tap(c=>c.Marked("CheckUser"));

			app.WaitForElement(c => c.Marked("FeedbackLabel").Text("The mobile number is too short."));
		}

		[Test]
		public void VerifyUserProfile_MobileNumberOnlyAcceptNumbers()
		{

			app.WaitForElement(c => c.Marked("action_bar_title").Text("User Profile Form"));

			app.EnterText(c => c.Marked("NameEntry"),"Sara Silva");

			app.EnterText(c => c.Marked("MobileNumberEntry"),"ABC");

			app.Tap(c=>c.Marked("CheckUser"));

			app.WaitForElement(c => c.Marked("FeedbackLabel").Text("The mobile number only accept numbers."));
		}

		[Test]
		public void VerifyUserProfile_MobileNumberMustBeDefined()
		{

			app.WaitForElement(c => c.Marked("action_bar_title").Text("User Profile Form"));

			app.EnterText(c => c.Marked("NameEntry"),"Sara Silva");

			app.Tap(c=>c.Marked("CheckUser"));

			app.WaitForElement(c => c.Marked("FeedbackLabel").Text("The mobile number must be defined."));
		}

		[Test]
		public void VerifyUserProfile_UserMustHaveName()
		{

			app.WaitForElement(c => c.Marked("action_bar_title").Text("User Profile Form"));

			app.EnterText(c => c.Marked("MobileNumberEntry"),"123456789");

			app.Tap(c=>c.Marked("CheckUser"));

			app.WaitForElement(c => c.Marked("FeedbackLabel").Text("The user must have a name. "));
		}
	}
}

