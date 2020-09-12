using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.Models
{
    public class RolePermission
    {
        public int Id { get; set; }

        // تقديم الطلبات
        public bool ApplyRequests { get; set; }

        // عرض الصفحات
        public bool ViewPages { get; set; }
        
        // تعديل على الصفحات
        public bool EditPages{ get; set; }

        // حذف على الصفحات
        public bool DeletePages { get; set; }

        //اضافه على الصفحات
        public bool AddPages { get; set; }

        //الموافقه/رفض الطلبات
        public bool ApprovalRejectionRequests { get; set; }

        //اعطاء الصلاحيات الادارية للمستخدمين
        public bool GivingPermissionForUsers { get; set; }

        //انشاء سوبر ادمن
        public bool CreateSuperAdmin{ get; set; }

        //حذف اسم من الشجرة
        public bool DeleteFromFamilyTree { get; set; }

        //حذف والغاء الطلبات
        public bool DeleteRequrest { get; set; }

        //تعليق وايقاف الطلبات
        public bool BlockRequests { get; set; }

        //اعطاء الصلاحيات
        public bool GivinPermission { get; set; }

        public bool IsDelete { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
