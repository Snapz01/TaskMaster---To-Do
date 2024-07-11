using Xunit;
using TaskMaster.Data;

namespace TaskMaster.Tests
{
    public class TodoSequencerTests
    {
        [Fact]
        public void ShouldIncrementAndReturnNextId()
        {
            //reset
            TodoSequencer.Reset();
            //get id
            int firstId = TodoSequencer.NextTodoId();
            int secondId = TodoSequencer.NextTodoId();
            //verify
            Assert.Equal(1, firstId);
            Assert.Equal(2, secondId);
        }

        [Fact]
        public void Reset_ShouldSetTodoIdToZero()
        {
            //get id
            TodoSequencer.NextTodoId();
            TodoSequencer.NextTodoId();
            //reset and next id
            TodoSequencer.Reset();
            int nextId = TodoSequencer.NextTodoId();
            //verify
            Assert.Equal(1, nextId);
        }
    }
}
