using Xunit;

namespace Dhgms.Nucleotide.IntegrationTests.SampleGenerator
{
    /// <summary>
    /// Fake test to ensure test project builds/runs.
    /// </summary>
    public sealed class FakeTest
    {
        /// <summary>
        /// fake test method.
        /// </summary>
        [Fact]
        public void FakeTestMethod()
        {
            // Fake test to ensure test project builds/runs.
            // need to do some housekeeping and move the actual integration tests out of unit tests project.
            Assert.True(true);
        }
    }
}
