using System.IO;
using Microsoft.Extensions.Options;
using Sat.Recruitment.Infrastructure.Contracts;
using Sat.Recruitment.Infrastructure.Exceptions;
using Sat.Recruitment.Infrastructure.Settings;

namespace Sat.Recruitment.Infrastructure.Implementations
{
    public class FileSystemDataLoader : IDataLoader
    {
        private readonly IPathBuilder pathBuilder;
        private readonly FileSystemDataLoaderSettings settings;

        public FileSystemDataLoader(IOptions<FileSystemDataLoaderSettings> settings, IPathBuilder pathBuilder)
        {
            this.pathBuilder = pathBuilder;
            this.settings = settings.Value;
        }

        public StreamReader LoadData()
        {
            CheckPath();
            CheckFile();

            string fullPath = pathBuilder.GetFull();

            using  FileStream fileStream = File.OpenRead(fullPath);

            using StreamReader reader = new StreamReader(fileStream);
            return reader;
        }

        private void CheckPath()
        {
            string path = pathBuilder.GetPath();

            if (Directory.Exists(path))
            {
                return;
            }

            if (settings.CreateIfNotExist)
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                throw new MissingDirectoryException($"Couldn't find {path} directory.");
            }
        }

        private void CheckFile()
        {
            string fullPath = pathBuilder.GetFull();

            if (File.Exists(fullPath))
            {
                return;
            }

            if (settings.CreateIfNotExist)
            {
                File.Create(fullPath);
            }
            else
            {
                throw new MissingFileException($"Couldn't find {fullPath} the file.");
            }

        }
    }
}
