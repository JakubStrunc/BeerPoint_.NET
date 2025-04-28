using PNET_semestralka_blazor_app.Models;
using Microsoft.JSInterop;

namespace PNET_semestralka_blazor_app.Components.Pages
{
    public partial class Home
    {
        private List<Product>? products;
        private string? errorMessage;

        
        protected override async Task OnInitializedAsync()
        {

            try
            {
                products = await HomeService.GetAllProductsAsync();
            }
            catch (Exception ex)
            {
                errorMessage = "Chyba pøi naèítání produktù: " + ex.Message;
            }
            
        }

        private async Task PridatDoKosiku(Product product)
        {
            throw new NotImplementedException();
            //try
            //{
            //    await HomeService.AddToCartAsync(session.UserEmail, product);

            //    await JSRuntime.InvokeVoidAsync("Toastify", new
            //    {
            //        text = $"{product.Nazev} pøidán do košíku",
            //        duration = 3000,
            //        close = true,
            //        gravity = "bottom",
            //        position = "right",
            //        backgroundColor = "linear-gradient(to right, #00b09b, #96c93d)",
            //        stopOnFocus = true
            //    });
            //}
            //catch (Exception ex)
            //{
            //    await JSRuntime.InvokeVoidAsync("Toastify", new
            //    {
            //        text = $"Chyba: {ex.Message}",
            //        duration = 3000,
            //        backgroundColor = "linear-gradient(to right, #ff5f6d, #ffc371)"
            //    });
            //}
        }
    }
}