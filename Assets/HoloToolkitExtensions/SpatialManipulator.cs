using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace LocalJoost.HoloToolkitExtensions
{
    public class SpatialManipulator : MonoBehaviour
    {
        public float MoveSpeed = 0.1f;

        public float RotateSpeed = 6f;

        public float ScaleSpeed = 0.2f;


        public BaseRayStabilizer Stabilizer = null;

        public BaseSpatialMappingCollisionDetector CollisonDetector;

        void Start()
        {
            Mode = ManipulationMode.None;
            if (CollisonDetector == null)
            {
                CollisonDetector = gameObject.AddComponent<DefaultMappingCollisionDetector>();
            }
        }

        public void Faster()
        {
            if (Mode == ManipulationMode.Move)
            {
                MoveSpeed *= 2f;
            }

            if (Mode == ManipulationMode.Rotate)
            {
                RotateSpeed *= 2f;
            }
            if (Mode == ManipulationMode.Scale)
            {
                ScaleSpeed *= 2f;
            }
        }

        public ManipulationMode Mode { get; set; }


        public void Slower()
        {
            if (Mode == ManipulationMode.Move)
            {
                MoveSpeed /= 2f;
            }

            if (Mode == ManipulationMode.Rotate)
            {
                RotateSpeed /= 2f;
            }

            if (Mode == ManipulationMode.Scale)
            {
                ScaleSpeed /= 2f;
            }
        }

        public void Manipulate(Vector3 manipulationData)
        {
            switch (Mode)
            {
                case ManipulationMode.Move:
                    Move(manipulationData);
                    break;
                case ManipulationMode.Rotate:
                    Rotate(manipulationData);
                    break;
                case ManipulationMode.Scale:
                    Scale(manipulationData);
                    break;
            }
        }

        void Move(Vector3 manipulationData)
        {
            var delta = manipulationData*MoveSpeed;
            if (CollisonDetector.CheckIfCanMoveBy(delta))
            {
                transform.localPosition += delta;
            }
        }

        void Rotate(Vector3 manipulationData)
        {
            transform.RotateAround(transform.position, Camera.main.transform.up, 
                -manipulationData.x * RotateSpeed);
            transform.RotateAround(transform.position, Camera.main.transform.forward, 
                manipulationData.y * RotateSpeed);
            transform.RotateAround(transform.position, Camera.main.transform.right, 
                manipulationData.z * RotateSpeed);
        }

        void Scale(Vector3 manipulationData)
        {
            transform.localScale *= 1.0f - (manipulationData.z*ScaleSpeed);
        }
    }
}
