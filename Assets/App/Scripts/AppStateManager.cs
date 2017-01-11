using System.Runtime.InteropServices;
using HoloToolkit.Unity;

namespace LocalJoost.HoloToolkitExtensions
{
    public class AppStateManager : BaseAppStateManager
    {
        public static new AppStateManager Instance
        {
            get { return (AppStateManager)BaseAppStateManager.Instance; }
        }
    }
}