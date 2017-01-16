using System;
using HoloToolkit.Unity;
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

        protected virtual void ResetDeselectedObject(GameObject oldGameObject)
        {
        }

        public event EventHandler<GameObjectEventArgs> SelectedObjectChanged;
    }
}
