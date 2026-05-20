using System.Numerics;

namespace Biohazard.BioRand.RE7.Serialization;

public class SerializableRotation(float x, float y, float z, float w) {
    public float X { get; set; } = x;

    public float Y { get; set; } = y;

    public float Z { get; set; } = z;

    public float W { get; set; } = w;

    public override string ToString()
        => $"[{X}, {Y}, {Z}, {W}]";

    public static implicit operator Quaternion(SerializableRotation rValue)
        => new(rValue.X, rValue.Y, rValue.Z, rValue.W);

    public static implicit operator SerializableRotation(Quaternion rValue)
        => new(rValue.X, rValue.Y, rValue.Z, rValue.W);
}