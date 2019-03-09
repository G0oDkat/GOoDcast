namespace GOoDcast.Json.NamingStrategies
{
    using Extensions;
    using Newtonsoft.Json.Serialization;

    internal class UnderscoreUpperInvariantNamingStrategy : NamingStrategy
    {
        protected override string ResolvePropertyName(string name)
        {
            return name.ToUnderscoreUpperInvariant();
        }
    }
}