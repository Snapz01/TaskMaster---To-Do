using Xunit;
using TaskMaster.Data;

namespace TaskMaster.Tests
{
    public class PersonSequencerTests
    {
        [Fact]
        public void NextPersonId()
        {
            PersonSequencer.Reset();

            //Call twice to get the first and second IDs
            int firstId = PersonSequencer.NextPersonId();
            int secondId = PersonSequencer.NextPersonId();

            //Verify first id is 1 and second is 2
            Assert.Equal(1, firstId);
            Assert.Equal(2, secondId);
        }

        [Fact]
        public void Reset_ShouldSetPersonIdToZero()
        {
            PersonSequencer.NextPersonId();
            PersonSequencer.NextPersonId();

            PersonSequencer.Reset();
            int nextId = PersonSequencer.NextPersonId();

            Assert.Equal(1, nextId);
        }
    }
}
