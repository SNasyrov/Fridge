﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FridgeV2.Models
{
    /// <summary>
    /// Модель списка рецептов
    /// </summary>
    public class RecipeList
    {
        /// <summary>
        /// Идентификатор рецепта
        /// </summary>
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        /// <summary>
        /// Название рецепта
        /// </summary>
        [DisplayName("Название рецепта")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Название продукта
        /// </summary>
        [DisplayName("Название продукта")]
        public string Product { get; set; }

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