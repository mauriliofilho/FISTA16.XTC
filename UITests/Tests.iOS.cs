using NUnit.Framework;
using Xamarin.UITest;

namespace FISTA16.Demo.UITests
{
	[TestFixture (Platform.iOS)]
	public class Tests_iOS
	{
		IApp app;
		Platform platform;

		public Tests_iOS (Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest ()
		{
			app = AppInitializer.StartApp (platform);
		}

		[Test]
		public void VerifyUserProfile_UserValid()
		{
			app.WaitForElement(c=>c.Class("UINavigationBar").Marked("User Profile Form"));

			app.EnterText(c => c.Class("UITextField").Marked("NameEntry"),"Sara Silva");

			app.EnterText(c => c.Class("UITextField").Marked("MobileNumberEntry"),"123456789");

			app.Tap(c=>c.Marked("CheckUser").Class("UIButton"));

			app.WaitForElement (c => c.Marked ("User valid!").Class ("UILabel").Marked("FeedbackLabel"));
		}

		[Test]
		public void VerifyUserProfile_MobileNumberIsTooLong()
		{
			app.WaitForElement(c=>c.Class("UINavigationBar").Marked("User Profile Form"));

			app.EnterText(c => c.Class("UITextField").Marked("NameEntry"),"Sara Silva");

			app.EnterText(c => c.Class("UITextField").Marked("MobileNumberEntry"),"1234567890");

			app.Tap(c=>c.Marked("CheckUser").Class("UIButton"));

			app.WaitForElement (c => c.Marked ("The mobile number is too long.").Class ("UILabel").Marked("FeedbackLabel"));

		}

		[Test]
		public void VerifyUserProfile_MobileNumberIsTooShort()
		{
			app.WaitForElement(c=>c.Class("UINavigationBar").Marked("User Profile Form"));

			app.EnterText(c => c.Class("UITextField").Marked("NameEntry"),"Sara Silva");

			app.EnterText(c => c.Class("UITextField").Marked("MobileNumberEntry"),"12345678");

			app.Tap(c=>c.Marked("CheckUser").Class("UIButton"));

			app.WaitForElement (c => c.Marked ("The mobile number is too short.").Class ("UILabel").Marked("FeedbackLabel"));

		}

		[Test]
		public void VerifyUserProfile_MobileNumberOnlyAcceptNumbers()
		{
			app.WaitForElement(c=>c.Class("UINavigationBar").Marked("User Profile Form"));

			app.EnterText(c => c.Class("UITextField").Marked("NameEntry"),"Sara Silva");

			app.EnterText(c => c.Class("UITextField").Marked("MobileNumberEntry"),"ABC");

			app.Tap(c=>c.Marked("CheckUser").Class("UIButton"));

			app.WaitForElement (c => c.Marked ("The mobile number only accept numbers.").Class ("UILabel").Marked("FeedbackLabel"));
		}

		[Test]
		public void VerifyUserProfile_MobileNumberMustBeDefined()
		{
			app.WaitForElement(c=>c.Class("UINavigationBar").Marked("User Profile Form"));

			app.EnterText(c => c.Class("UITextField").Marked("NameEntry"),"Sara Silva");

			app.Tap(c=>c.Marked("CheckUser").Class("UIButton"));

			app.WaitForElement (c => c.Marked ("The mobile number must be defined.").Class ("UILabel").Marked("FeedbackLabel"));

		}

		[Test]
		public void VerifyUserProfile_UserMustHaveName()
		{
			app.WaitForElement(c=>c.Class("UINavigationBar").Marked("User Profile Form"));

			app.EnterText(c => c.Class("UITextField").Marked("MobileNumberEntry"),"123456789");

			app.Tap(c=>c.Marked("CheckUser").Class("UIButton"));

			app.WaitForElement (c => c.Marked ("The user must have a name. ").Class ("UILabel").Marked("FeedbackLabel"));
		}
	}
}

