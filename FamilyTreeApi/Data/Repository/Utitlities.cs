using FamilyTreeApi.Data.IRepository;
using FamilyTreeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.Repository
{
    public class Utitlities : ControllerBase, IUtitlities
    {
        private readonly IGeneralSettings _generalSettings;
        public Utitlities(IGeneralSettings generalSettings)
        {
            _generalSettings = generalSettings;
        }

        public DateTime GetKSADate()
        {
            DateTime serverTime = DateTime.Now;
            DateTime _localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "Arab Standard Time");
            return _localTime;
        }

        public DateTime ConvertDateToKSA(DateTime dateParam)
        {
            DateTime _localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateParam, TimeZoneInfo.Local.Id, "Arab Standard Time");
            return _localTime;
        }

        public DateTime GetDate(string date, string formate)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            var result = DateTime.ParseExact(date, formate, provider);
            return result;
        }

        public string GenerateToken(User user, AppSettings options)
        {
            var claims = new[]
           {
                new Claim("Id", user.Id.ToString()),
                new Claim("userName", user.UserName.ToString()),
                new Claim("Email", user.Email.ToString()),
                new Claim("PhoneNumber", user.PhoneNumber.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecritKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return token;
        }

        public string GetUserId()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            return userId;
        }

        public bool SendMail(List<string> ListUsersMails, string Body, string Subject)
        {
            try
            {
                Settings result = _generalSettings.GetSettings();

                SmtpClient client = new SmtpClient(result.MailServer.Trim(), result.MailServerPort);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(result.MailUserName, result.MailPassword);

                MailMessage mailMessage = new MailMessage();
                mailMessage.IsBodyHtml = true;
                mailMessage.From = new MailAddress(result.MailUserName);

                foreach (var item in ListUsersMails)
                    mailMessage.To.Add(item);

                mailMessage.Subject = Subject;
                mailMessage.Body = Body;
                //string userState = "Mail State";

                //client.SendAsync(mailMessage, null);
                client.Send(mailMessage); 
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public async Task SendMailAsync(List<string> ListUsersMails, string Body, string Subject)
        //{
        //    Settings result = _generalSettings.GetSettings();
        //    SmtpClient client = new SmtpClient(result.MailServer.Trim(), result.MailServerPort);
        //    client.EnableSsl = true;
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = new NetworkCredential(result.MailUserName, result.MailPassword);

        //    MailMessage mailMessage = new MailMessage();
        //    mailMessage.IsBodyHtml = true;
        //    mailMessage.From = new MailAddress(result.MailUserName);

        //    foreach (var item in ListUsersMails)
        //        mailMessage.To.Add(item);

        //    mailMessage.Subject = Subject;
        //    mailMessage.Body = Body;
        //    //string userState = "Mail State";

        //    client.SendAsync(mailMessage, null);
        //    //client.Send(mailMessage);
        //    await Task.CompletedTask;
        //}

        public string GetHijryDate(DateTime dt)
        {
            string HijriDate = "";
            DateTimeFormatInfo DTFormat = new CultureInfo("ar-SA", false).DateTimeFormat;
            DTFormat.Calendar = new System.Globalization.UmAlQuraCalendar();
            DTFormat.ShortDatePattern = "MM/dd/yyyy";
            HijriDate = dt.ToString("d", DTFormat);

            return HijriDate;
        }

        public string ToHijri(DateTime dt)
        {
            if (dt == null)
                return "";

            string format = "MM/dd/yyyy";
            string output = "";
            //Store CurrentCulture/CurrentUICulture
            var currentThreadCulture = Thread.CurrentThread.CurrentCulture;
            var currentThreadUiCulture = Thread.CurrentThread.CurrentUICulture;

            //Change CurrentCulture/CurrentUICulture To ar-SA to get hijri Date
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ar-SA");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar-SA");

            output = dt.ToString(format);
            Thread.CurrentThread.CurrentCulture = currentThreadCulture;
            Thread.CurrentThread.CurrentUICulture = currentThreadUiCulture;
            return output;
        }

        public DateTime GetDate_EG(DateTime dt)
        {
            string newDate = "";

            DateTimeFormatInfo DTFormat = new CultureInfo("ar-EG", false).DateTimeFormat;
            DTFormat.Calendar = new System.Globalization.UmAlQuraCalendar();

            DTFormat.ShortDatePattern = "MM/dd/yyyy";
            newDate = dt.ToString("d", DTFormat);

            return Convert.ToDateTime(newDate);
        }

        //public string ToHijri(this DateTime dt)
        //{
        //    string format = "MM/dd/yyyy";
        //    string output = "";
        //    //Store CurrentCulture/CurrentUICulture
        //    var currentThreadCulture = Thread.CurrentThread.CurrentCulture;
        //    var currentThreadUiCulture = Thread.CurrentThread.CurrentUICulture;

        //    //Change CurrentCulture/CurrentUICulture To ar-SA to get hijri Date
        //    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ar-SA");
        //    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar-SA");

        //    output = dt.ToString(format);
        //    Thread.CurrentThread.CurrentCulture = currentThreadCulture;
        //    Thread.CurrentThread.CurrentUICulture = currentThreadUiCulture;
        //    return output;
        //}

    }
}
