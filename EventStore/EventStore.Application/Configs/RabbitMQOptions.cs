﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Application.Configs
{
    public class RabbitMQOptions
    {
        public string HostName {  get; set; }
        public string UserName { get; set; }
        public string Password {  get; set; }
    }
}
