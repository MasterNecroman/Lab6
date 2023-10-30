using System;
using System.Numerics;

namespace task_3
{
    public class Quaternion
    {
        public float W { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Quaternion(float w, float x, float y, float z)
        {
            W = w;
            X = x;
            Y = y;
            Z = z;
        }

        public float Norm()
        {
            return (float)Math.Sqrt(W * W + X * X + Y * Y + Z * Z);
        }

        public Quaternion Conjugate()
        {
            return new Quaternion(W, -X, -Y, -Z);
        }

        public Quaternion Inverse()
        {
            float norm = Norm();
            if (norm == 0)
                throw new InvalidOperationException("Quaternion has zero norm and no inverse.");

            float normSquared = norm * norm;
            return Conjugate() / normSquared;
        }

        public static Quaternion operator +(Quaternion q1, Quaternion q2)
        {
            return new Quaternion(q1.W + q2.W, q1.X + q2.X, q1.Y + q2.Y, q1.Z + q2.Z);
        }

        public static Quaternion operator -(Quaternion q1, Quaternion q2)
        {
            return new Quaternion(q1.W - q2.W, q1.X - q2.X, q1.Y - q2.Y, q1.Z - q2.Z);
        }

        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            float w = q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z;
            float x = q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y;
            float y = q1.W * q2.Y - q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X;
            float z = q1.W * q2.Z + q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W;

            return new Quaternion(w, x, y, z);
        }

        public static Quaternion operator *(Quaternion q, float scalar)
        {
            return new Quaternion(q.W * scalar, q.X * scalar, q.Y * scalar, q.Z * scalar);
        }

        public static Quaternion operator /(Quaternion q, float scalar)
        {
            if (scalar == 0)
                throw new InvalidOperationException("Division by zero.");

            return new Quaternion(q.W / scalar, q.X / scalar, q.Y / scalar, q.Z / scalar);
        }

        public static bool operator ==(Quaternion q1, Quaternion q2)
        {
            return q1.Equals(q2);
        }

        public static bool operator !=(Quaternion q1, Quaternion q2)
        {
            return !q1.Equals(q2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Quaternion other = (Quaternion)obj;
            return W == other.W && X == other.X && Y == other.Y && Z == other.Z;
        }

        public override int GetHashCode()
        {
            return W.GetHashCode() ^ X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

       
        public Matrix4x4 ToRotationMatrix()
        {
            float xx = X * X;
            float xy = X * Y;
            float xz = X * Z;
            float xw = X * W;
            float yy = Y * Y;
            float yz = Y * Z;
            float yw = Y * W;
            float zz = Z * Z;
            float zw = Z * W;

            Matrix4x4 matrix = new Matrix4x4();

            matrix.M11 = 1 - 2 * (yy + zz);
            matrix.M12 = 2 * (xy - zw);
            matrix.M13 = 2 * (xz + yw);

            matrix.M21 = 2 * (xy + zw);
            matrix.M22 = 1 - 2 * (xx + zz);
            matrix.M23 = 2 * (yz - xw);

            matrix.M31 = 2 * (xz - yw);
            matrix.M32 = 2 * (yz + xw);
            matrix.M33 = 1 - 2 * (xx + yy);

            return matrix;
        }

        
        public static Quaternion FromRotationMatrix(Matrix4x4 matrix)
        {
            float trace = matrix.M11 + matrix.M22 + matrix.M33;

            if (trace > 0)
            {
                float s = 0.5f / (float)Math.Sqrt(trace + 1.0);
                float w = 0.25f / s;
                float x = (matrix.M32 - matrix.M23) * s;
                float y = (matrix.M13 - matrix.M31) * s;
                float z = (matrix.M21 - matrix.M12) * s;
                return new Quaternion(w, x, y, z);
            }
            else if (matrix.M11 > matrix.M22 && matrix.M11 > matrix.M33)
            {
                float s = 2.0f * (float)Math.Sqrt(1.0 + matrix.M11 - matrix.M22 - matrix.M33);
                float w = (matrix.M32 - matrix.M23) / s;
                float x = 0.25f * s;
                float y = (matrix.M12 + matrix.M21) / s;
                float z = (matrix.M13 + matrix.M31) / s;
                return new Quaternion(w, x, y, z);
            }
            else if (matrix.M22 > matrix.M33)
            {
                float s = 2.0f * (float)Math.Sqrt(1.0 + matrix.M22 - matrix.M11 - matrix.M33);
                float w = (matrix.M13 - matrix.M31) / s;
                float x = (matrix.M12 + matrix.M21) / s;
                float y = 0.25f * s;
                float z = (matrix.M23 + matrix.M32) / s;
                return new Quaternion(w, x, y, z);
            }
            else
            {
                float s = 2.0f * (float)Math.Sqrt(1.0 + matrix.M33 - matrix.M11 - matrix.M22);
                float w = (matrix.M21 - matrix.M12) / s;
                float x = (matrix.M13 + matrix.M31) / s;
                float y = (matrix.M23 + matrix.M32) / s;
                float z = 0.25f * s;
                return new Quaternion(w, x, y, z);
            }
        }
    }
}