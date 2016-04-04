using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PhotoOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = @"C:\Users\Chuck Conway\Desktop\Photography";
            var destination = @"C:\temp";

            DirectoryInfo info = new DirectoryInfo(source);

            var files = info.GetFiles("*.*", SearchOption.AllDirectories);

            var photos = files.GroupBy(s=>s.LastWriteTime.Date);

            foreach (var date in photos)
            {
                var d = date.Key;
                //var month = d.Month;
                var year = d.Year;
                //var day = d.Day;

                string name = d.ToString("m") +", " + year;
                string dest = $@"{destination}\{year}\{name}";
                var p = date.ToList();

                if (!Directory.Exists(dest))
                {
                    Directory.CreateDirectory(dest);
                }

                foreach (var file in p)
                {
                    File.Copy(file.FullName, string.Format(dest + @"\" + file.Name));
                }
                
            }
        }
    }
}
