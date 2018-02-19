using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileConverter
{
	class ConverterService
	{
		private System.IO.FileSystemWatcher _watcher;

		public bool Start()
		{
			_watcher = new System.IO.FileSystemWatcher(@"D:\temp", "*.txt");
			_watcher.Created += FileCreated;
			_watcher.IncludeSubdirectories = false;
			_watcher.EnableRaisingEvents = true;
			return true;



		}


		public bool Pause()
		{
			_watcher.EnableRaisingEvents = false;
			return true;
		}

		public bool Continue()
		{
			_watcher.EnableRaisingEvents = true;

			return true;
		}
		private void FileCreated(object sender, FileSystemEventArgs e)
		{
			string content = File.ReadAllText(e.FullPath);
			string uppercontent = content.ToUpperInvariant();
			var dir = Path.GetDirectoryName(e.FullPath);
			var convertedFileName = Path.GetFileName(e.FullPath);
			var convertedPath = Path.Combine(dir, convertedFileName);
			File.WriteAllText(convertedPath,uppercontent);
		}
		public bool Stop()
		{
			_watcher.Dispose();
			return true;



		}
	}
}
