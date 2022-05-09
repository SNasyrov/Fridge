using System.ComponentModel.DataAnnotations;

namespace FridgeV2.Models
{
    /// <summary>
    /// Модель производитель
    /// </summary>
    public class Manufacturer
    {
        /// <summary>
        /// Идентификатор производителя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название производителя
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Юр.Адресс
        /// </summary>
        public string LegalAddress { get; set; }

        /// <summary>
        /// Физ.Адресс
        /// </summary>
        public string PhysicalAddress { get; set; }
    }
}
