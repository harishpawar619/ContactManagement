using System;
using System.Collections.Generic;
using System.Text;

namespace ContactMangement.Logger
{
		public class SerilogConfigurationSettings
		{
				public string ComponentName { get; set; }

				public string ConnectionString { get; set; }

				public string TableName { get; set; }

				public bool FilebasedLogger { get; set; }

				public string LogFilePath { get; set; }
		}
}
