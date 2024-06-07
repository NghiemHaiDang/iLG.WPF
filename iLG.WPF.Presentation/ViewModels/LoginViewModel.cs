using CommunityToolkit.Mvvm.Input;
using iLG.WPF.Infrastructure.Entities;
using iLG.WPF.Infrastructure.Repositories.Abstractions;
using iLG.WPF.Presentation.Commands.Generic;

using iLG.WPF.Presentation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RelayCommand = iLG.WPF.Presentation.Commands.Generic.RelayCommand;

namespace iLG.WPF.Presentation.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public readonly IBaseHttpRepository<User> _baseHttpRepository;
        public ICommand LoginCommand { get; private set; }

        private UserModel _userModel;
        
        public UserModel UserModel
        {
            get { return _userModel; }
            set { 
                _userModel = value;
                OnPropertyChanged(nameof(UserModel));
            }
        }
        public LoginViewModel()
        {
            UserModel = new UserModel();
            LoginCommand = new RelayCommand(Login,CanLogin);
        }
        private bool CanLogin(object parameter)
        {
            return !string.IsNullOrWhiteSpace(UserModel.Email) && !string.IsNullOrWhiteSpace(UserModel.Password);
        }
        private void Login(object parameter)
        {

        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
