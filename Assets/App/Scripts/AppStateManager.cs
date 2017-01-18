using HoloToolkit.Unity.InputModule;
using LocalJoost.HoloToolkitExtensions;
using UnityEngine;

public class AppStateManager : BaseAppStateManager, IManipulationHandler
{
    void Start()
    {
        InputManager.Instance.AddGlobalListener(gameObject);
    }

    public static new AppStateManager Instance
    {
        get { return (AppStateManager)BaseAppStateManager.Instance; }
    }

    protected override void ResetDeselectedObject(GameObject oldGameObject)
    {
        var manipulator = GetManipulator(oldGameObject);
        if (manipulator != null)
        {
            manipulator.Mode = ManipulationMode.None;
        }
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

    protected SpatialManipulator GetManipulator(GameObject obj)
    {
        if (obj == null)
        {
            return null;
        }
        var manipulator = obj.GetComponent<SpatialManipulator>() ??
            obj.GetComponentInChildren<SpatialManipulator>();
        return manipulator;
    }
}