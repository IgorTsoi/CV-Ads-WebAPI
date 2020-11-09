﻿using CV_Ads_WebAPI.Services;
using CV_Ads_WebAPI.Services.UserServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CV_Ads_WebAPI.ServiceInstallation.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<AdminService>();
            services.AddTransient<PartnerService>();
            services.AddTransient<CustomerService>();
            services.AddTransient<SmartDeviceService>();

            services.AddTransient<PasswordService>();
            services.AddTransient<JWTTokenService>();
        }
    }
}
