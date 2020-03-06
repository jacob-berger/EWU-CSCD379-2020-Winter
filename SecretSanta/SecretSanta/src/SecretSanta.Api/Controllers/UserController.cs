﻿using Microsoft.AspNetCore.Mvc;
using SecretSanta.Business.Dto;
using SecretSanta.Business.Services;

namespace SecretSanta.Api.Controllers
{
    public class UserController : BaseApiController<User, UserInput>
    {
        public UserController(IUserService userService)
            : base(userService)
        { }
    }
}