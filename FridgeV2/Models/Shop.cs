using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FridgeV2.Models
{
    /// <summary>
    /// Модель магазина
    /// </summary>
    public class Shop
    {
        /// <summary>
        /// Идентификатор магазина
        /// </summary>
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        /// <summary>
        /// Название магазина
        /// </summary>
        [DisplayName("Название")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Адрес магазина
        /// </summary>
        [DisplayName("Адрес")]
        public string Address { get; set; }

        /// <summary>
        /// Проверка
        /// </summary>
        public bool IsConfirmed { get; set; }
    }
}
