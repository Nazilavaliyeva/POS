// Fayl: Business/KateqoriyaServisi.cs

using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.Business
{
    /// <summary>
    /// Kateqoriyalarla bağlı biznes məntiqini idarə edir.
    /// </summary>
    public class KateqoriyaServisi
    {
        /// <summary>
        /// Bütün kateqoriyaların siyahısını qaytarır.
        /// </summary>
        public List<Category> GetirButunKateqoriyalari()
        {
            return DataAccess.GetAllCategories();
        }

        /// <summary>
        /// Yeni kateqoriya əlavə edir.
        /// </summary>
        public void ElaveEt(string ad)
        {
            if (string.IsNullOrWhiteSpace(ad))
            {
                throw new Exception("Kateqoriya adı boş ola bilməz.");
            }
            // Add validation for existing category if needed
            DataAccess.AddCategory(ad);
        }

        /// <summary>
        /// Kateqoriyanı yeniləyir.
        /// </summary>
        public void Yenile(int id, string yeniAd)
        {
            if (string.IsNullOrWhiteSpace(yeniAd))
            {
                throw new Exception("Kateqoriya adı boş ola bilməz.");
            }
            DataAccess.UpdateCategory(id, yeniAd);
        }

        /// <summary>
        /// Kateqoriyanı silir, əgər istifadədə deyilsə.
        /// </summary>
        public void Sil(int id)
        {
            if (DataAccess.IsCategoryInUse(id))
            {
                throw new Exception("Bu kateqoriya məhsullarda istifadə olunduğu üçün silinə bilməz.");
            }
            DataAccess.DeleteCategory(id);
        }
    }
}