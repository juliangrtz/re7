using System.Numerics;

namespace Biohazard.BioRand.RE7.Serialization;

public class SerializableQuaternion(float x, float y, float z, float w)
{
    public float X { get; set; } = x;
    public float Y { get; set; } = y;
    public float Z { get; set; } = z;
    public float W { get; set; } = w;

    public override string ToString()
        => $"[{X}, {Y}, {Z}, {W}]";

    public static implicit operator Quaternion(SerializableQuaternion rValue)
        => new Quaternion(rValue.X, rValue.Y, rValue.Z, rValue.W);

    public static implicit operator SerializableQuaternion(Quaternion rValue)
        => new SerializableQuaternion(rValue.X, rValue.Y, rValue.Z, rValue.W);
}