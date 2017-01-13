using System;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace LocalJoost.HoloToolkitExtensions
{
    public class BaseAppStateManager : Singleton<BaseAppStateManager>
    {




        private GameObject _selectedGameObject;

        public GameObject SelectedGameObject
        {
            get { return _selectedGameObject; }
            set
            {
                if (_selectedGameObject != value)
                {
                    ResetDeselectedObject(_selectedGameObject);
                    _selectedGameObject = value;
                    if (SelectedObjectChanged != null)
                    {
                        SelectedObjectChanged(this, new GameObjectEventArgs(_selectedGameObject));
                    }
                }
            }
        }

        private void ResetDeselectedObject(GameObject oldGameObject)
        {
            if (oldGameObject != null)
            {
                var manipulator = GetManipulator(oldGameObject);
                if (manipulator != null)
                {
                    manipulator.Mode = ManipulationMode.None;
                }
            }
        }

        public event EventHandler<GameObjectEventArgs> SelectedObjectChanged;

        protected SpatialManipulator GetManipulator(GameObject obj)
        {
            var manipulator = obj.GetComponent<SpatialManipulator>() ??
                obj.GetComponentInChildren<SpatialManipulator>();
            return manipulator;
        }
    }
}
