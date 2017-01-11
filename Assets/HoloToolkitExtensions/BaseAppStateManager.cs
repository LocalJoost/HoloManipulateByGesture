//using System;
//using HoloToolkit.Unity;
//using UnityEngine;

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
                _selectedGameObject = value;
                if (SelectedObjectChanged != null)
                {
                    SelectedObjectChanged(this, new GameObjectEventArgs(_selectedGameObject));
                }
            }
        }

        public event EventHandler<GameObjectEventArgs> SelectedObjectChanged;
    }
}
