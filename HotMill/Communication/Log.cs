using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using log4net.Config;
using System.IO;

// [assembly: log4net.Config.DOMConfigurator(ConfigFile = "Communication.log4net", ConfigFileExtension = "log4net", Watch = true)]

namespace Kvics.Communication
{
    /// <summary>
    /// Singleton class for logging
    /// </summary>    
    public class Log
    {
        public static Kvics.DBAccess.Log Instance
        {
            get
            {
                return Kvics.DBAccess.Log.Instance;
            }
        }
    }
}