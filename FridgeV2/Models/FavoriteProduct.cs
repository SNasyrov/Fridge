namespace FridgeV2.Models
{
    /// <summary>
    /// Модель любимый продукт
    /// </summary>
    public class FavoriteProduct
    {
        /// <summary>
        /// Идентификатор любимого продукта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public string ManufacturerName { get; set; }

    }
}
