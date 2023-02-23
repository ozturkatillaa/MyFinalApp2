using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    //static sabit tutyor newlemeye gerek yok
    public static class Messages
    {
        public static string CategoryLimitExceded ="Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string ProductNameAlreadyExists = "Bu isimde zaten aynı ürün var";
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductNameValid= "Ürün ismi geçersiz.";
        public static string MaintenanceTime="saati gçti";
        public static string ProductListed="listelendi urunler";
        public static string ProductCountofCategoryError = "Bir Kategoride en fazla 10 ürün olabilir";
        public static string AuthorizationDenied = "yetki reddedildi";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Paralo hatası";
        public static string SuccessfulLogin = "başarılı giriş";
        public static string UserAlreadyExists = "kullancı mevcut";
        public static string AccessTokenCreated = "giriş token ı oluşturuldu";
        public static string ProductDeleted = "Urun Silindi";
    }
}
