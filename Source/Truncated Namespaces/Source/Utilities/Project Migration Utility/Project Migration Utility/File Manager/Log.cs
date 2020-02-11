using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ProjectMigrationUtility.FileManager
{
	internal class Log
	{
		private readonly static object locker;

		static Log()
		{
			FileSelectionManager.Log.locker = new object();
		}

		public Log()
		{
		}

		private static string getCurrentMethod()
		{
			return (new StackTrace()).GetFrame(3).GetMethod().Name;
		}

		private static void WriteFile(string logMessage, string messageType, string className, TextWriter w)
		{
			object[] shortDateString = new object[] { DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), className, FileSelectionManager.Log.getCurrentMethod(), messageType, logMessage };
			w.WriteLine("[{0} {1}] [{2}:{3}] [{4}] [{5}]", shortDateString);
		}

		public static void WriteLog(string message, string messageType, string className, Dictionary<string, object> appConfig)
		{
			if (appConfig.Count > 0 && Convert.ToBoolean(appConfig["ACTIVE"]))
			{
				lock (FileSelectionManager.Log.locker)
				{
					using (StreamWriter w = File.AppendText(string.Concat(Convert.ToString(appConfig["FULLPATH"]), "\\", Convert.ToString(appConfig["FILENAME"]))))
					{
						FileSelectionManager.Log.WriteFile(message, messageType, className, w);
					}
				}
			}
		}
	}
}