using UnityEngine;

namespace LocalJoost.HoloToolkitExtensions
{
    public class SpatialMappingCollisionDetector : BaseSpatialMappingCollisionDetector
    {
        public float MinDistance = 0.0f;

        private Rigidbody _rigidbody;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>() ?? gameObject.AddComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
            _rigidbody.useGravity = false;
        }

        public override bool CheckIfCanMoveBy(Vector3 delta)
        {
            RaycastHit hitInfo;
            // Sweeptest wisdom from 
            // http://answers.unity3d.com/questions/499013/cubecasting.html
            return !_rigidbody.SweepTest(delta, out hitInfo, delta.magnitude);
        }

        public override Vector3 GetMaxDelta(Vector3 delta)
        {
            RaycastHit hitInfo;
            if(!_rigidbody.SweepTest(delta, out hitInfo, delta.magnitude))
            {
                return KeepDistance(delta, hitInfo.point);
            }

            delta *= (hitInfo.distance / delta.magnitude);
            for (var i = 0; i <= 9; i += 3)
            {
                var dTest = delta / (i + 1);
                if (!_rigidbody.SweepTest(dTest, out hitInfo, dTest.magnitude))
                {
                    return KeepDistance(dTest, hitInfo.point);
                }
            }
            return Vector3.zero;
        }

        private  Vector3 KeepDistance(Vector3 delta, Vector3 hitPoint)
        {
            var distanceVector = hitPoint - transform.position;
            return delta - (distanceVector.normalized * MinDistance);
        }
    }
}


