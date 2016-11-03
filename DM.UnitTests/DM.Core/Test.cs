using NBehave.Spec.NUnit;
using NUnit.Framework;

namespace DM.UnitTests.DM.Core
{
    public class Test : Specification
    {
        [Test]
        public void this_solution_is_setup_and_ready_to_test()
        {
            1.ShouldEqual(2);
        }
    }
}
