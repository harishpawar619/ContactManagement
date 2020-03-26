using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace ContactMangement.Logger
{
	public static class SerilogManager
	{
		private static Serilog.ILogger _Logger;

		public static string _ComponentName;
		public static string _ConnectionString { get; set; }
		public static string _TableName { get; set; }
		public static bool FilebasedLogger { get; set; }
		public static string _LogFilePath { get; set; }
		public static string _HostName { get; set; }
		static SerilogManager()
		{
		}

		public static void InitializeLogger()
		{
				_HostName = Environment.MachineName.ToString();
				if (FilebasedLogger)
				{
						var columnOptions = new ColumnOptions();
						columnOptions.Store.Remove(StandardColumn.MessageTemplate);
						columnOptions.Store.Remove(StandardColumn.Properties);
						columnOptions.AdditionalColumns = new Collection<SqlColumn>
						{
								new SqlColumn {ColumnName = "ComponentName", DataType = SqlDbType.VarChar, DataLength=100 },
								new SqlColumn { ColumnName = "HostName", DataType = SqlDbType.VarChar, DataLength=100},
								new SqlColumn { ColumnName = "TicketNumber", DataType = SqlDbType.VarChar, DataLength=50}
						};

						Log.Logger = new LoggerConfiguration()
								.Enrich.WithMachineName()
								.Enrich.WithThreadId()
								.MinimumLevel.Debug()
								.WriteTo.MSSqlServer(_ConnectionString, _TableName, null, LogEventLevel.Verbose, 50, null, null, false, columnOptions: columnOptions, null, "dbo")
								.WriteTo.File(_LogFilePath, LogEventLevel.Verbose, "{Timestamp:dd-MMM-yyyy HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}  {ComponentName}  {HostName}", null, 1234567, null, false, false, null, RollingInterval.Day, false, 31, null, null)
								.CreateLogger();
				}
				else
				{
						var columnOptions = new ColumnOptions();
						columnOptions.Store.Remove(StandardColumn.MessageTemplate);
						columnOptions.Store.Remove(StandardColumn.Properties);
						columnOptions.AdditionalColumns = new Collection<SqlColumn>
						{
								new SqlColumn {ColumnName = "ComponentName", DataType = SqlDbType.VarChar, DataLength=100 },
								new SqlColumn { ColumnName = "HostName", DataType = SqlDbType.VarChar, DataLength=100},
								new SqlColumn { ColumnName = "TicketNumber", DataType = SqlDbType.VarChar, DataLength=50},
						};

						Log.Logger = new LoggerConfiguration()
								.Enrich.WithMachineName()
								.Enrich.WithThreadId()
								.MinimumLevel.Debug()
								.WriteTo.MSSqlServer(_ConnectionString, _TableName, null, LogEventLevel.Verbose, 50, null, null, false, columnOptions: columnOptions, null, "dbo")
								.CreateLogger();
				}
		}
		public static void Debug(string message)
		{
				Log.ForContext("ComponentName", _ComponentName).ForContext("HostName", _HostName).Debug(message);
		}

		public static void Debug(string message, Exception ex)
		{
				Log.ForContext("ComponentName", _ComponentName).ForContext("HostName", _HostName).Debug(ex, message);
		}

		public static void Information(string message)
		{
				Log.ForContext("ComponentName", _ComponentName).ForContext("HostName", _HostName).Information(message);
		}

		public static void Information(Exception ex, string message)
		{
				Log.ForContext("ComponentName", _ComponentName).ForContext("HostName", _HostName).Information(ex, message);
		}

		public static void Warning(string message)
		{
				Log.ForContext("ComponentName", _ComponentName).ForContext("HostName", _HostName).Warning(message);
		}

		public static void Warning(Exception ex, string message)
		{
				Log.ForContext("ComponentName", _ComponentName).ForContext("HostName", _HostName).Warning(ex, message);
		}

		public static void Error(string message)
		{
				Log.ForContext("ComponentName", _ComponentName).ForContext("HostName", _HostName).Error(message);
		}

		public static void Error(Exception ex)
		{
				Log.ForContext("ComponentName", _ComponentName).ForContext("HostName", _HostName).Error(ex,ex.Message);
		}

		public static void Error(Exception ex, string message)
		{
				Log.ForContext("ComponentName", _ComponentName).ForContext("HostName", _HostName).Error(ex, message);
		}

		public static void Error(string ticketNumber, Exception ex)
		{
				Log.ForContext("ComponentName", _ComponentName).ForContext("HostName", _HostName).ForContext("TicketNumber", ticketNumber).Error(ex, ex.Message);
		}

		public static void Fatal(string message)
		{
				Log.ForContext("ComponentName", _ComponentName).ForContext("HostName", _HostName).Fatal(message);
		}

		public static void Fatal(Exception ex)
		{
				Log.ForContext("ComponentName", _ComponentName).ForContext("HostName", _HostName).Fatal(ex, ex.Message);
		}

		public static void Fatal(Exception ex, string message)
		{
				Log.ForContext("ComponentName", _ComponentName).ForContext("HostName", _HostName).Fatal(ex, message);
		}
	}

}