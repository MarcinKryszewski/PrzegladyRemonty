using PrzegladyRemonty.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrzegladyRemonty.Commands
{
    class LoginCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (true)
            {
                Window loginWindow = Application.Current.MainWindow;
                Application.Current.MainWindow = new MainWindow();
                Application.Current.MainWindow.Show();
                loginWindow.Close();
            }
            
        }
    }
}
