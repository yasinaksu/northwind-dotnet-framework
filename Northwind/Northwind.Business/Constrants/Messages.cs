using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Constrants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün başarıyla eklendi";
        public static string ProductUpdated = "Ürün başarıyla güncellendi";
        public static string ProductDeleted = "Ürün başarıyla silindi";

        public static string CategoryAdded = "Category başarıyla eklendi";
        public static string CategoryUpdated = "Category başarıyla güncellendi";
        public static string CategoryDeleted = "Category başarıyla silindi";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Kullanıcı başarıyla giriş yaptı";
        public static string UserAlreadyExist = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";
    }
}
