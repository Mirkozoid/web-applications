using System.Linq;
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
                var uniq = IdList.Distinct();
            }
        }
    }
}
