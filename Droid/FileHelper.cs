using System;
using System.IO;
using Xamarin.Forms;
using XamarinCleanApp.Core.Data.Cache;
using XamarinCleanApp.Droid;

[assembly: Dependency(typeof(FileHelper))]
namespace XamarinCleanApp.Droid
{
	public class FileHelper : IFileHelper
	{
		public string GetLocalFilePath(string filename)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(path, filename);
		}
	}
}
