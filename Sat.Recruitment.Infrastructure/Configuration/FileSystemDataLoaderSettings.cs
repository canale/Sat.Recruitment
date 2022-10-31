namespace Sat.Recruitment.Infrastructure.Settings
{
    /// <summary>
    /// Settings for file system data loading
    /// </summary>
    public class FileSystemDataLoaderSettings
    {
        public bool CreateIfNotExist { get; set; }
        
        public string Root { get; set; }

        public string Directory { get; set; }

        public string FileName { get; set; }
    }
}
