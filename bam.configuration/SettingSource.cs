﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.CoreServices.Configuration
{
    public enum SettingSource
    {
        Invalid,
        DefaultConfigurationFile,
        CommonSetting,
        MachineSetting,
        ApplicationSetting
    }
}
