using NUnit.Framework;
using NBehave.Spec.NUnit;
using OSIM.Core.Entities;
using OSIM.Core.Persistence;
using Moq;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIM.UnitTests.OSIM.Core
{
    public class when_working_with_the_item_type_repository : Specification
    {
        protected IItemTypeRepository _itemTypeRepository;
        protected Mock<ISessionFactory> sessionFactory;
        protected Mock<ISession> session;

        protected override void Establish_context()
        {
            base.Establish_context();
            sessionFactory = new Mock<ISessionFactory>();
            session = new Mock<ISession>();
            sessionFactory.Setup(sf => sf.OpenSession()).Returns(session.Object);
            _itemTypeRepository = new ItemTypeRepository(sessionFactory.Object);
        }
    }

    public class and_saving_a_valid_item_type : 
        when_working_with_the_item_type_repository
    {
        private int _result;
        private ItemType _testItemType;
        private int _itemTypeId;

        protected override void Establish_context()
        {
            base.Establish_context();

            var randomNumberGenerator = new Random();
            _itemTypeId = randomNumberGenerator.Next(32000);
            _testItemType = new ItemType();

            session.Setup(s => s.Save(_testItemType)).Returns(_itemTypeId);
        }

        protected override void Because_of()
        {
            _result = _itemTypeRepository.Save(_testItemType);
        }

        [Test]
        public void then_a_valid_item_type_id_should_be_returned()
        {
            _result.ShouldEqual(_itemTypeId);
        }
    }

    public class and_saving_an_invalid_item_type :
        when_working_with_the_item_type_repository
    {
        private Exception _result;

        protected override void Establish_context()
        {
            base.Establish_context();

            session.Setup(s => s.Save(null)).Throws(new ArgumentNullException());
        }
        protected override void Because_of()
        {
            try
            {
                _itemTypeRepository.Save(null);
            }
            catch (Exception exception)
            {
                _result = exception;
            }
            
        }

        [Test]
        public void then_an_argument_null_exception_should_be_raised()
        {
            _result.ShouldBeInstanceOfType(typeof(ArgumentNullException));
        }
    }

    public class and_getting_a_item_type_by_id :
        when_working_with_the_item_type_repository
    {
        private ItemType _testItemType;
        private ItemType _validResult;
        private ItemType _invalidResult;

        protected override void Establish_context()
        {
            base.Establish_context();
            _testItemType = new ItemType();
            var randomNumberGenerator = new Random();
            _testItemType.Id = randomNumberGenerator.Next(32000);
            session.Setup(s => s.Get<ItemType>(_testItemType.Id)).Returns(_testItemType);
        }
        protected override void Because_of()
        {
            _validResult = _itemTypeRepository.GetById(_testItemType.Id);
            _invalidResult = _itemTypeRepository.GetById(_testItemType.Id - 1);
        }

        [Test]
        public void then_a_valid_item_type_should_be_return()
        {
            _validResult.Id.ShouldEqual(_testItemType.Id);
            _invalidResult.ShouldBeNull();
        }
    }

}