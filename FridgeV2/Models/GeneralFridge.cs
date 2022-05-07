using System.ComponentModel;

namespace FridgeV2.Models
{
    /// <summary>
    /// Модель общего холодильника
    /// </summary>
    public class GeneralFridge
    {
        /// <summary>
        /// Идентификатор общего хдильника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор холодильника
        /// </summary>
        public int FridgeId { get; set; }

        /// <summary>
        /// Холодильник
        /// </summary>
        public ProductInFridge ProductInFridge { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [DisplayName("Пользователь")]
        public string UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; set; }
    }
}
