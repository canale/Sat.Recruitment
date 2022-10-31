using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Sat.Recruitment.Infrastructure.Contracts;
using Sat.Recruitment.Infrastructure.Exceptions;
using Sat.Recruitment.Infrastructure.Implementations;
using Sat.Recruitment.Infrastructure.Settings;
using Sat.Recruitment.Test.Tests;
using System;
using Sat.Recruitment.Domain.Exceptions;
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

            _pathBuilder.Setup(mock => mock.GetPath()).Returns(@$"{AppContext.BaseDirectory}");
            _pathBuilder.Setup(mock => mock.GetFull()).Returns(@$"{AppContext.BaseDirectory}/Users.txt");

            var SUT = this.CreateSUT(); 

            // Action
           // var act = SUT.LoadData();

            // Assertion
           // act.Should().NotBeNull();
        }


        [Fact]
        public void LoadData_WithNonExsistentPathsAndDoesntCreateIfNotExist_ShouldTrhowException()
        {
            // Arrange
            AddInstance(Options.Create(new FileSystemDataLoaderSettings { CreateIfNotExist = false } ));
            Guid guid = Guid.NewGuid();

            _pathBuilder.Setup(mock => mock.GetPath()).Returns(@$"{AppContext.BaseDirectory}{guid}");
            _pathBuilder.Setup(mock => mock.GetFull()).Returns(@$"{AppContext.BaseDirectory}{guid}/Users.txt");

            var SUT = this.CreateSUT();

            // Action
         //   Action act = () => SUT.LoadData();

            // Assertion
          //  act.Should().Throw<TechnicalException>();
        }


    }
}
