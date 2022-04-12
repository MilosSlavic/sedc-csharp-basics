using CSB.Business;
using CSB.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CSB.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
            this.DispatcherUnhandledException += (sender, @event) =>
            {
                MessageBox.Show(@event.Exception.Message);
            };
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<CbsDbContext>(options =>
            {
                options.UseSqlite("Data Source=file.db");
            });

            services.AddSingleton<MainWindow>();
            services.AddTransient<AddEmployee>();
            services.AddTransient<DeleteEmployee>();
            services.AddAutoMapper(cfg => cfg.AddProfile<BusinessProfile>());
            services.AddRepository();
            services.AddBusiness();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var dbContext = serviceProvider.GetRequiredService<CbsDbContext>();
            dbContext.Database.EnsureCreated();
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
