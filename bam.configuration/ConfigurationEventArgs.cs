﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Configuration
{
    public class ConfigurationEventArgs: EventArgs
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
