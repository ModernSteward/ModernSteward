using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using System.Security.Cryptography;

namespace ModernSteward
{
    public class ZipManager
    {
        public static int Extract(string sourceFile, string destinationPath)
        {
            ZipInputStream zinstream = null; // used to read from the zip file
            int numFileUnzipped = 0; // number of files extracted from the zip file

            try
            {
                // create a zip input stream from source zip file
                zinstream = new ZipInputStream(File.OpenRead(sourceFile));

                // we need to extract to a folder so we must create it if needed
                if (Directory.Exists(destinationPath) == false)
                    Directory.CreateDirectory(destinationPath);

                ZipEntry theEntry; // an entry in the zip file which could be a file or directory

                // now, walk through the zip file entries and copy each file/directory
                while ((theEntry = zinstream.GetNextEntry()) != null)
                {
                    string dirname = Path.GetDirectoryName(theEntry.Name); // the file path
                    string fname = Path.GetFileName(theEntry.Name);      // the file name

                    // if a path name exists we should create the directory in the destination folder
                    string target = destinationPath + Path.DirectorySeparatorChar + dirname;
                    if (dirname.Length > 0 && !Directory.Exists(target))
                        Directory.CreateDirectory(target);

                    // now we know the proper path exists in the destination so copy the file there
                    if (fname != String.Empty)
                    {
                        DecompressAndWriteFile(destinationPath + Path.DirectorySeparatorChar + theEntry.Name, zinstream);
                        numFileUnzipped++;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
				zinstream.Dispose();
                zinstream.Close();
            }
            return numFileUnzipped;
        }

        private static void DecompressAndWriteFile(string destination, ZipInputStream source)
        {
            FileStream wstream = null;

            try
            {
                // create a stream to write the file to
                wstream = File.Create(destination);

                const int block = 2048; // number of bytes to decompress for each read from the source

                byte[] data = new byte[block]; // location to decompress the file to

                // now decompress and write each block of data for the zip file entry
                while (true)
                {
                    int size = source.Read(data, 0, data.Length);

                    if (size > 0)
                        wstream.Write(data, 0, size);
                    else
                        break; // no more data
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (wstream != null)
                    wstream.Close();
            }
        }

		public static string GetMD5FromAZip(string filePath)
		{
			FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] retVal = md5.ComputeHash(file);
			file.Close();

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < retVal.Length; i++)
			{
				sb.Append(retVal[i].ToString("x2"));
			}
			return sb.ToString();
		}
    }
}
