﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCart.DBManager
{
    public class loginModal
    {
        public int LoginUserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Action { get; set; }
    }
}