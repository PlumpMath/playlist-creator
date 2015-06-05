using System;
using System.IO;
using System.Linq;

namespace playlistcreator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string playlistName = Path.Combine(System.Environment.CurrentDirectory, "play.m3u");
			int playlistLength = 1000;

//			Console.WriteLine (System.Environment.CurrentDirectory);


			var extensions = new string[] { ".mp4", ".mov", ".png", ".gif", ".jpg", ".jpeg", ".avi" };

			var di = new DirectoryInfo (System.Environment.CurrentDirectory);
			var files = di.GetFileSystemInfos ()
				.Where (f => f.Attributes != FileAttributes.Hidden)
				.Where (f => extensions.Contains (f.Extension, StringComparer.CurrentCultureIgnoreCase))
				.OrderByDescending (f => f.CreationTime)
				.Take (playlistLength)
				.Select (f => f.Name);

			if (File.Exists (playlistName))
				File.Delete (playlistName);

			using (StreamWriter playlist = File.CreateText (playlistName)) {
				playlist.WriteLine ("#EXTM3U");


				foreach (var file in files) {
					playlist.WriteLine (string.Format ("#EXTINF:0,{0}", file));
					playlist.WriteLine (file);
				}

			}

		}
	}
}
