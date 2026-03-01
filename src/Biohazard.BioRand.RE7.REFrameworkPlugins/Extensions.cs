using REFrameworkNET;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

public static class Extension
{
    public static T? Cast<T>(this _System.Object obj) where T : class
    {
        return (obj as IObject)?.As<T>();
    }

    public static ulong Address(this _System.Object obj)
    {
        return (obj as IObject)?.GetAddress() ?? 0;
    }
}