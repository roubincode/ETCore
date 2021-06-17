#if SERVER
using System;
using System.Globalization;
using System.Runtime.InteropServices;
using scm = System.ComponentModel;

namespace UnityEngine
{
    [Serializable]
    public partial struct Bounds : IEquatable<Bounds>
    {
        private Vector3 m_Center;
        private Vector3 m_Extents;

        // Creates new Bounds with a given /center/ and total /size/. Bound ::ref::extents will be half the given size.
        public Bounds(Vector3 center, Vector3 size)
        {
            m_Center = center;
            m_Extents = size * 0.5F;
        }

        // used to allow Bounds to be used as keys in hash tables
        public override int GetHashCode()
        {
            return center.GetHashCode() ^ (extents.GetHashCode() << 2);
        }

        // also required for being able to use Vector4s as keys in hash tables
        public override bool Equals(object other)
        {
            if (!(other is Bounds)) return false;

            return Equals((Bounds)other);
        }

        public bool Equals(Bounds other)
        {
            return center.Equals(other.center) && extents.Equals(other.extents);
        }

        // The center of the bounding box.
        public Vector3 center { get { return m_Center; } set { m_Center = value; } }

        // The total size of the box. This is always twice as large as the ::ref::extents.
        public Vector3 size { get { return m_Extents * 2.0F; } set { m_Extents = value * 0.5F; } }

        // The extents of the box. This is always half of the ::ref::size.
        public Vector3 extents { get { return m_Extents; } set { m_Extents = value; } }

        // The minimal point of the box. This is always equal to ''center-extents''.
        public Vector3 min { get { return center - extents; } set { SetMinMax(value, max); } }

        // The maximal point of the box. This is always equal to ''center+extents''.
        public Vector3 max { get { return center + extents; } set { SetMinMax(min, value); } }

        //*undoc*
        public static bool operator==(Bounds lhs, Bounds rhs)
        {
            // Returns false in the presence of NaN values.
            return (lhs.center == rhs.center && lhs.extents == rhs.extents);
        }

        //*undoc*
        public static bool operator!=(Bounds lhs, Bounds rhs)
        {
            // Returns true in the presence of NaN values.
            return !(lhs == rhs);
        }

        // Sets the bounds to the /min/ and /max/ value of the box.
        public void SetMinMax(Vector3 min, Vector3 max)
        {
            extents = (max - min) * 0.5F;
            center = min + extents;
        }

        // Grows the Bounds to include the /point/.
        public void Encapsulate(Vector3 point)
        {
            SetMinMax(Vector3.Min(min, point), Vector3.Max(max, point));
        }

        // Grows the Bounds to include the /Bounds/.
        public void Encapsulate(Bounds bounds)
        {
            Encapsulate(bounds.center - bounds.extents);
            Encapsulate(bounds.center + bounds.extents);
        }

        // Expand the bounds by increasing its /size/ by /amount/ along each side.
        public void Expand(float amount)
        {
            amount *= .5f;
            extents += new Vector3(amount, amount, amount);
        }

        // Expand the bounds by increasing its /size/ by /amount/ along each side.
        public void Expand(Vector3 amount)
        {
            extents += amount * .5f;
        }

        // Does another bounding box intersect with this bounding box?
        public bool Intersects(Bounds bounds)
        {
            return (min.x <= bounds.max.x) && (max.x >= bounds.min.x) &&
                (min.y <= bounds.max.y) && (max.y >= bounds.min.y) &&
                (min.z <= bounds.max.z) && (max.z >= bounds.min.z);
        }

    }
}
#endif