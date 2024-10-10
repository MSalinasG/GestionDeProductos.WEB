namespace GestionDeProductos.Web.Helpers
{
    public class BreadcrumbService : IBreadcrumbService
    {
        private readonly Dictionary<string, string> _primaryBreadcrumb = new Dictionary<string, string>
        {
            { "ProductsControllerIndex", "Products List" },
            { "ProductsControllerDetails", "Product Details" },
            { "ProductsControllerCreate", "Create Product" },
            { "ProductsControllerEdit", "Edit Product" },
            { "ProductsControllerDelete", "Delete Product" }

        };

        private readonly Dictionary<string, string> _secondaryBreadcrumb = new Dictionary<string, string>
        {
            { "ProductsControllerCreate", "Products List" },
            { "ProductsControllerEdit", "Products List" },
            { "ProductsControllerDelete", "Products List" },
            { "ProductsControllerDetails", "Products List" }
        };

        public string? GetPrimaryBreadcrumb(string actionName)
        {
            return _primaryBreadcrumb.ContainsKey(actionName) ? _primaryBreadcrumb[actionName] : "Home";
        }

        public string? GetSecondaryBreadcrumb(string actionName)
        {
            return _secondaryBreadcrumb.ContainsKey(actionName) ? _secondaryBreadcrumb[actionName] : null;
        }
    }
}
