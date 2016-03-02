using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FISTA16.Demo
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

		private void Button_OnClicked(object sender, EventArgs e)
		{
			string message;
			var isValid = IsUserValid(NameEntry.Text, MobileNumberEntry.Text, out message);

			if (isValid)
			{
				FeedbackLabel.BackgroundColor = Color.Green;
				FeedbackLabel.TextColor = Color.White;
				FeedbackLabel.Text = "User valid!";
			}
			else
			{
				FeedbackLabel.BackgroundColor= Color.Red;
				FeedbackLabel.TextColor= Color.White;
				FeedbackLabel.Text = message;
			}
		}

		public bool IsUserValid(string name, string mobileNumber, out string message)
		{
			var isValid = true;
			message = string.Empty;
			int value = 0;

			if (string.IsNullOrWhiteSpace(name))
			{
				message = "The user must have a name. ";
				isValid = false;
			}

			if (string.IsNullOrWhiteSpace(mobileNumber))
			{
				message += "The mobile number must be defined.";
				isValid = false;
			}
			else if (!int.TryParse(mobileNumber, out value))
			{
				message += "The mobile number only accept numbers.";
				isValid = false;
			}
			else if (mobileNumber.Length < 9)
			{
				message += "The mobile number is too short.";
				isValid = false;
			}
			else if (mobileNumber.Length > 9)
			{
				message += "The mobile number is too long.";
				isValid = false;
			}

			return isValid;
		}

		private void MobileNumberEntry_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(MobileNumberEntry.Text) || string.IsNullOrEmpty(NameEntry.Text))
			{
				FeedbackLabel.BackgroundColor = Color.White;
				FeedbackLabel.TextColor = Color.Black;
				FeedbackLabel.Text = string.Empty;
			}
		}
	}

}

