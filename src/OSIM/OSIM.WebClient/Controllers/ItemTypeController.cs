using OSIM.Core.Persistence;
using System.Web.Mvc;

namespace OSIM.WebClient.Controllers
{
    public class ItemTypeController : Controller
    {
        private IItemTypeRepository _itemTypeRepository;

        public ItemTypeController(IItemTypeRepository itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }
        // GET: ItemType
        public ActionResult Index()
        {
            ViewData.Model = _itemTypeRepository.GetAll;
            return View();
        }
    }
}