using AutoMapper;
using CoreBankingTest.Core.Entities;

namespace CoreBankingTest.APP.Common.Mappings.Resolvers
{
    public class FullNameResolver : IValueResolver<Customer, object, string>
    {
        public string Resolve(Customer source, object destination, string destMember, ResolutionContext context)
            => $"{source.FirstName} {source.LastName}";
    }

}