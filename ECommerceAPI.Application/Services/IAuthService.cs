﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.DTOs;

namespace ECommerceAPI.Application.Services
{
    public interface IAuthService
    {
        Task<string?> AuthenticateUserAsync(UserLoginDto loginDto);
    }
}
