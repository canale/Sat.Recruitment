using System;
using System.IO;
using Sat.Recruitment.Infrastructure.Contracts;

namespace Sat.Recruitment.Infrastructure.Implementations
{
    public class PathBuilder : IPathBuilder
    {
        private string _root = "";
        private string _fileName = "";
        private string _directory = "";

        public PathBuilder()
        {
            _root = AppContext.BaseDirectory;
        }

        public IPathBuilder AddRoot(string root)
        {
            _root = root;

            return this;
        }

        public IPathBuilder AddFileName(string fileName)
        {
            _fileName = fileName;

            return this;
        }

        public IPathBuilder AddDirectory(string directory)
        {
            _directory = directory;

            return this;
        }

        public IPathBuilder TrySetRoot(string root)
        {
            _root = string.IsNullOrEmpty(root) ? this._root : root;
            return this;
        }

        public string GetFull()
         => Path.Combine(_root, _directory, _fileName);


        public string GetPath()
            => System.IO.Path.Combine(_root, _directory);

    }
}
