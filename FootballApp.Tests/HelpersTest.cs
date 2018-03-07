using FootballApp.Helpers;
using Xunit;

namespace FootballApp.Tests
{
    public class HelpersTest
    {

        [Fact]
        public void EmailShouldBeValid()
        {
            Assert.True(Validations.IsValidEmail("javicamdo@gmail.com"));
        }

        public void EmailShouldBeValid2()
        {
            Assert.True(Validations.IsValidEmail("javicamdo@gmail"));
        }

        [Fact]
        public void EmailShouldBeInvalid()
        {
            Assert.True(!Validations.IsValidEmail("javicamdogmail.com"));
        }

        [Fact]
        public void EmailShouldBeInvalid2()
        {
            Assert.True(!Validations.IsValidEmail("@gmail.com"));
        }

        [Fact]
        public void EmailShouldBeInvalid3()
        {
            Assert.True(!Validations.IsValidEmail("dasdsa@"));
        }
    }
}
