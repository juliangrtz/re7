using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;
using System.Text;

namespace Biohazard.BioRand.RE7.DataGen.CodeGen;

/// <summary>
/// Decompiled adaptation of IntelOrca's code for custom Enum handling.
/// </summary>
public class RszTypeCsharpWriter
{
    public bool GenerateEnums { get; set; }
    public bool UseEnumTypes { get; set; }
    public string? EnumNamespace { get; set; }

    private class CsharpWriter
    {
        private readonly StringBuilder _sb = new();
        private int _indent;

        public void AppendLine(string line)
        {
            _sb.Append(new string(' ', _indent * 4));
            _sb.Append(line);
            _sb.AppendLine();
        }

        public void BeginNamespaceBlock(string ns)
        {
            AppendLine("namespace " + ns);
            AppendLine("{");
            Indent();
        }

        public void BeginEnumBlock(string name)
        {
            AppendLine("internal enum " + name);
            AppendLine("{");
            Indent();
        }

        public void BeginClassBlock(string name, string? parentName)
        {
            string text = ((parentName == null) ? "" : (" : " + parentName));
            AppendLine("internal class " + name + text);
            AppendLine("{");
            Indent();
        }

        public void Property(string type, string name, string? initializer)
        {
            if (initializer == null)
            {
                AppendLine($"public {type} {name} {{ get; set; }}");
            }
            else
            {
                AppendLine($"public {type} {name} {{ get; set; }} = {initializer};");
            }
        }

        public void EndBlock()
        {
            Outdent();
            AppendLine("}");
        }

        public void Indent()
        {
            _indent++;
        }

        public void Outdent()
        {
            _indent--;
        }

        public override string ToString()
        {
            return _sb.ToString();
        }
    }

    public string Generate(RszType rszType)
    {
        CsharpWriter writer = new();
        List<RszType> allTypes = FindTypes([], rszType);
        foreach (IGrouping<string, RszType> item in from x in allTypes
                                                    group x by x.Namespace)
        {
            writer.BeginNamespaceBlock(item.Key);
            foreach (RszType item2 in item)
            {
                if (item2.IsEnum)
                {
                    if (GenerateEnums)
                    {
                        writer.BeginEnumBlock(item2.NameWithoutNamespace);
                        writer.EndBlock();
                    }
                }
                else
                {
                    WriteType(item2);
                }
            }

            writer.EndBlock();
        }

        return writer.ToString();
        void WriteType(RszType t)
        {
            if (!t.Name.Contains("[]") && !t.Name.Contains('<'))
            {
                string? parentName = null;
                RszType? rszType2 = null;
                if (t.Parent != null && allTypes.Contains(t.Parent))
                {
                    rszType2 = t.Parent;
                    parentName = ((t.Parent.Namespace == t.Namespace) ? t.Parent.NameWithoutNamespace : t.Parent.Name);
                }

                writer.BeginClassBlock(t.NameWithoutNamespace, parentName);
                ImmutableArray<RszTypeField>.Enumerator enumerator3 = t.Fields.GetEnumerator();
                while (enumerator3.MoveNext())
                {
                    RszTypeField current3 = enumerator3.Current;
                    if (rszType2 == null || !t.IsFieldInherited(current3.Name))
                    {
                        string fieldTypeName = GetFieldTypeName(current3);
                        if (current3.IsArray)
                        {
                            writer.Property("System.Collections.Generic.List<" + fieldTypeName + ">", current3.Name, "[]");
                        }
                        else
                        {
                            writer.Property(fieldTypeName, current3.Name, GetInitializer(current3));
                        }
                    }
                }

                ImmutableArray<RszType>.Enumerator enumerator4 = t.Repository.GetNestedTypes(t).GetEnumerator();
                while (enumerator4.MoveNext())
                {
                    RszType current4 = enumerator4.Current;
                    WriteType(current4);
                }

                writer.EndBlock();
            }
        }
    }

    private static string? GetInitializer(RszTypeField f)
    {
        if (f.Type == RszFieldType.String)
        {
            return "\"\"";
        }

        if (f.ObjectType != null)
        {
            return null;
        }

        return "new()";
    }

    private string GetFieldTypeName(RszTypeField field)
    {
        RszType? objectType = field.ObjectType;
        if (objectType != null && objectType.IsEnum)
        {
            if (UseEnumTypes)
            {
                return string.IsNullOrWhiteSpace(EnumNamespace)
                        ? objectType.Name
                        : $"{EnumNamespace}.{objectType.Name}";
            }
            else if (!GenerateEnums)
            {
                objectType = objectType.Fields[0].ObjectType;
            }
        }

        return field.Type switch
        {
            RszFieldType.Bool => "bool",
            RszFieldType.S8 => "sbyte",
            RszFieldType.U8 => "byte",
            RszFieldType.S16 => "short",
            RszFieldType.U16 => "ushort",
            RszFieldType.S32 => "int",
            RszFieldType.U32 => "uint",
            RszFieldType.S64 => "long",
            RszFieldType.U64 => "ulong",
            RszFieldType.F32 => "float",
            RszFieldType.F64 => "double",
            RszFieldType.Vec2 => "System.Numerics.Vector2",
            RszFieldType.Vec3 => "System.Numerics.Vector3",
            RszFieldType.Vec4 => "System.Numerics.Vector4",
            RszFieldType.Quaternion => "System.Numerics.Quaternion",
            RszFieldType.Guid or RszFieldType.GameObjectRef => "System.Guid",
            RszFieldType.Range => "IntelOrca.Biohazard.REE.Rsz.Native.Range",
            RszFieldType.KeyFrame => "IntelOrca.Biohazard.REE.Rsz.Native.KeyFrame",
            RszFieldType.String => "string",
            RszFieldType.UserData => "RszUserDataNode",
            RszFieldType.Resource => "RszResourceNode",
            _ => objectType?.Name ?? "object",
        };
    }

    private List<RszType> FindTypes(List<RszType> types, RszType type)
    {
        if (type.Name.StartsWith("System."))
        {
            return types;
        }

        if (type.Name.StartsWith("via."))
        {
            return types;
        }

        if (type.IsEnum && !GenerateEnums)
        {
            return types;
        }

        if (types.Contains(type))
        {
            return types;
        }

        if (type.Repository.FromName(type.Namespace) == null)
        {
            types.Add(type);
        }

        foreach (RszType item in type.Children.OrderBy(x => x.Name))
        {
            types.Add(item);
        }

        ImmutableArray<RszTypeField>.Enumerator enumerator2 = type.Fields.GetEnumerator();
        while (enumerator2.MoveNext())
        {
            RszTypeField current2 = enumerator2.Current;
            if (current2.ObjectType != null)
            {
                FindTypes(types, current2.ObjectType);
            }
        }

        return types;
    }
}