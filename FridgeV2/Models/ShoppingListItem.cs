using System.ComponentModel;

namespace FridgeV2.Models
{
    /// <summary>
    /// Элемент списка покупок
    /// </summary>
    public class ShoppingListItem
    {
        /// <summary>
        /// Идентификатор элемента списка покупок
        /// </summary>
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        /// <summary>
        /// Количество продукта
        /// </summary>
        [DisplayName("Количество продукта")]
        public int AmountOfProduct { get; set; }

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
        /// Идентификатор продукта
        /// </summary>
        [DisplayName("Продукт")]
        public int ProductId { get; set; }

        /// <summary>
        /// Продукт
        /// </summary>
        public Product Product { get; set; }
    }
}
