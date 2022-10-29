using System.IO;

namespace Sat.Recruitment.Infrastructure.Contracts
{
    public interface IDataLoader
    {
        StreamReader LoadData();
    }
}
