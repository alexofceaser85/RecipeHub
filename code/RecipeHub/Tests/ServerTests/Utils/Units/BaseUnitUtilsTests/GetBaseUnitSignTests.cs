using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Utils.Units;

namespace ServerTests.Utils.Units.BaseUnitUtilsTests
{
    public class GetBaseUnitSignTests
    {
        [Test]
        public void GetMassUnit()
        {
            Assert.That(BaseUnitUtils.GetBaseUnitSign(MeasurementType.Mass), Is.EqualTo("g"));
        }

        [Test]
        public void GetVolumeUnit()
        {
            Assert.That(BaseUnitUtils.GetBaseUnitSign(MeasurementType.Volume), Is.EqualTo("ml"));
        }

        [Test]
        public void GetQuantityUnit()
        {
            Assert.That(BaseUnitUtils.GetBaseUnitSign(MeasurementType.Quantity), Is.EqualTo(""));
        }

        [Test]
        public void GetUnknownUnit()
        {
            Assert.That(BaseUnitUtils.GetBaseUnitSign((MeasurementType)3), Is.EqualTo(""));
        }
    }
}
