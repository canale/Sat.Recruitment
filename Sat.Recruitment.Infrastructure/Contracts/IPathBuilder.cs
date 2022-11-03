using Sat.Recruitment.Infrastructure.Implementations;

namespace Sat.Recruitment.Infrastructure.Contracts
{
    public interface IPathBuilder
    {
        IPathBuilder AddDirectory(string directory);
        IPathBuilder AddFileName(string fileName);
        IPathBuilder AddRoot(string root);
        IPathBuilder TrySetRoot(string root);
        string GetFull();
        string GetPath();
    }
}
