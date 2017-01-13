using System.Runtime.InteropServices;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

namespace LocalJoost.HoloToolkitExtensions
{
    public class AppStateManager : BaseAppStateManager, IManipulationHandler
    {
        void Start()
        {
            InputManager.Instance.PushFallbackInputHandler(gameObject);
        }

        public static new AppStateManager Instance
        {
            get { return (AppStateManager)BaseAppStateManager.Instance; }
        }

        public void OnManipulationUpdated(ManipulationEventData eventData)
        {
            if (SelectedGameObject != null)
            {
                var manipulator = GetManipulator(SelectedGameObject);
                if (manipulator != null)
                {
                    manipulator.Manipulate(eventData.CumulativeDelta);
                }
            }
        }

        public void OnManipulationStarted(ManipulationEventData eventData)
        {

        }

        public void OnManipulationCompleted(ManipulationEventData eventData)
        {
        }

        public void OnManipulationCanceled(ManipulationEventData eventData)
        {
        }
    }
}