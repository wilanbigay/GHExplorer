using System;
using Xamarin.Forms;

namespace GHExplorer
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new NavigationPage(new HomeView());
		}
	}
}

