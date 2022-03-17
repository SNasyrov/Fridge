using Microsoft.AspNetCore.Identity;

namespace FridgeV2.Models
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class User : IdentityUser
    {

        /// <summary>
        /// Отображаемое имя
        /// </summary>
        public string FirstName { get; set; }
    }
}
