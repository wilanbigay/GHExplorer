using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace GHExplorer
{
	//notes:
	//	a) INotifyPropertyChanging is not available in PCL

	public class BaseViewModel : BaseModel
	{

		protected INavigation _navigation;
		public BaseViewModel (INavigation navigation)
		{
			_navigation = navigation;
		}

		#region Properties

		private string _title = "";
		public string Title {
			get { return _title; }
			set { SetProperty (ref _title, value); }
		}

		string _subTitle = null;
		public string SubTitle {
			get { return _subTitle; }
			set {
				SetProperty (ref _subTitle, value);
			}
		}

		string _icon = null;
		public string Icon {
			get { return _icon = null; }
			set { SetProperty (ref _icon, value); }
		}

		bool _isBusy;
		public bool IsBusy {
			get { return _isBusy; }
			set { SetProperty (ref _isBusy, value, IsBusyPropertyName, () => { OnPropertyChanged(IsNotBusyPropertyName); }); }
		}
		public bool IsNotBusy {
			get { return !_isBusy; }
		}

		bool _canLoadMore;
		public bool CanLoadMore {
			get { return _canLoadMore; }
			set { SetProperty (ref _canLoadMore, value); }
		}

		#endregion


		#region PropertyNames
		public const string TitlePropertyName 		= "Title";
		public const string SubTitlePropertyName 	= "SubTitle";
		public const string IconPropertyName 		= "Icon";
		public const string IsBusyPropertyName 		= "IsBusy";
		public const string IsNotBusyPropertyName 	= "IsNotBusy";
		public const string CanLoadMorePropertyName = "CanLoadMore";
		#endregion

	}
}




