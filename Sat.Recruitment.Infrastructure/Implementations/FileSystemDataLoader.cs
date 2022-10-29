using System;
using System.IO;
using Microsoft.Extensions.Options;
using Sat.Recruitment.Infrastructure.Contracts;
using Sat.Recruitment.Infrastructure.Exceptions;
using Sat.Recruitment.Infrastructure.Settings;

namespace Sat.Recruitment.Infrastructure.Implementations
{
    public class FileSystemDataLoader : IDataLoader
    {
        private readonly IPathBuilder _pathBuilder;
        private readonly FileSystemDataLoaderSettings _settings;

        public FileSystemDataLoader(IOptions<FileSystemDataLoaderSettings> settings, IPathBuilder pathBuilder)
        {
            _pathBuilder = pathBuilder;
            _settings = settings.Value;

            BuildPath();
        }

        public TResult LoadData<TResult>(Func<StreamReader, TResult> processingData)
        {
            CheckPath();
            CheckFile();

            string fullPath = _pathBuilder.GetFull();

            using  FileStream fileStream = File.OpenRead(fullPath);
            using StreamReader reader = new StreamReader(fileStream);

            return processingData(reader);
        }

        public void LoadData(Action<StreamReader> processingData)
        {
            CheckPath();
            CheckFile();

            string fullPath = _pathBuilder.GetFull();

            using FileStream fileStream = File.OpenRead(fullPath);
            using StreamReader reader = new StreamReader(fileStream);

            processingData(reader);
        }

        private void CheckPath()
        {
            string path = _pathBuilder.GetPath();

            if (Directory.Exists(path))
            {
                return;
            }

            if (_settings.CreateIfNotExist)
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                throw new MissingDirectoryException($"Couldn't find {path} _directory.");
            }
        }

        private void CheckFile()
        {
            string fullPath = _pathBuilder.GetFull();

            if (File.Exists(fullPath))
            {
                return;
            }

            if (_settings.CreateIfNotExist)
            {
                File.Create(fullPath);
            }
            else
            {
                throw new MissingFileException($"Couldn't find {fullPath} the file.");
            }

        }

        private void BuildPath()
        {
            _pathBuilder
                .AddDirectory(_settings.Directory)
                .AddFileName(_settings.FileName)
                .TrySetRoot(_settings.Root);
        }

    }
}
