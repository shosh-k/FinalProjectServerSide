using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class EmailAndPayPal
    {
        //פעולה בשביל התשלום##
        public bool PayOfAppearance(int cardNum, int threeLetters, DateTime effect, int sumOfPay)
        {
            return false;
        }
        //שליחת הודעת אימייל לקונה/למוכר
        public int SendMailToUser(Users user, Products pro, int status)
        {
            User u = new User();
            try
            {
                string email = "comfortableapp2021@gmail.com";
                string password = "comforTable2021";
             

                var loginInfo = new NetworkCredential(email, password);
                var msg = new MailMessage();
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);


                msg.From = new MailAddress(email);
                msg.ReplyToList.Add(new MailAddress(user.EmailUser));
                msg.To.Add(new MailAddress(user.EmailUser));


                string sInsert = "מישהו אהב מאוד את המוצר שלך והחליט לקנות אותו." +
                   "נא המתן ליצירת קשר עם הלקוח.";
                msg.Subject = "הודעה על קניית מוצר";
                if (status == 1)
                {
                    var phone = u.GetUserById(int.Parse(pro.CodeSallerProduct.ToString())).PhoneUser;
                    sInsert = "ברכות על קנייתך ב comforTable." +
                        "עליך ליצור קשר עם המוכר בטלפון מספר: " + phone;

                    msg.Subject = "קנייתך הושלמה בהצלחה";
                }


                #region buildHtmlMessageBody
                string htmlBodyString = string.Format(
                      @"
                       <div style='  direction: rtl;
                                     background-color: rgb(240, 240, 240);
                                     font-family: Amerald;
                                     font-size:medium; '>
                           <div style='text-align:center'>
                               <h1>שלום!</h1>
                           </div>
                           <div style='  position: relative;
                                         padding: 0.75rem 1.25rem;
                                         margin-bottom: 1rem;
                                         margin-left: 7%;
                                         margin-right: 7%;
                                         border: 1px solid rgb(201, 23, 23);
                                         border-radius: 0.25rem;
                                         color:black;
                                         width: 75%;
                                         background-color: white;
                                         border-radius: 5px; '>
                               <label> {0} יקר/ה </label>
                               <br />
                               <label>{1}</label>
                               <br/>
                               <label> שם המוצר: {2}</label>
                               <br />
                               <label> תאור המוצר: {3}</label>
                               <br />
                           </div>"

                         , user.FirstNameUser + " " + user.LastNameUser, sInsert, pro.NameProduct, pro.DescriptionProduct);

                #endregion
                AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBodyString, null, MediaTypeNames.Text.Html);
                //alternateView.LinkedResources.Add(res);
                msg.AlternateViews.Add(alternateView);
                msg.IsBodyHtml = true;
                //msg.Attachments.Add(new Attachment(doctor.pictureDiploma));
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;
                smtpClient.Send(msg);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
