using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Services.Http
{
  public class DataCache
    {
        #region singleton

        
        private static DataCache _instance;
        private static readonly object InstanceLock = new object();

        public static DataCache Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (InstanceLock)
                    {
                        if(_instance==null)
                        {
                            _instance = new DataCache();    
                        }
                    }

                }
                return _instance;
            }            
        }

#endregion  

    }
}
