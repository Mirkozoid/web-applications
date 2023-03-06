using System.Collections.Generic;

namespace User
{
    class Users
    {
        public static int ID;
        public static int IndexId;
        public static List<int> ListId = new List<int>();
        public static void UserId()
        {
            for (int i = 0; i < ListId.Count; i++)
            {
                if (ListId[i] == ID) IndexId = i;
            }
        }
    }
}
