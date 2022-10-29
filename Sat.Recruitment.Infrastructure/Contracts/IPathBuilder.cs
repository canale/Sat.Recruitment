using Sat.Recruitment.Infrastructure.Implementations;

namespace Sat.Recruitment.Infrastructure.Contracts
{
    public interface IPathBuilder
    {
        PathBuilder AddDirectory(string directory);
        PathBuilder AddFileName(string fileName);
        PathBuilder AddRoot(string root);
        string GetFull();
        string GetPath();
    }
}
