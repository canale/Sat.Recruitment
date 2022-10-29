using System;
using System.Collections.Generic;
using System.Text;
using Sat.Recruitment.Infrastructure.Settings;

namespace Sat.Recruitment.Test.Helpers.Factories
{
    internal class FileSystemDataLoaderSettingsBuilder
    {
        public static string ValidFileName => "User.txt";

        public static string ValidRoot => "C://Windows";

        public static string ValidDirectory => "Files";

        public static FileSystemDataLoaderSettingsBuilder GetWith() => new FileSystemDataLoaderSettingsBuilder();

        public static FileSystemDataLoaderSettings GetWithNoRoot()
            => new FileSystemDataLoaderSettings
            {
                Directory = ValidDirectory,
                Root = "",
                FileName = ValidFileName,
                CreateIfNotExist = true,
            };

        internal static object GetWithNotCreateIfNotExist()
         => new FileSystemDataLoaderSettings
         {
             Directory = ValidDirectory,
             Root = "",
             FileName = ValidFileName,
             CreateIfNotExist = false,
         };

        private bool _createIfNotExist;
        private string _root;
        private string _directory;
        private string _fileName;

        public FileSystemDataLoaderSettingsBuilder()
        {
        }


        public FileSystemDataLoaderSettingsBuilder EmptyRoot()
        {
            _root = string.Empty;
            return this;
        }

        public FileSystemDataLoaderSettingsBuilder AppContextRoot()
        {
            _root = AppContext.BaseDirectory;

            return this;
        }

        public FileSystemDataLoaderSettingsBuilder AValidDirectory()
        {
            _directory = ValidDirectory;

            return this;
        }

        public FileSystemDataLoaderSettingsBuilder EmptyDirectory()
        {
            _directory = string.Empty;

            return this;
        }

        public FileSystemDataLoaderSettingsBuilder RandomDirectory()
        {
            int randNumber = new Random().Next(100000000, 900000000);
            _directory = randNumber.ToString();

            return this;
        }

        public FileSystemDataLoaderSettingsBuilder CreateIfNotExist()
        {
            _createIfNotExist = true;
            return this;
        }

        public FileSystemDataLoaderSettingsBuilder NotCreateIfNotExist()
        {
            _createIfNotExist = false;
            return this;
        }

        public FileSystemDataLoaderSettings Build()
            => new FileSystemDataLoaderSettings
            {
                Directory = _directory,
                Root = _root,
                FileName = _fileName,
                CreateIfNotExist = _createIfNotExist,
            };

        public static implicit operator FileSystemDataLoaderSettings(FileSystemDataLoaderSettingsBuilder builder) => builder.Build();


    }
}
