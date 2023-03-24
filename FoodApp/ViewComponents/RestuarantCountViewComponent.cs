using FoodApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.ViewComponents
{
    public class RestuarantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestuarantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IViewComponentResult Invoke() 
        {
            var count = restaurantData.GetCountRestaurants();
            return View(count);
        }
    }
}
