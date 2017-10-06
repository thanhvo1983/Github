using System;
using System.Collections.Generic;
using System.Text;

using log4net;
using log4net.Config;
using System.IO;

namespace Kvics.HotMill.Forms
{
    public class Log
    {
        static Log _Instance = null;
        static readonly object _Sync = new Object();

        private Log()
        {
            // Using DBAccess.log4net file
            XmlConfigurator.Configure(new FileInfo("DBAccess.log4net"));
        }

        public static Log Instance
        {
            get
            {
                lock (_Sync)
                {
                    if (_Instance == null)
                    {
                        _Instance = new Log();
                    }
                    return _Instance;
                }
            }
        }

        public ILog GetLogger(Type log)
        {
            return LogManager.GetLogger(log);
        }
    }
}
