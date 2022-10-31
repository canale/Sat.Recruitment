namespace Sat.Recruitment.Infrastructure.Contracts
{
    public interface IDataSerializerMapper<TTarget>
    {
        char Separator { get; }

        TTarget Serialize(string[] fields);

        string[] Deserialize(TTarget source);
    }
}
