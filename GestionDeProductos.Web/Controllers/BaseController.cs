using GestionDeProductos.Data.Repositories;
using GestionDeProductos.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductos.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


    }   
}
