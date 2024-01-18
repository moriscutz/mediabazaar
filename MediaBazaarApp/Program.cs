using BusinessLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using DataAccess;

namespace MediaBazaarApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var service = new ServiceCollection();
            ApplicationConfiguration.Initialize();
            service.AddTransient<IEmployeeDB, EmployeeDB>();
            service.AddTransient<IEmployeeRepository, EmployeeRepository>();
            service.AddTransient<IShiftDB, ShiftDB>();
            service.AddTransient<IShiftRepository, ShiftRepository>();
            service.AddTransient<IAvailabilityDB, AvailabilityDB>();
            service.AddTransient<IAvailabilityRepository, AvailabilityRepository>();
            service.AddTransient<InitialForm>();
            var serviceProvider = service.BuildServiceProvider();
            Application.Run(serviceProvider.GetService<InitialForm>());
        }
    }
}