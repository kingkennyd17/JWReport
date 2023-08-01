using JWReport.Database;
using JWReport.Models;
using JWReport.PageModels.Base;
using JWReport.Pages;
using JWReport.Services.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JWReport.PageModels
{
    public class LaunchPageModel : PageModelBase
    {
        public LaunchPageModel()
        {
            this.InitializeAsync(null);
        }

        public async override Task InitializeAsync(object navigationData)
        {
            BaseRepository<GroupOverseer> database = await GroupOverseerRepository.Instance;
            GroupOverseer groupOverseer = new GroupOverseer();
            groupOverseer = await database.GetAsync(1);
            BaseRepository<User> userdatabase = await UserRepository.Instance;
            User userinfo = new User();
            userinfo = await userdatabase.GetAsync(1);
            if (userinfo == null)
            {
                await Shell.Current.GoToAsync($"//{nameof(WelcomePrivilegePage)}");
            }
            else if (groupOverseer == null)
            {
                await Shell.Current.GoToAsync($"//{nameof(WelcomeGroupOverseerPage)}");
            }
            else
            {
                await Shell.Current.GoToAsync($"//{nameof(FieldPage)}");
            }
            //await base.InitializeAsync(navigationData);
        }
    }
}
