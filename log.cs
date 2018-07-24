// log text to text file and show it in the UI

 private void Log(string log_text)
{
    txtLog.AppendText(log_text + "\r\n");
    txtLog.ScrollToEnd();
    string LogPath = @"C:\_log\";
    try
    {
        if (!Directory.Exists(LogPath))
        {
            // Try to create the directory.
            Directory.CreateDirectory(LogPath);
        }
        string FilePath = LogPath + "_"+ DateTime.Now.ToString("dd.MM.yyyy") + ".txt";
        File.AppendAllText(FilePath, log_text + "\r\n");
    }
    catch (Exception ex)
    {
        txtLog.AppendText("ERROR WRITING LOG FILE" + "\r\n");
        txtLog.AppendText(ex.Message);
    }
    DoEvents();
}

private static void DoEvents() // wpf window update
{
    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
} // refresh app 
