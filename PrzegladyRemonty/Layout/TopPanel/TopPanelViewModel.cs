﻿using Microsoft.Extensions.Hosting;
using PrzegladyRemonty.Shared.ViewModels;
using PrzegladyRemonty.Stores;

namespace PrzegladyRemonty.Layout.TopPanel
{
    public class TopPanelViewModel : ViewModelBase
    {
        private IHost _userHost;
        private readonly UserStore _user;

        public string HelloMassage => $"Witaj {_user.User?.Name}!";
        public TopPanelViewModel(UserStore user)
        {
            _user = user;
        }
    }
}
