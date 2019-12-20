using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace LifeCycleWorkflowLibrary
{
    static class LifeCycleFileUtilities
    {
        [DllImport("psapi.dll")]
        static extern int EmptyWorkingSet(IntPtr hwProc);

        static void MinimizeFootprint()
        {
            EmptyWorkingSet(Process.GetCurrentProcess().Handle);
        }


        /// <summary>
        /// Performs FileCopy, create the path supplied. Provide option to Rename the file, this method will read the original file extension and rename the file to the same extension.
        /// Returns the new file's fullname.
        /// </summary>
        /// <param name="FileToCopy"></param>
        /// <param name="CopyToPath"></param>
        /// <param name="RenameTo"></param>
        /// <returns></returns>
        public static string CopyFile(string FileToCopy, string CopyToPath, string RenameTo = "")
        {
            Directory.CreateDirectory(CopyToPath);

            if (RenameTo == "")
            {
                string destPath = Path.Combine(CopyToPath, Path.GetFileName(FileToCopy));
                File.Copy(FileToCopy, destPath, true);

                return destPath;
            }
            else
            {
                string destPath = Path.Combine(CopyToPath, RenameTo + Path.GetExtension(FileToCopy));
                try
                {
                    File.Copy(FileToCopy, destPath, true);
                }
                catch
                {
                    //TODO error log this copy failed;
                }
                return destPath;
            }
        }
    }
}
