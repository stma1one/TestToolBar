using System;
using System.Collections.Generic;
using System.Text;
using TestToolBar.Views;
using Xamarin.Forms;
using System.Windows.Input;
using System.ComponentModel;

namespace TestToolBar.ViewModels
{
    class HomeViewModel : INotifyPropertyChanged
    {
        #region members
        private int count;
        #endregion

        #region properties
        public int Count { get { return count; } 
        set { if (count != value)
                { count = value;
                    //when Count is updated ->check if the CanChange function output is changed
                    (Display as Command).ChangeCanExecute();
                    OnPropertyChange(nameof(Count)); } } }
        #endregion

        #region INOTIFYPROPERTYCHANGED
        #region event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        private void OnPropertyChange(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
        #endregion


        #region Commands
        public ICommand PressMe { get; set; }

        public ICommand Display { get; set; }
        #region CanExecute 
        private bool CanChange()
        {
            return Count%3==0;
        }
        #endregion
        #endregion

        #region Constructor
        public HomeViewModel() 
        { count = 1;
            Display = new Command(() => { Application.Current.MainPage.DisplayAlert("Hello", "Hi there", "OK"); },CanChange);
            PressMe = new Command(() => { Count++; });
        }
        #endregion

    }
}
