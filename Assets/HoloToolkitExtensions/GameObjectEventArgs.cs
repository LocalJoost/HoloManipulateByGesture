using System;
using UnityEngine;

namespace LocalJoost.HoloToolkitExtensions
{
    public class GameObjectEventArgs : EventArgs
    {
        public GameObject GameObject { get; private set; }

        public GameObjectEventArgs(GameObject gameObject)
        {
            GameObject = gameObject;
        }
    }
}