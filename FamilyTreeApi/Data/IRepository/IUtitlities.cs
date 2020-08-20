using FamilyTreeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Data.IRepository
{
    public interface IUtitlities
    {
        DateTime GetKSADate();
        DateTime ConvertDateToKSA(DateTime dt);
        DateTime GetDate(string date, string formate);
        string GenerateToken(User user, AppSettings options);
        string GetUserId();
        bool SendMail(List<string> ListUsersMails, string Body, string Subject);
        //Task SendMailAsync(List<string> ListUsersMails, string Body, string Subject);
        string GetHijryDate(DateTime dt);
        string ToHijri(DateTime dt);
        DateTime GetDate_EG(DateTime dt);
    }
}
