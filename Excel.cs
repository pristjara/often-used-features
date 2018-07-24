using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;

private static void ReleaseMemory(object obj) // function that closes excel and clears memory
{
    try
    {
        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj); // releases COM objects from memory
        obj = null;
    }
    catch (Exception)
    {
        obj = null;
    }
    finally
    {
        GC.Collect(); // "garbage collector" - "collects" all unused connections
    }
}

private void ReadFile()
{
   // open file
  OpenFileDialog openFileDialog = new OpenFileDialog();
  openFileDialog.DefaultExt = ".xlsx";
  openFileDialog.Filter = "XLSX Files (*.xlsx)|*.xlsx|XLS Files (*.xls)|*.xls";

  var result = openFileDialog.ShowDialog(); // nullable bool

  // get file name
  string filename = string.Empty;
  if (result == true)
  {
      filename = openFileDialog.FileName;
  }
  else
  {
      MessageBox.Show("No File selected");
      return;
  }

  // declare excel file
  Excel.Application application = new Excel.Application();
  application.DisplayAlerts = false;
  Excel.Workbook workbook = application.Workbooks.Open(filename);
  Excel._Worksheet worksheet = workbook.Sheets[1];
  Excel.Range range = worksheet.UsedRange;

  //read file to list
  try
  {
      int lineRead = 2;
      // Begin reading file.
      while (!((Excel.Range)range.Cells[lineRead, 1]).Text.ToString().Trim().Equals("")) // while cell not empty
      {
          string text;
          text = ((Excel.Range)range.Cells[lineRead, 1]).Text.ToString();
          list.Add(text);
          lineRead++;
      }
      // File reading complete.
  }
  catch (Exception ex)
  {
      MessageBox.Show("Error reading excel file" + "\r\n\r\n" + ex.Message);
      return;
  }
} // read file

private void WriteToFile()
{ 
  // Saving to file
  
  int line = 2;
  foreach (var item in list)
  {
      worksheet.Cells[line, 2] = item;
  }

  workbook.Save();
  application.Quit();

  ReleaseMemory(application);
  ReleaseMemory(workbook);
  ReleaseMemory(worksheet);

 // Saved 
}
