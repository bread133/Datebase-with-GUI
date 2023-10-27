using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIR_7.General
{
    public static class Cmd
    {
        public static string ExecuteDump(string commandLine, string outputFile)
        {
            var process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\MySQL\MySQL Server 8.0\bin\mysqldump.exe",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Arguments = $" {commandLine} > {outputFile}"
            };
            process.Start();

            StreamReader reader = process.StandardOutput;
            string output = reader.ReadToEnd();
            process.WaitForExit();
            process.Close();

            return output;
        }

        public static void ExecuteBackup(string batchFilePath)
        {
            var process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd",
                CreateNoWindow = true,
                UseShellExecute = true,
                //RedirectStandardOutput = true,
                Arguments = $"/c {batchFilePath}"
            };
            process.Start();

            //StreamReader reader = process.StandardOutput;
            //string output = reader.ReadToEnd();

            process.WaitForExit();
            process.Close();
        }
    }
}
