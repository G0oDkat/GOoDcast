namespace GOoDcast.Json.NamingStrategies
{
    using Extensions;
    using Newtonsoft.Json.Serialization;

    internal class UnderscoreLowerInvariantNamingStrategy : NamingStrategy
    {
        protected override string ResolvePropertyName(string name)
        {
            return name.ToUnderscoreLowerInvariant();
        }
    }
}