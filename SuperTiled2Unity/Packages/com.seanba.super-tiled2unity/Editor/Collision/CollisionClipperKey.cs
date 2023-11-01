using System;

namespace SuperTiled2Unity.Editor
{
    public struct CollisionClipperKey : IEquatable<CollisionClipperKey>
    {
        private readonly int m_LayerId;
        private readonly string m_LayerName;
        private readonly string m_TagName;
        private readonly bool m_IsTrigger;

        public CollisionClipperKey(int layerId, string layerName, string tagName, bool isTrigger)
        {
            m_LayerId = layerId;
            m_LayerName = layerName;
            m_TagName = tagName;
            m_IsTrigger = isTrigger;
        }

        public int LayerId { get { return m_LayerId; } }

        public string LayerName { get { return m_LayerName; } }

        public string TagName { get { return m_TagName; } }

        public bool IsTrigger { get { return m_IsTrigger; } }

        public override int GetHashCode()
        {
            var result = m_LayerId.GetHashCode();
            result = (result * 397) ^ m_LayerName.GetHashCode();
            result = (result * 397) ^ m_TagName.GetHashCode();
            result = (result * 397) ^ m_IsTrigger.GetHashCode();
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals((CollisionClipperKey)obj);
        }

        public bool Equals(CollisionClipperKey other)
        {
            return other.m_LayerId.Equals(m_LayerId) &&
                other.m_LayerName.Equals(m_LayerName, StringComparison.OrdinalIgnoreCase) &&
                other.m_TagName.Equals(m_TagName, StringComparison.OrdinalIgnoreCase) &&
                other.m_IsTrigger.Equals(m_IsTrigger);
        }
    }
}
