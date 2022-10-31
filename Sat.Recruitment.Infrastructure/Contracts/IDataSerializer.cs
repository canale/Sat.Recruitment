namespace Sat.Recruitment.Infrastructure.Contracts
{
    public interface IDataSerializer<TTarget>
            where TTarget : class
    {
        TTarget Serialize(string source);
        string Deserialize(TTarget source);
    }
}
