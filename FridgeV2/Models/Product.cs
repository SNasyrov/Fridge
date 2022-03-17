namespace FridgeV2.Models
{
    public class Product
    {
        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название продукта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор производителя
        /// </summary>
        public int ManufacturerId { get; set; }

        /// <summary>
        /// Производитель
        /// </summary>
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Категории
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Проверка
        /// </summary>
        public bool IsConfirmed { get; set; }

        /// <summary>
        /// Продукт нравится
        /// </summary>
        public bool LikeTheProduct { get; set; }



    }
}
