using System;
using System.ComponentModel;

namespace FridgeV2.Models
{
    public class ProductInFridge

    {
        /// <summary>
        /// Идентификатор продукта в холодильнике
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        [DisplayName("Продукт")]
        public int ProductId { get; set; }

        /// <summary>
        /// Продукт
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [DisplayName("Пользователь")]
        public string UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Срок годности
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Дата покупки
        /// </summary>
        public DateTime PurchaseDate { get; set; } = DateTime.Today;

        /// <summary>
        /// Идентификатор магазины
        /// </summary>
        [DisplayName("Магазин")]
        public int ShopId { get; set; }

        /// <summary>
        /// Магазин
        /// </summary>
        public Shop Shop { get; set; }

        /// <summary>
        /// Сохранить в список покупок
        /// </summary>
        public bool SaveToList { get; set; }
    }
}
