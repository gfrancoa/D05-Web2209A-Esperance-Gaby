using Chevalier.Utility.Authentication;
using Chevalier.Utility.Commands;
using Chevalier.Utility.ViewModels;
using ShoppingAppWPF.Models;
using ShoppingAppWPF.Repositories;
using ShoppingAppWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace ShoppingAppWPF.ViewModels
{
    class LoginViewModel : ViewModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public string Message { get; set; }

        public DelegateCommand LoginCommand { get; }

        private UserRepository repository { get; set; }

        private LoginView loginView { get; set; }

        private ProductListView ProductListView { get; set; }
        private LoginView LoginView { get; set; }

        private Action Navigate;

        private User loggedUser;
        public LoginViewModel(User user,Action navigate,LoginView loginView)
        {
            repository = new UserRepository();
            LoginCommand = new DelegateCommand(Login);
           // ProductListView = productListView;
            
            loggedUser = user;
            Navigate =navigate;
            LoginView = loginView;
        }



        private void Login(object _)
        {
            try
            {
               
                User user = repository.GetUser(Username);

                if (user is null)
                {
                    Message = "User not found";
                    NotifyPropertyChanged(nameof(Message));
                    return;
                    
                }

                PasswordHasher passwordHasher = new PasswordHasher();
                HashedPassword hashedPassword = passwordHasher.HashPassword(Password, user.Password.Salt);
                
                PasswordResult result = passwordHasher.VerifyPassword(Password, user.Password);
                Console.WriteLine($"Password result: {result}");
                Console.WriteLine();

                if (result != PasswordResult.Correct)
                {

                    Message = "Failed to login";
                    NotifyPropertyChanged(nameof(Message));
                } else
                {
                    Name = user.Name;
                    Navigate();
                    Message = "";
                    Username = "";
                    Password = "";
                    LoginView.passwordBox.Clear();
                    NotifyPropertyChanged(nameof(Message));
                    NotifyPropertyChanged(nameof(Username));
                    NotifyPropertyChanged(nameof(Password));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: Failed to log in: {e.Message}");
            }
        }
    }
}
