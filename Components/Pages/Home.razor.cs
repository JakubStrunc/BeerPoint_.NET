using PNET_semestralka_blazor_app.Models;

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
                errorMessage = "Chyba p�i na��t�n� produkt�: " + ex.Message;
            }
        }

        private void PridatDoKosiku(int productId)
        {
            // Logika pro p�id�n� do ko��ku (bude� p�id�vat pozd�ji)
        }
    }
}