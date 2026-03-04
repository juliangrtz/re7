using System.Numerics;

namespace Biohazard.BioRand.RE7.Serialization;

public class SerializableVector3
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public SerializableVector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override string ToString()
        => $"[{X}, {Y}, {Z}]";

    public static implicit operator Vector3(SerializableVector3 rValue)
        => new Vector3(rValue.X, rValue.Y, rValue.Z);

    public static implicit operator SerializableVector3(Vector3 rValue)
        => new SerializableVector3(rValue.X, rValue.Y, rValue.Z);
}