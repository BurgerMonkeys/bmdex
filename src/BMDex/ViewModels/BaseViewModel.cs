using System;
using System.Threading.Tasks;
using BMDex.Abstractions;

namespace BMDex.ViewModels
{
    public class BaseViewModel : BindableObject, IInitialize
    {
        bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
