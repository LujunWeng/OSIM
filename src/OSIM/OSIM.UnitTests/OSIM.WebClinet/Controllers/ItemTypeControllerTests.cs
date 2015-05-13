using Moq;
using OSIM.Core.Entities;
using OSIM.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIM.UnitTests.OSIM.WebClinet.Controllers
{
    public class when_working_with_the_item_type_controller : Specification
    {
        protected Mock<IItemTypeRepository> _itemRepository =
             new Mock<IItemTypeRepository>();
        protected ItemType _itemOne;
        protected ItemType _itemTwo;
        protected ItemType _itemThree;

        protected override void Establish_context()
        {
            _itemOne = new ItemType { Id = 1, Name = "USB drives" };
            _itemTwo = new ItemType { Id = 2, Name = "Nerf darts" };
            _itemThree = new ItemType { Id = 3, Name = "Flying Monkeys" };
            var itemTypeList = new List<ItemType>
            {
                _itemOne, _itemTwo, _itemThree
            };

            _itemRepository.Setup(x => x.GetAll).Returns(itemTypeList);
        }
    }
}
