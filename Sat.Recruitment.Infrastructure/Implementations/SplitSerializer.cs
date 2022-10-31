using System;
using Sat.Recruitment.Infrastructure.Contracts;

namespace Sat.Recruitment.Infrastructure.Implementations
{
    public class SplitSerializer<TTarget> : IDataSerializer<TTarget>
        where TTarget : class
    {
        private readonly IDataSerializerMapper<TTarget> _dataSerializerMapper;

        public SplitSerializer(IDataSerializerMapper<TTarget> dataSerializerMapper)
        {
            _dataSerializerMapper = dataSerializerMapper;
        }

        public TTarget Serialize(string source)
        {
            string[] fields = source.Split(_dataSerializerMapper.Separator);
            TTarget result = _dataSerializerMapper.Serialize(fields);

            return result;
        }

        public string Deserialize(TTarget source)
        {
            string[] fields = _dataSerializerMapper.Deserialize(source);

            return string.Join(",", fields);
        }
    }
}
