using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GHExplorer
{
	public class BaseModel : INotifyPropertyChanged, INotifyPropertyChanging
	{

		protected void SetProperty<T>(
			ref T backingStore, T value,
			[CallerMemberName] string propertyName = "",
			Action onChanged = null,
			Action<T> onChanging = null	) 
		{


			if (EqualityComparer<T>.Default.Equals(backingStore, value)) 
				return;

			if (onChanging != null) 
				onChanging(value);

			OnPropertyChanging(propertyName);

			backingStore = value;

			if (onChanged != null) 
				onChanged();

			OnPropertyChanged(propertyName);
		}


		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string propertyName) {
			if (PropertyChanged == null)
				return;
			PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}
		#endregion

		#region INotifyPropertyChanging implementation

		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		public void OnPropertyChanging(string propertyName) {
			if (PropertyChanging == null)
				return;
			PropertyChanging (this, new PropertyChangingEventArgs (propertyName));
		}
		#endregion
	}
}

