using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace GHExplorer
{
	public class HomeViewModel : BaseViewModel
	{

		public HomeViewModel (INavigation navigation) : base(navigation)
		{
			Title = "Home";
		}

		private string _username;
		public string UserName {
			get {
				return _username;
			}
			set {
				SetProperty (ref _username, value, UserNamePropertyName);
			}
		}

		string _blog;
		public string Blog {
			get {
				return _blog;
			}
			set {
				SetProperty (ref _blog, value, BlogPropertyName);
			}
		}

		string _company;
		public string Company {
			get { return _company; }
			set { SetProperty (ref _company, value, CompanyPropertyName ); }
		}

		string _avatarUrl;
		public string AvatarUrl {
			get { return _avatarUrl; }
			set { SetProperty (ref _avatarUrl, value, AvatarUrlPropertyName); }

		}


		private Command _searchGitHubCommand;
		public Command SearchGitHubCommand {
			get { 
				return _searchGitHubCommand 
					?? (_searchGitHubCommand = new Command<string> (ExecuteSearchCommand, CanSearch)); 
			}
		}

		private async void ExecuteSearchCommand(string username) {

			if (IsBusy)
				return;

			if (string.IsNullOrWhiteSpace(username))
				return;

			IsBusy = true;
			var user = await GetUserFromApi (username);
			IsBusy = false;
			this.AvatarUrl = user.avatar_url;
			this.Blog = user.blog;
			this.Company = user.company;
		}

		private bool CanSearch(string username) {
			return !string.IsNullOrWhiteSpace (username);
		}

		#region PropertyNames
		public const string UserNamePropertyName = "UserName";
		public const string SearchGitHubCommandPropertyName = "SearchGitHubCommand";
		public const string BlogPropertyName = "Blog";
		public const string CompanyPropertyName = "Company";
		public const string AvatarUrlPropertyName = "AvatarUrl";
		#endregion

		private async Task<User> GetUserFromApi(string username) {
			var client = new HttpClient();
			var url = "https://api.github.com/users/" + username;
			client.DefaultRequestHeaders.Add("User-Agent","Mozilla/5.0 (Macintosh; Intel Mac OS X 10_9_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36");
			var str = await client.GetStringAsync(url);
			var user = JsonConvert.DeserializeObject<User> (str);

			return user;
		}


	}
}

