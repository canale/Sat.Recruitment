using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Sat.Recruitment.Domain.Exceptions;
using Sat.Recruitment.Infrastructure.Contracts;
using Sat.Recruitment.Infrastructure.Implementations;
using Sat.Recruitment.Infrastructure.Settings;
using Sat.Recruitment.Test.Tests;
using System;
using Xunit;

namespace Sat.Recruitment.Test.Infrastructure
{
    public class FileSystemDataLoaderTest : BaseTest<FileSystemDataLoader>
    {
        Mock<IPathBuilder> _pathBuilder;

        public FileSystemDataLoaderTest()
        {
            _pathBuilder = AddFromInterface<IPathBuilder>();
        }


        [Fact]
        public void LoadData_WithValiddPaths_ShouldGetReader()
        {
            // Arrange
            AddInstance( Options.Create(new FileSystemDataLoaderSettings { CreateIfNotExist = true }));
            _pathBuilder.Setup(mock => mock.AddDirectory(It.IsAny<string>())).Returns(_pathBuilder.Object);
            _pathBuilder.Setup(mock => mock.AddFileName(It.IsAny<string>())).Returns(_pathBuilder.Object);
            _pathBuilder.Setup(mock => mock.TrySetRoot(It.IsAny<string>())).Returns(_pathBuilder.Object);

            _pathBuilder.Setup(mock => mock.GetPath()).Returns(@$"{AppContext.BaseDirectory}");
            _pathBuilder.Setup(mock => mock.GetFull()).Returns(@$"{AppContext.BaseDirectory}/Users.txt");

            var SUT = this.CreateSUT(); 

            // Action
            bool act = SUT.LoadData(reader => reader != null);

            // Assertion
            act.Should().BeTrue();
        }


        [Fact]
        public void LoadData_WithNonExsistentPathsAndDoesntCreateIfNotExist_ShouldTrhowException()
        {
            // Arrange
            AddInstance(Options.Create(new FileSystemDataLoaderSettings { CreateIfNotExist = false } ));
            Guid guid = Guid.NewGuid();

            _pathBuilder.Setup(mock => mock.AddDirectory(It.IsAny<string>())).Returns(_pathBuilder.Object);
            _pathBuilder.Setup(mock => mock.AddFileName(It.IsAny<string>())).Returns(_pathBuilder.Object);
            _pathBuilder.Setup(mock => mock.TrySetRoot(It.IsAny<string>())).Returns(_pathBuilder.Object);
            _pathBuilder.Setup(mock => mock.GetFull()).Returns(@$"{AppContext.BaseDirectory}{guid}/Users.txt");

            var SUT = this.CreateSUT();

            // Action
            Action act = () => SUT.LoadData(reader => true);

            // Assertion
            act.Should().Throw<TechnicalException>();
        }


    }
}
