using System;
using System.IO;
using Sat.Recruitment.Infrastructure.Contracts;

namespace Sat.Recruitment.Infrastructure.Implementations
{
    public class PathBuilder : IPathBuilder
    {
        private string root = "";
        private string fileName = "";
        private string directory = "";

        public PathBuilder()
        {
            root = AppContext.BaseDirectory;
        }

        public PathBuilder AddRoot(string root)
        {
            this.root = root;

            return this;
        }

        public PathBuilder AddFileName(string fileName)
        {
            this.fileName = fileName;

            return this;
        }

        public PathBuilder AddDirectory(string directory)
        {
            this.directory = directory;

            return this;
        }

        public string GetFull()
         => Path.Combine(root, directory, fileName);


        public string GetPath()
            => System.IO.Path.Combine(root, directory);

    }
}
