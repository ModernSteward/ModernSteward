using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FolderRemoverAtUninstall
{
	/// <summary>
	/// Removes the application folder when uninstalling the product
	/// </summary>
	class FolderRemover
	{
		static void Main(string[] args)
		{
			try
			{
				string path = "";
				foreach (var str in args)
				{
					path += str + ' ';
				}

				path.TrimEnd(' ');

				System.IO.Directory.Delete(path, true);
			}
			catch (Exception e) { }
		}
	}
}
