﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesApi
{
    public interface IAuthService
    {

        Task<string> LoginAsync(string email, string password);

    }

}

