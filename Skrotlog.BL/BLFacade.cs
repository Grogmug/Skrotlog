using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skrotlog.BL
{
    public class BLFacade
    {
        private static volatile BLFacade instance;

        public static BLFacade Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new BLFacade();
                    
                }
                return instance;
            }
        }
    }
}
