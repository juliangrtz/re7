namespace Biohazard.BioRand.RE7.Attributes;

[AttributeUsage(AttributeTargets.Class)]
internal class OrderAttribute(int order) : Attribute
{
    public int Order => order;
}