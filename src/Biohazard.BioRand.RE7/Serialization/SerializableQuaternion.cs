using System.Numerics;

namespace Biohazard.BioRand.RE7.Serialization;

public class SerializableQuaternion
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public float W { get; set; }

    public SerializableQuaternion(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public override string ToString()
        => $"[{X}, {Y}, {Z}, {W}]";

    public static implicit operator Quaternion(SerializableQuaternion rValue)
        => new Quaternion(rValue.X, rValue.Y, rValue.Z, rValue.W);

    public static implicit operator SerializableQuaternion(Quaternion rValue)
        => new SerializableQuaternion(rValue.X, rValue.Y, rValue.Z, rValue.W);
}