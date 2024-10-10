namespace GestionDeProductos.Web.Helpers
{
    public interface IBreadcrumbService
    {
        string? GetPrimaryBreadcrumb(string actionName);
        string? GetSecondaryBreadcrumb(string actionName);
    }
}
