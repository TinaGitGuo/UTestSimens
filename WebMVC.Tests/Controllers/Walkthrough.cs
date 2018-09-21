﻿using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.Tests.Controllers
{
  public  class Walkthrough
    {

        //public static void DisplayInExcel(IEnumerable<Account> accounts)
        //{
        //    var excelApp = new Microsoft.Office.Interop.Excel.Application();
        //    // Make the object visible.
        //    excelApp.Visible = true;
        //    // Create a new, empty workbook and add it to the collection returned
        //    // by property Workbooks. The new workbook becomes the active workbook.
        //    // Add has an optional parameter for specifying a praticular template.
        //    // Because no argument is sent in this example, Add creates a new workbook.
        //    excelApp.Workbooks.Add();
        //    // This example uses a single workSheet.
        //    Microsoft.Office.Interop.Excel._Worksheet workSheet = excelApp.ActiveSheet;
        //    // Earlier versions of C# require explicit casting.
        //    //Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;
        //    // Establish column headings in cells A1 and B1.
        //    workSheet.Cells[1, "A"] = "ID Number";
        //    workSheet.Cells[1, "B"] = "Current Balance";
        //    var row = 1;
        //    foreach (var acct in accounts)
        //    {
        //        row++;
        //        workSheet.Cells[row, "A"] = acct.ID;
        //        workSheet.Cells[row, "B"] = acct.Balance;
        //    }
        //   // The following code shows the complete example.
        //    workSheet.Columns[1].AutoFit();
        //    workSheet.Columns[2].AutoFit();
        //    // Call to AutoFormat in Visual C#. This statement replaces the
        //    // two calls to AutoFit.
        //    workSheet.Range["A1", "B3"].AutoFormat(
        //    Microsoft.Office.Interop.Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);
        //    // Put the spreadsheet contents on the clipboard. The Copy method has one
        //    // optional parameter for specifying a destination. Because no argument
        //    // is sent, the destination is the Clipboard.
        //    workSheet.Range["A1:B3"].Copy();
            
        //}
        public static void CreateIconInWordDoc()
        {
            var wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = true;
            // The Add method has four reference parameters, all of which are
            // optional. Visual C# allows you to omit arguments for them if
            // the default values are what you want.
            wordApp.Documents.Add();
            // PasteSpecial has seven reference parameters, all of which are
            // optional. This example uses named arguments to specify values
            // for two of the parameters. Although these are reference
            // parameters, you do not need to use the ref keyword, or to create
            // variables to send in as arguments. You can send the values directly.
            wordApp.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);
        }
      public static void DisplayInExcel(IEnumerable<Account> accounts,
            Action<Account, Microsoft.Office.Interop.Excel.Range> DisplayFunc)
        {
            var excelApp =new Microsoft.Office.Interop.Excel.Application();
            // Add a new Excel workbook.
            excelApp.Workbooks.Add();
            excelApp.Visible = true;
            excelApp.Range["A1"].Value = "ID";
            excelApp.Range["B1"].Value = "Balance";
            excelApp.Range["A2"].Select();
            foreach (var ac in accounts)
            {
                DisplayFunc(ac, excelApp.ActiveCell);
                excelApp.ActiveCell.Offset[1, 0].Select();
            }
            // Copy the results to the Clipboard.
            excelApp.Range["A1:B3"].Copy();
        }
    }
    public class Account
    {
        public int ID { get; set; }
        public double Balance { get; set; }
    }
 
}
