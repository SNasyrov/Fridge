using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FridgeV2.Data;
using FridgeV2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FridgeV2.Services
{
    public class NotificationService
    {
        /// <summary>
        /// Контекст базы данных
        /// </summary>
        private readonly ApplicationContext _db;

        /// <summary>
        /// Менеджер пользователей
        /// </summary>
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Доступ к текущему HttpContext
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        /// <param name="userManager">Менеджер пользователей</param>
        /// <param name="httpContextAccessor">Доступ к текущему HttpContext</param>
        public NotificationService(ApplicationContext context,
                                   UserManager<User> userManager,
                                   IHttpContextAccessor httpContextAccessor)
        {
            _db = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Получение списка уведомлений об испорченных продуктах
        /// </summary>
        public async Task<List<string>> GetNotificationAsync()
        {
            var expiredProduct = new List<string>();

            var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(currentUserId))
                return expiredProduct;

            var nowDate = DateTime.Now.Date;
            var productInFridges = await _db.ProductsInFridge
                                            .Include(x => x.Product)
                                            .Where(p => p.UserId == currentUserId)
                                            .ToListAsync();

            foreach (var p in productInFridges)
            {
                if (p.ExpirationDate.Date < nowDate)
                    expiredProduct.Add(p.Product.Name);
            }

            return expiredProduct;
        }
    }
}
