﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Service.Dtos.UserPortal
{
    public class UserPortalDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}
