using System.Numerics;

namespace Biohazard.BioRand.RE7.Serialization;

public class SerializableVector3(float x, float y, float z)
{
    public float X { get; set; } = x;
    public float Y { get; set; } = y;
    public float Z { get; set; } = z;

    public override string ToString()
        => $"[{X}, {Y}, {Z}]";

    public static implicit operator Vector3(SerializableVector3 rValue)
        => new Vector3(rValue.X, rValue.Y, rValue.Z);

    public static implicit operator SerializableVector3(Vector3 rValue)
        => new SerializableVector3(rValue.X, rValue.Y, rValue.Z);
}