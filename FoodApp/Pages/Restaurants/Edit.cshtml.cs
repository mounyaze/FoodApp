using FoodApp.Core;
using FoodApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodApp.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        readonly IRestaurantData restaurantData;
        public IHtmlHelper htmlHelper;
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }



        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            if (restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {

                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();

            }
            if (Restaurant.ID > 0)
            {
                restaurantData.Update(Restaurant);
                TempData["Message"] = "Restaurant has been successfully updated !";
            }
            else

            {
                restaurantData.Add(Restaurant);
                TempData["Message"] = "Restaurant has been successfully added !";
            }

            restaurantData.Commit();
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.ID });



        }
    }
}
