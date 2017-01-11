using System;
using UnityEngine;

namespace LocalJoost.HoloToolkitExtensions
{
    public class DefaultMappingCollisionDetector : BaseSpatialMappingCollisionDetector
    {
        public  override bool CheckIfCanMoveBy(Vector3 delta)
        {
            Debug.Log("No SpatialMappingCollisionDetector found, using default");
            return true;
        }

        public override Vector3 GetMaxDelta(Vector3 delta)
        {
            Debug.Log("No SpatialMappingCollisionDetector found, using default");
            return delta;
        }
    }
}