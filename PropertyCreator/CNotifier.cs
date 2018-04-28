using System;
using System.ComponentModel;

namespace PropertyCreator
	{
	public class CNotifier : INotifyPropertyChanged

		{
		public event PropertyChangedEventHandler
			PropertyChanged;

		protected void OnPropertyChanged(String PropertyName)
			{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
			}
		}
	}