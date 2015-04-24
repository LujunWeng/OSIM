using NBehave.Spec;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIM.UnitTests
{
    [TestFixture]
    public class Specification
    {
        [TestFixtureSetUp]
        protected virtual void Establish_context()
        {
        }
        [SetUp]
        protected virtual void Because_of()
        {
        }
        [TestFixtureTearDown]
        protected virtual void Cleanup()
        {
        }
    }
}