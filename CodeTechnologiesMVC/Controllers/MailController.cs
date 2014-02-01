using CodeTechnologiesMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data.OleDb;
using System.Data;

namespace CodeTechnologiesMVC.Controllers
{
    public class MailController : Controller
    {
        //
        // GET: /Mail/

        public ActionResult Index(string SearchString, int? page)
        {
            using (var db = new sadiqEntities2())
            {
                IEnumerable<MailViewModel> mails = db.GetMailDetails();
                if (!String.IsNullOrEmpty(SearchString))
                {
                    mails = mails.Where(m => m.CandidateName.ToUpper().Contains(SearchString.ToUpper()));
                }
                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(mails.ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(mail mailObj)
        {
            using (var db = new sadiqEntities2())
            {
                db.mails.Add(mailObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        public ActionResult ImportMailExcelFileToDB()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImportMailExcelFileToDB(HttpPostedFileBase file)
        {
            if (Request.Files["FileUpload"].ContentLength > 0)
            {
                string fileExtension = System.IO.Path.GetExtension(Request.Files["FileUpload"].FileName);
                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    string fileLocation = Server.MapPath("~/App_Data/ExcelFiles") + "/" + Request.Files["FileUpload"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                        System.IO.File.Delete(fileLocation);

                    Request.Files["FileUpload"].SaveAs(fileLocation);
                    string excelConnectionString = String.Empty;

                    excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    if (fileExtension == ".xls")
                    {
                        excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    //connection String for xlsx file format.
                    else if (fileExtension == ".xlsx")
                    {

                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                    excelConnection.Open();
                    DataTable dt = new DataTable();

                    dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dt == null)
                    {
                        return null;
                    }
                    String[] excelSheets = new String[dt.Rows.Count];
                    int t = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[t] = row["TABLE_NAME"].ToString();
                        t++;
                    }
                    OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);
                    DataSet ds = new DataSet();

                    string query = string.Format("Select * from [{0}]", excelSheets[0]);
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                    {
                        dataAdapter.Fill(ds);
                    }
                    using (var db = new sadiqEntities2())
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            mail tempmailObj = new mail();
                            //int instituteId = (int)db.institutes.Where(inst => inst.Name == ds.Tables[0].Rows[i]["Name"].ToString()).Single(n => n.Id);
                            string instituteName = ds.Tables[0].Rows[i]["Name"].ToString();
                            int instituteId = db.institutes.First(inst => String.Equals(inst.Name, instituteName)).Id;
                            tempmailObj.ReceivedDate = (DateTime)ds.Tables[0].Rows[i]["ReceivedDate"];
                            tempmailObj.CandidateName = ds.Tables[0].Rows[i]["CandidateName"].ToString();
                            tempmailObj.ExamNo = ds.Tables[0].Rows[i]["ExamNo"].ToString();
                            tempmailObj.Discount = Convert.ToInt32(ds.Tables[0].Rows[i]["Discount"]);
                            tempmailObj.Abroad = Convert.ToBoolean(ds.Tables[0].Rows[i]["Abroad"]);
                            tempmailObj.ScheduledDate = (DateTime)ds.Tables[0].Rows[i]["ScheduledDate"];
                            tempmailObj.InstituteId = instituteId;
                            tempmailObj.VoucherNo = ds.Tables[0].Rows[i]["VoucherNo"].ToString();
                            tempmailObj.client = ds.Tables[0].Rows[i]["Client"].ToString();
                            tempmailObj.CommittedPrice = Convert.ToInt32(ds.Tables[0].Rows[i]["CommittedPrice"]);

                            db.mails.Add(tempmailObj);
                            db.SaveChanges();
                        }
                    }
                }
                else
                {
                    //Error PAge Naviagation
                }
            }

            return RedirectToAction("Index");
        }

    }
}
