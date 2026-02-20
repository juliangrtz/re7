using Biohazard.BioRand.RE7.REEngine;
using System.Numerics;

namespace Biohazard.BioRand.RE7.Extensions {
    internal static class NumericExtensions {
        public static Vector3 ToVector3(this Vector4 v) => new(v.X, v.Y, v.Z);
        public static Vector4 ToVector4(this Quaternion q) => new(q.X, q.Y, q.Z, q.W);
        public static Quaternion ToQuaternion(this Vector4 v) => new(v.X, v.Y, v.Z, v.W);
        public static EulerAngles ToEuler(this Quaternion q) => new(q);
    }
}
