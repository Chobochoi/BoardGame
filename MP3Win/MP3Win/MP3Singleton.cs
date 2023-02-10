using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP3
{
    public class MP3Singleton
    {
        private static MP3Singleton getInstance;

        private MP3Singleton() { }
        
        public static MP3Singleton OnlyOne()
        {
            if (getInstance == null)
            {
                getInstance = new MP3Singleton();
            }
            return getInstance;
        }
    }
}
