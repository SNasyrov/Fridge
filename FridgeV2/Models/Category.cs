namespace FridgeV2.Models
{
    /// <summary>
    /// Модель категорий
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название категории
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор родительской категории
        /// </summary>
        public int? ParentСategoryId { get; set; }

        /// <summary>
        /// Родительская категория
        /// </summary>
        public Category ParentСategory { get; set; }
    }
}
