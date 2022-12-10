using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSynchronizer
{
    public class Logger
    {
        public void Log(string message)
        {
            //using (FileStream fs = new FileStream(@"C:\\Users\\Administrator\\Documents\\Visual Studio 2013\\Projects\\EmailSynchronizer\\EmailSynchronizer\\bin\\Debug\\EmailSynchronizerLog.txt", FileMode.Append, FileAccess.Write))
            using (FileStream fs = new FileStream(@"C:\\Users\\qsmrf\\Desktop\\EmailSynchronizer\\EmailSynchronizer\\bin\\Debug\\EmailSynchronizerLog.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(DateTime.Now + " " + message);
            }
        }
    }
}
