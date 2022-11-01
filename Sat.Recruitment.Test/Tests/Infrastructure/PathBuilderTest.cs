using FluentAssertions;
using Sat.Recruitment.Infrastructure.Implementations;
using Sat.Recruitment.Test.Helpers.Factories;
using System;
using Xunit;

namespace Sat.Recruitment.Test.Tests.Infrastructure
{
    public class PathBuilderTest : BaseTest<PathBuilder>
    {
        // GetPath
        [Fact]
        public void GetPath_WithValidParamaters_ShouldGetRightPath()
        {
            // Arrange            
            var SUT = this.CreateSUT()
                .AddRoot(FileSystemDataLoaderSettingsBuilder.ValidRoot)
                .AddFileName(FileSystemDataLoaderSettingsBuilder.ValidFileName)
                .AddDirectory(FileSystemDataLoaderSettingsBuilder.ValidDirectory);

            // Action
            string act = SUT.GetPath();

            // Assertion
            act.Should().NotBeNullOrEmpty();
            act.Should().Be($"{FileSystemDataLoaderSettingsBuilder.ValidRoot}\\{FileSystemDataLoaderSettingsBuilder.ValidDirectory}");
        }

        [Fact]
        public void GetPath_WithValidParamatersAndNoRoot_ShouldGetRightPath()
        {
            // Arrange
            var SUT = this.CreateSUT()
                .AddFileName(FileSystemDataLoaderSettingsBuilder.ValidFileName)
                .AddDirectory(FileSystemDataLoaderSettingsBuilder.ValidDirectory);

            // Action
            string act = SUT.GetPath();

            // Assertion
            act.Should().NotBeNullOrEmpty();
            act.Should().Be(@$"{AppContext.BaseDirectory}{FileSystemDataLoaderSettingsBuilder.ValidDirectory}");
        }

        [Fact]
        public void GetPath_WithNoAdditionalParameters_ShouldGetDefaultPath()
        {
            // Arrange
            var SUT = this.CreateSUT();

            // Action
            string act = SUT.GetPath();

            // Assertion
            act.Should().NotBeNullOrEmpty();
            act.Should().Be(AppContext.BaseDirectory);
        }


        // GetFull
        [Fact]
        public void GetFull_WithValidParamaters_ShouldGetRightPath()
        {
            // Arrange            
            var SUT = this.CreateSUT()
                .AddRoot(FileSystemDataLoaderSettingsBuilder.ValidRoot)
                .AddFileName(FileSystemDataLoaderSettingsBuilder.ValidFileName)
                .AddDirectory(FileSystemDataLoaderSettingsBuilder.ValidDirectory);

            // Action
            string act = SUT.GetFull();

            // Assertion
            act.Should().NotBeNullOrEmpty();
            act.Should().Be(@$"{FileSystemDataLoaderSettingsBuilder.ValidRoot}\{FileSystemDataLoaderSettingsBuilder.ValidDirectory}\{FileSystemDataLoaderSettingsBuilder.ValidFileName}");
        }

        [Fact]
        public void GetFull_WithValidParamatersAndNoRoot_ShouldGetRightPath()
        {
            // Arrange
            var SUT = this.CreateSUT()
                .AddFileName(FileSystemDataLoaderSettingsBuilder.ValidFileName)
                .AddDirectory(FileSystemDataLoaderSettingsBuilder.ValidDirectory);

            // Action
            string act = SUT.GetFull();

            // Assertion
            act.Should().NotBeNullOrEmpty();
            act.Should().Be(@$"{AppContext.BaseDirectory}{FileSystemDataLoaderSettingsBuilder.ValidDirectory}\{FileSystemDataLoaderSettingsBuilder.ValidFileName}");
        }

        [Fact]
        public void GetFull_WithNoAdditionalParameters_ShouldGetDefaultPath()
        {
            // Arrange
            var SUT = this.CreateSUT();

            // Action
            string act = SUT.GetFull();

            // Assertion
            act.Should().NotBeNullOrEmpty();
            act.Should().Be(AppContext.BaseDirectory);
        }

    }
}
