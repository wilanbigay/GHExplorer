using System;

namespace GHExplorer
{
	public class User : BaseModel
	{
		string _name;
		public string name {
			get { return _name; }
			set { SetProperty (ref _name, value, "name"); }
		}
		string _company;
		public string company {
			get { return _company; }
			set { SetProperty (ref _company, value, "company"); }
		}
		string _blog;
		public string blog {
			get { return _blog; }
			set { SetProperty (ref _blog, value, "blog"); }

		}
		string _avatar_url;
		public string avatar_url {
			get { return _avatar_url; }
			set { SetProperty (ref _avatar_url, value, "avatar_url"); }

		}
	}
}

