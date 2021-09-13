using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DAL;
using Models;

namespace API.Controllers
{
    [RoutePrefix("api/image")]

    public class ImageController : ApiController
    {
        ImageModel img = new ImageModel();

        [HttpPost]
        [Route("uploadimage")]
        public void UploadImage(string name)
        {
            //string filePath = "";
            //var files = System.Web.HttpContext.Current.Request.Form.Files;
            //if(files != null)
            //{
            //    foreach (var file in files)
            //    {
            //        var fileName = file;
            //    }
            //}


            //string puthUploadImage = "C:/Users/IMOE001/Desktop/ClientSide/comforTableClientSide/src/ssets/UploadImages";

            //HttpPostedFile file = HttpContext.Current.Request.Files[0];
            //img.PuthImaje1 = HttpContext.Current.Server.MapPath("~/Content/Images/" + file.FileName);
            //file.SaveAs(img.PuthImaje1);
       





            //using (FileStream fs = System.IO.File.Create(fileName))
            //{
            //    Uploadfile.CopyTo(fs);
            //    fs.Flush();
            //}

        }

        [HttpPost]
        [Route("UploadImage")]
        public void UploadImage()
        {
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
            //Upload Image
            var postedFile = httpRequest.Files[0];
            //Create custom filename
            if (postedFile != null)
            {
                imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray())+".png";
                //imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
                var filePath = HttpContext.Current.Server.MapPath("~/Resourses/Images/" + imageName);
                postedFile.SaveAs(filePath);
                //System.IO.File.Copy(imageName, filePath);
                File.Copy(@"‏‏C:\Users\IMOE001\Pictures\" + postedFile.FileName ,filePath);
            }
        }
    }
}
