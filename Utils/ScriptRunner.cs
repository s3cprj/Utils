using System.Diagnostics;

public class ScriptRunner
{
    private Process runningProcess = null;

    public async Task RunAsync(string exePath)
    {
        runningProcess = new Process();
        runningProcess.StartInfo.FileName = exePath;
        runningProcess.StartInfo.UseShellExecute = false;
        runningProcess.StartInfo.RedirectStandardOutput = false;
        runningProcess.StartInfo.RedirectStandardError = true;
        runningProcess.StartInfo.CreateNoWindow = true;
        runningProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        runningProcess.Start();
    }


    public void Stop()
    {
        if (runningProcess != null && !runningProcess.HasExited)
        {
            runningProcess.Kill(true);
            runningProcess.Dispose();
            runningProcess = null;
        }
    }
}
