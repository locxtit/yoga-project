using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yoga.Bussiness;
using Yoga.Entity;
using Yoga.Entity.Enums;
using Yoga.Entity.Models;
using Yoga.Web.Controls;
using Yoga.Web.Infrastructure.Extensions;
using Yoga.Web.Models;

namespace Yoga.Web.Controllers
{
    public class ExcelController : Controller
    {

        public void WriteHtmlTable<T>(IEnumerable<T> data, TextWriter output)
        {
            //Writes markup characters and text to an ASP.NET server control output stream. This class provides formatting capabilities that ASP.NET server controls use when rendering markup to clients.
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {

                    //  Create a form to contain the List
                    Table table = new Table();
                    TableRow row = new TableRow();
                    PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
                    foreach (PropertyDescriptor prop in props)
                    {
                        TableHeaderCell hcell = new TableHeaderCell();
                        hcell.Text = prop.Name;
                        hcell.BackColor = Color.FromArgb(47, 117, 181);
                        hcell.ForeColor = Color.FromArgb(255, 255, 255);
                        hcell.Font.Bold = true;
                        row.Cells.Add(hcell);
                    }

                    table.Rows.Add(row);

                    //  add each of the data item to the table
                    foreach (T item in data)
                    {
                        row = new TableRow();
                        foreach (PropertyDescriptor prop in props)
                        {
                            TableCell cell = new TableCell();
                            cell.Text = prop.Converter.ConvertToString(prop.GetValue(item));
                            cell.BorderColor = Color.FromArgb(221, 221, 221);
                            cell.BorderStyle = BorderStyle.Solid;
                            cell.BorderWidth = 1;
                            row.Cells.Add(cell);
                        }
                        table.Rows.Add(row);
                    }

                    //  render the table into the htmlwriter
                    table.RenderControl(htw);

                    //  render the htmlwriter into the response
                    output.Write(sw.ToString());
                }
            }

        }

        public ActionResult ExportToExcel(DataTable data, string fileName, string sheetName)
        {

            using (MemoryStream mem = new MemoryStream())
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(data, sheetName);
                    wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    wb.Style.Font.Bold = true;

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename= "+fileName + DateTime.Now.ToString("yyMMddHHmmss") +".xlsx");

                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }  
            }

            return View();
        }

        public static DataTable ToDataTable<T>(IEnumerable<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            var listColumnNames = new List<string>();
            foreach (PropertyDescriptor prop in properties)
            {
                
                MemberInfo property = typeof(T).GetProperty(prop.Name);
                var attribute = property.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                    .Cast<DisplayNameAttribute>().Single();
                string displayName = attribute.DisplayName;
                table.Columns.Add(displayName, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                listColumnNames.Add(displayName);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                var i = 0;
                foreach (PropertyDescriptor prop in properties)
                {
                    row[listColumnNames[i]] = prop.GetValue(item) ?? DBNull.Value;
                    i++;
                }
                table.Rows.Add(row);
            }
            return table;
        }

        public ActionResult TrainerExport(string email, string phone, string trainerName)
        {
            var criteria = new SearchTrainerCriteriaModel()
            {
                Email = email,
                Phone = phone,
                TrainerName = trainerName,
            };
            var trainerBll = new TrainerBll();
            var trainers = trainerBll.Search(criteria).OrderByDescending(x => x.CreatedDate);
            var model = new List<TrainerExportModel>();
            foreach (var trainer in trainers)
            {
                var bankInfo = trainer.BankInfos.FirstOrDefault(x => x.StatusId == StatusEnum.ACTIVE.ToString());
                var trainerExport = new TrainerExportModel
                {
                    Address = trainer.Address,
                    Email = trainer.Email,
                    Experience = trainer.Experience,
                    Phone = trainer.Phone,
                    Subject = trainer.Subject,
                    TrainerName = trainer.TrainerName,
                };
                if (bankInfo != null)
                {
                    trainerExport.BankId = bankInfo.BankId;
                    trainerExport.BankBrand = bankInfo.BankBrand;
                    trainerExport.BankName = bankInfo.BankName;
                    trainerExport.BankNumber = bankInfo.BankNumber;
                }

                model.Add(trainerExport);

            }
            return ExportToExcel(ToDataTable<TrainerExportModel>(model), "hlv-", "DS Huấn Luận Viên");
        }

        public ActionResult CustomerExport(string customerName, string phone, string customerTypeId, string customerStatusId)
        {
            SearchCustomerCriteriaModel criteria = new SearchCustomerCriteriaModel()
            {
                CustomerTypeId = customerTypeId,
                CustomerStatusId = customerStatusId,
                CustomerName = customerName,
                Phone = phone
            };
            var customerBll = new CustomerBll();
            var customers = customerBll.Search(criteria).OrderByDescending(x => x.CreatedDate);
            var model = new List<CustomerExportModel>();
            foreach (var customer in customers)
            {
                var customerExport = new CustomerExportModel
                {
                    Address = customer.Address,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Name = customer.Name,
                    ProvinceName = customer.Province.ProvinceName,
                    StatusName = customer.Status.StatusName,
                    CustomerStatusName = customer.CustomerStatus.CustomerStatusName,
                    CustomerTypeName = customer.CustomerType.CustomerTypeName
                };
                model.Add(customerExport);
            }
            return ExportToExcel(ToDataTable<CustomerExportModel>(model), "hoc-ven-","DS Học viên");
        }

        public ActionResult ClassInfoExport(int? trainerId, string customerName)
        {
            SearchClassInfoCriteriaModel criteria = new SearchClassInfoCriteriaModel()
            {
                TrainerId = trainerId,
                CustomerName = customerName,
            };
            var classInfoBll = new ClassInfoBll();
            var classInfos = classInfoBll.Search(criteria).OrderByDescending(x => x.CreatedDate);
            var model = new List<ClassInfoExportModel>();
            foreach (var classInfo in classInfos)
            {
                var classInfoExport = new ClassInfoExportModel
                {
                    ClassName = classInfo.ClassName,
                    CustomerName = classInfo.Customer.Name,
                    CustomerPhone = classInfo.Customer.Phone,
                    Note = classInfo.Note,
                    Reply = classInfo.Reply,
                    TotalDays = classInfo.TotalDays,
                    TrainerName = classInfo.Trainer.TrainerName,
                    StartDate = classInfo.StartDate.ToString("dd/MM/yyyy"),
                    EndDate = classInfo.EndDate != null? classInfo.EndDate.Value.ToString("dd/MM/yyyy"):"",
                    Price =  classInfo.Price
                };
                model.Add(classInfoExport);
            }
            return ExportToExcel(ToDataTable<ClassInfoExportModel>(model), "lop-", "DS Lớp");
        }
    }
}
