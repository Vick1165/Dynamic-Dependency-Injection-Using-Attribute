namespace Balaji.DependencyInjection.Core.Base;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
public class ExportAttribute : Attribute
{
    public Type ContractType { get; }
    public Lifetime Lifetime { get; }

    public ExportAttribute(Type contractType, Lifetime lifetime = Lifetime.Transient)
    {
        ContractType = contractType;
        Lifetime = lifetime;
    }
}
