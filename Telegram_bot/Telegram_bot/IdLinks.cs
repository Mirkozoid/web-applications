using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varible;

namespace IDrecords
{
    class IDrecord : Variables
    {
        public static void RecordingID()
        {
            for (int i = 0; i < IdList.Count; i++)
            {
                if (IdList[i] == ID) IDindex = i;   
            }
        }
    }
}
