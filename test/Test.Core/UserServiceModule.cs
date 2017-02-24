﻿using System;
using System.Collections.Generic;
using KickStart.Services;

namespace Test.Core
{
    public class UserServiceModule : IServiceModule
    {
        public void Register(IServiceRegistration services, IDictionary<string, object> data)
        {
            services.RegisterSingleton<IConnection, SampleConnection>();
            services.RegisterTransient<IUserService, UserService>(c => new UserService(c.GetService<IConnection>()));
        }
    }
}