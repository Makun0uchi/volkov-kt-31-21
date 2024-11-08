using VolkoVladislavKT_31_21.Models;

namespace VolkovVladislavKT_31_21.Tests
{
    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_KT3121_True()
        {
            var testGroup = new Group
            {
                GroupName = "KT-31-21"
            };

            var result = testGroup.IsValidGroupName();

            Assert.True(result);
        }
    }
}