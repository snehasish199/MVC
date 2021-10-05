using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public sealed class Log : ILog
    {

        private Log()
        {

        }
        //lazy initialization
        // type 1: using lazy keyword
        private static readonly Lazy<Log> instance =
            new Lazy<Log>(() => new Log());
        public static Log GetInstance()
        {
            return instance.Value;
        }

        public void LogException(string message)
        {
            string FileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToShortDateString());

            string LogFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, FileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---------------------------------");
            sb.AppendLine(DateTime.Now.ToString());

            sb.AppendLine(message);

            using (StreamWriter writer = new StreamWriter(LogFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }

        }
    }
}

