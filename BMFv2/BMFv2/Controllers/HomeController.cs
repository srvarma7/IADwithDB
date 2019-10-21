using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//For PDF generation
using IronPdf;

namespace BMFv2.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Nav()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult OnlineUsers()
        {
            ViewBag.Message = "Your online users page.";

            return View();
        }

        public ActionResult invoice()
        {
            return View();
        }

        public ActionResult PDFGenS()
        {
            return View();
        }

        public ActionResult PDFGenF()
        {
            return View();
        }

        public ActionResult GeneratePDF()
        {
            //var PDF = Renderer.RenderHTMLFileAsPdf("https://localhost:44335/Home/About.cshtml");
            //var PDF = Renderer.RenderHTMLFileAsPdf("C:/Users/Raghu/Desktop/BMF/IAD/BMFv2/BMFv2/Views/Home/Index.cshtml");
            try
            {
                var Renderer = new IronPdf.HtmlToPdf();
                var PDF = Renderer.RenderUrlAsPdf("https://localhost:44335/Home/invoice");

                //CHANGE THE FILE PATH TO GENERATE PDF
                //Setting the path location to store the pdf
                var OutputPath = "C:/Users/Raghu/Desktop/Invoice.pdf";
                PDF.SaveAs(OutputPath);
                ViewBag.Message = "PDF generated Successfully";
                return RedirectToAction("PDFGenS");
            }
            catch
            {

            }

            return RedirectToAction("PDFGenF");
        }
    }
}