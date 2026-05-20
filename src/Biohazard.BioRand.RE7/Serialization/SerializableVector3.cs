using System.Numerics;

namespace Biohazard.BioRand.RE7.Serialization;

public class SerializablePosition(float x, float y, float z) {
    public float X { get; set; } = x;

    public float Y { get; set; } = y;

    public float Z { get; set; } = z;

    public override string ToString()
        => $"[{X}, {Y}, {Z}]";

    public static implicit operator Vector3(SerializablePosition rValue)
        => new(rValue.X, rValue.Y, rValue.Z);

    public static implicit operator SerializablePosition(Vector3 rValue)
        => new(rValue.X, rValue.Y, rValue.Z);
}