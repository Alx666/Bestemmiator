using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bestemmiator.Resources
{
    internal static class ResourceLoader
    {
        static Random rand;

        static ResourceLoader()
        {
            rand = new Random();
        }


        internal static Bitmap GetRandomImage()
        {
            Assembly asm = Assembly.GetAssembly(typeof(ResourceLoader));

            string[] names = asm.GetManifestResourceNames();


            using (Stream resourceStream = asm.GetManifestResourceStream(names[rand.Next(0, names.Length)]))
            {
                return new Bitmap(resourceStream);                
            }                
        }
    }
}
