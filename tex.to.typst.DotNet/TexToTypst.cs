using System;
using System.Diagnostics;

namespace TexToTypstDotNet;

public static class TexToTypst
{
    public static string Convert(string tex)
    {
        string nodePath = "node.exe"; // Path to Node.js executable
        string scriptPath = "convert.js"; // Path to your script file

        // Escape the LaTeX content for safe command-line usage
        tex = tex.Replace("\"", "\\\"");
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = nodePath,
                Arguments = $"{scriptPath} \"{tex}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        process.WaitForExit();

        if (!string.IsNullOrWhiteSpace(output))
        {
            return output;
        }

        throw new Exception(error);
    }
}