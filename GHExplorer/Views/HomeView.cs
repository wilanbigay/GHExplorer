using System;
using Xamarin.Forms;

namespace GHExplorer
{
	public class HomeView : BaseView
	{

		private HomeViewModel ViewModel 
		{
			get { return BindingContext as HomeViewModel; }
		}

		public HomeView ()
		{

			BindingContext = new HomeViewModel (this.Navigation);

			var stack = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Spacing = 10
			};

			var username = new Entry {
				Placeholder = "username",
			};
			username.SetBinding (Entry.TextProperty, new Binding (HomeViewModel.UserNamePropertyName));
			stack.Children.Add (username);

			var label = new Label {
			};
			label.SetBinding(Label.TextProperty, new Binding(HomeViewModel.UserNamePropertyName));
			stack.Children.Add (label);

			var btnSearch = new Button {
				Text = "Search"
			};
			btnSearch.SetBinding (Button.CommandProperty, new Binding( HomeViewModel.SearchGitHubCommandPropertyName));
			btnSearch.SetBinding (Button.CommandParameterProperty, new Binding (HomeViewModel.UserNamePropertyName));
			stack.Children.Add (btnSearch);

			var stack2 = new StackLayout {
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10
			};

			var activity = new ActivityIndicator {
				IsEnabled = true,
				Color = Color.Gray
			};
			activity.SetBinding (ActivityIndicator.IsVisibleProperty, HomeViewModel.IsBusyPropertyName);
			activity.SetBinding (ActivityIndicator.IsRunningProperty, HomeViewModel.IsBusyPropertyName);
			stack.Children.Add (activity);

			//var fullName = new Label {
			//	HorizontalOptions = LayoutOptions.Center
			//};
			//stack2.Children.Add (fullName);

			var avatar = new Image ();
			avatar.SetBinding(Image.SourceProperty, new Binding(HomeViewModel.AvatarUrlPropertyName));
			avatar.SetBinding (Image.IsVisibleProperty, new Binding(HomeViewModel.IsNotBusyPropertyName));
			avatar.GestureRecognizers.Add (new TapGestureRecognizer ((view, args) => {

				//this.Navigation.PushAsync(new WebsiteView("http://www.cnn.com", "CNN"));
				this.Navigation.PushAsync(
					new ContentPage {
						Content = 	new WebView { Source = "https://github.com/" + username.Text},
						Title = username.Text
					});
			}));
		
			stack2.Children.Add (avatar);

			var lblCompany = new Label {
				HorizontalOption = LayoutOptions.Center,
				Text = "Company"
			};
			//lblCompany.SetBindings (Label.TextProperty, HomeView.Company);
			stack2.Children.Add (lblCompany);

			stack.Children.Add (new ScrollView{VerticalOptions = LayoutOptions.FillAndExpand, Content = stack2 });


			Content = stack;
		}
	}
}

