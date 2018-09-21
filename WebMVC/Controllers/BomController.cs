using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class BomController : Controller
    {
        SiemensBomEntities db = new SiemensBomEntities();
        HP db2=new HP();
        // GET: Bom
        public ActionResult Index()
        {
            var b = db.T_User;
       //   var a=  db.T_User.Include("").ToList() ;

          var c=  db2.Users.ToList();
            return View();
        }
        public void Export()
        {
            var b = db.T_User;
            var a = db.T_User.ToList();

           


                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.ClearContent();
                System.Web.HttpContext.Current.Response.ClearHeaders();
                System.Web.HttpContext.Current.Response.Buffer = true;
                System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";

                System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=rptPayment.xlsx");
                //System.Web.HttpContext.Current.Response.Charset = "utf-8";
                //System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");

                View(b).ExecuteResult(this.ControllerContext);

                System.Web.HttpContext.Current.Response.Flush();
                System.Web.HttpContext.Current.Response.End();
            
            //return View();
        }
        public void ExporttoExcel()
        {
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ClearContent();
            System.Web.HttpContext.Current.Response.ClearHeaders();
            System.Web.HttpContext.Current.Response.Buffer = true;
            System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";

            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=rptPayment.xls");
            System.Web.HttpContext.Current.Response.Charset = "utf-8";
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");

            System.Web.HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            System.Web.HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            System.Web.HttpContext.Current.Response.Write("<BR><BR><BR>");
            ////sets the table border, cell spacing, border color, font of the text, background, foreground, font height
            System.Web.HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
              "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
              "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
            //get column header
            System.Web.HttpContext.Current.Response.Write("<Td>");
            System.Web.HttpContext.Current.Response.Write("<B>");
            System.Web.HttpContext.Current.Response.Write("a");
            System.Web.HttpContext.Current.Response.Write("</B>");
            System.Web.HttpContext.Current.Response.Write("</Td>");
            System.Web.HttpContext.Current.Response.Write("<Td>");
            System.Web.HttpContext.Current.Response.Write("<B>");
            System.Web.HttpContext.Current.Response.Write("b");
            System.Web.HttpContext.Current.Response.Write("</B>");
            System.Web.HttpContext.Current.Response.Write("</Td>");
            System.Web.HttpContext.Current.Response.Write("</TR>");
            System.Web.HttpContext.Current.Response.Write("<TR>");
            System.Web.HttpContext.Current.Response.Write("<Td>");
            System.Web.HttpContext.Current.Response.Write("<B>");
            System.Web.HttpContext.Current.Response.Write("a1");
            System.Web.HttpContext.Current.Response.Write("</B>");
            System.Web.HttpContext.Current.Response.Write("</Td>");
            System.Web.HttpContext.Current.Response.Write("<Td>");
            System.Web.HttpContext.Current.Response.Write("<B>");
            System.Web.HttpContext.Current.Response.Write("b1");
            System.Web.HttpContext.Current.Response.Write("</B>");
            System.Web.HttpContext.Current.Response.Write("</Td>");
            System.Web.HttpContext.Current.Response.Write("</TR>");
            System.Web.HttpContext.Current.Response.Write("</Table>");
            System.Web.HttpContext.Current.Response.Write("</font>");

            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }
        public void ExporttoExcel2()
        {

            //data:application/vnd.ms-excel;FileFormat:52

            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ClearContent();
            System.Web.HttpContext.Current.Response.ClearHeaders();
            System.Web.HttpContext.Current.Response.Buffer = true;
            System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";
            // System.Web.HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";            
            //System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=rptPayment.xls");
            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=rptPayment3.xlsx");
            System.Web.HttpContext.Current.Response.Charset = "utf-8";
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");

            // View("~/Views/Home/Index2.cshtml").ExecuteResult(this.ControllerContext);

            //or
            //System.Web.HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            //System.Web.HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            //System.Web.HttpContext.Current.Response.Write("<BR><BR><BR>");
            //////sets the table border, cell spacing, border color, font of the text, background, foreground, font height
            System.Web.HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
              "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
              "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
            //get column header
            System.Web.HttpContext.Current.Response.Write("<Td>");
            System.Web.HttpContext.Current.Response.Write("<B>");
            System.Web.HttpContext.Current.Response.Write("a");
            System.Web.HttpContext.Current.Response.Write("</B>");
            System.Web.HttpContext.Current.Response.Write("</Td>");
            System.Web.HttpContext.Current.Response.Write("<Td>");
            System.Web.HttpContext.Current.Response.Write("<B>");
            System.Web.HttpContext.Current.Response.Write("b");
            System.Web.HttpContext.Current.Response.Write("</B>");
            System.Web.HttpContext.Current.Response.Write("</Td>");
            System.Web.HttpContext.Current.Response.Write("</TR>");
            System.Web.HttpContext.Current.Response.Write("<TR>");
            System.Web.HttpContext.Current.Response.Write("<Td>");
            System.Web.HttpContext.Current.Response.Write("<B>");
            System.Web.HttpContext.Current.Response.Write("a1");
            System.Web.HttpContext.Current.Response.Write("</B>");
            System.Web.HttpContext.Current.Response.Write("</Td>");
            System.Web.HttpContext.Current.Response.Write("<Td>");
            System.Web.HttpContext.Current.Response.Write("<B>");
            System.Web.HttpContext.Current.Response.Write("b1");
            System.Web.HttpContext.Current.Response.Write("</B>");
            System.Web.HttpContext.Current.Response.Write("</Td>");
            System.Web.HttpContext.Current.Response.Write("</TR>");
            System.Web.HttpContext.Current.Response.Write("</Table>");
            //System.Web.HttpContext.Current.Response.Write("</font>");


            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }
        public void ExportData()
        {
            Response.ClearContent();
            //
            Response.ContentType = "application/vnd.xls";
           // Response.ContentType = "application/force-download";
            Response.AddHeader("content-disposition",
                "attachment; filename=" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
           Response.Charset = "utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
            Response.Write("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
            Response.Write("<head>");
            Response.Write("<META http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            //string fileCss = Server.MapPath("~/css/daoChuCSS.css");
            //string cssText = string.Empty;
            //StreamReader sr = new StreamReader(fileCss);
            //var line = string.Empty;
            //while ((line = sr.ReadLine()) != null)
            //{
            //    cssText += line;
            //}
            //sr.Close();
            //Response.Write("<style>" + cssText + "</style>");
            Response.Write("<!--[if gte mso 9]><xml>");
            Response.Write("<x:ExcelWorkbook>");
            Response.Write("<x:ExcelWorksheets>");
            Response.Write("<x:ExcelWorksheet>");
            Response.Write("<x:Name>Report Data</x:Name>");
            Response.Write("<x:WorksheetOptions>");
            Response.Write("<x:Print>");
            Response.Write("<x:ValidPrinterInfo/>");
            Response.Write("</x:Print>");
            Response.Write("</x:WorksheetOptions>");
            Response.Write("</x:ExcelWorksheet>");
            Response.Write("</x:ExcelWorksheets>");
            Response.Write("</x:ExcelWorkbook>");
            Response.Write("</xml>");
            Response.Write("<![endif]--> ");

            var b = db.T_User;
            View(b).ExecuteResult(this.ControllerContext);
            
            Response.Flush();
            Response.End();
        }
        public void ExportData1()
        {
            //Workbook workbook = new Workbook();
            //workbook.LoadFromFile(@"..\..\test.xml");
            //workbook.SaveToFile("sample.xlsx", ExcelVersion.Version2010);

            Response.ClearContent();
            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
            Response.AddHeader("content-disposition",
                "attachment; filename=" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
           // Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
          
            Response.Charset = "utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
            Response.Write("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
            Response.Write("<head>");
            //Response.Write("<META http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            //string fileCss = Server.MapPath("~/css/daoChuCSS.css");
            //string cssText = string.Empty;
            //StreamReader sr = new StreamReader(fileCss);
            //var line = string.Empty;
            //while ((line = sr.ReadLine()) != null)
            //{
            //    cssText += line;
            //}
            //sr.Close();
            //Response.Write("<style>" + cssText + "</style>");
            Response.Write("<!--[if gte mso 9]><xml>");
            Response.Write("<x:ExcelWorkbook>");
            Response.Write("<x:ExcelWorksheets>");
            Response.Write("<x:ExcelWorksheet>");
            Response.Write("<x:Name>Report Data</x:Name>");
            Response.Write("<x:WorksheetOptions>");
            Response.Write("<x:Print>");
            Response.Write("<x:ValidPrinterInfo/>");
            Response.Write("</x:Print>");
            Response.Write("</x:WorksheetOptions>");
            Response.Write("</x:ExcelWorksheet>");
            Response.Write("</x:ExcelWorksheets>");
            Response.Write("</x:ExcelWorkbook>");
            Response.Write("</xml>");
            Response.Write("<![endif]--> ");

            var b = db.T_User;
            View(b).ExecuteResult(this.ControllerContext);
            Response.TransmitFile(Server.MapPath("~/App_Data/Test.xlsx"));
            Response.Flush();
            Response.End();
        }

        public void ExporttoExcel6()
        {
            //XSSFWorkbook wb = new XSSFWorkbook();
            //XSSFSheet sh = (XSSFSheet)wb.CreateSheet("Instructional Hrs");

            //Create Header Row
            //var headerRow1 = sh.CreateRow(0);
            //headerRow1.CreateCell(0).SetCellValue("Jimmy G Rocks!!");

            //using (var stream = new MemoryStream())
            //{
            Response.Clear();
               
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition",
                    string.Format("attachment;filename={0}", "CCR Student Instructional Hours.xlsx"));
                //Response.BinaryWrite(stream.ToArray());
                var b = db.T_User;
                View(b).ExecuteResult(this.ControllerContext);
                Response.Flush();
                System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
                Response.Close();
            //}
        }

        public void ExporttoExcel3()
        {


 

            //data:application/vnd.ms-excel;FileFormat:52

            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ClearContent();
            System.Web.HttpContext.Current.Response.ClearHeaders();
            System.Web.HttpContext.Current.Response.Buffer = true;
            //or  System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";
            System.Web.HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";            
            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition",
                "attachment;filename=rptPayment11111.xlsx");
            System.Web.HttpContext.Current.Response.Charset = "utf-8";
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");

            var b = db.T_User;
            View(b).ExecuteResult(this.ControllerContext);
         
            System.Web.HttpContext.Current.Response.Flush();
            //System.Web.HttpContext.Current.Response.End();
            System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
            Response.Close();


            //System.Web.HttpContext.Current.Response.Flush();
            //System.Web.HttpContext.Current.Response.End();
        }
        public ActionResult ExporttoExcel4()
        {




            //data:application/vnd.ms-excel;FileFormat:52

            //System.Web.HttpContext.Current.Response.Clear();
            //System.Web.HttpContext.Current.Response.ClearContent();
            //System.Web.HttpContext.Current.Response.ClearHeaders();
            //System.Web.HttpContext.Current.Response.Buffer = true;
            //System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";
            ////or System.Web.HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";            
            //System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition",
            //    "attachment;filename=rptPayment11111.xlsx");
            //System.Web.HttpContext.Current.Response.Charset = "utf-8";
            //System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");

            var b = db.T_User;
            View(b).ExecuteResult(this.ControllerContext);

            Stream d = Response.OutputStream;
            // d.CanRead = true;
            MemoryStream objMemoryStream = new MemoryStream();
            d.CopyTo(objMemoryStream);
            var responseString = new StreamReader(objMemoryStream).ReadToEnd();
            return File(responseString, "application/ms-excel");

            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }

        public  void Export333()
        {
           
                // Create a list of accounts.
                var bankAccounts = new List<Account>
                {
                    new Account {
                        ID = 345678,
                        Balance = 541.27
                    },
                    new Account {
                        ID = 1230221,
                        Balance = -127.44
                    }
                };



                DisplayInExcel(bankAccounts, (account, cell) =>
                    // This multiline lambda expression sets custom processing rules
                    // for the bankAccounts.
                {
                    cell.Value = account.ID;
                    cell.Offset[0, 1].Value = account.Balance;
                    if (account.Balance < 0)
                    {
                        cell.Interior.Color = 255;
                        cell.Offset[0, 1].Interior.Color = 255;
                    }
                });

                // Display the list in an Excel spreadsheet.
                //Walkthrough. DisplayInExcel(bankAccounts);
                // Create a Word document that contains an icon that links to
                // the spreadsheet.
               
            
        }
        public static void DisplayInExcel(IEnumerable<Account> accounts,
            Action<Account, Microsoft.Office.Interop.Excel.Range> DisplayFunc)
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
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