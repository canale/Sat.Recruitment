using System;
using System.IO;

namespace Sat.Recruitment.Infrastructure.Contracts
{
    public interface IDataLoader
    {
        TResult LoadData<TResult>(Func<StreamReader, TResult> processingData);
        void LoadData(Action<StreamReader> processingData);
    }
}
