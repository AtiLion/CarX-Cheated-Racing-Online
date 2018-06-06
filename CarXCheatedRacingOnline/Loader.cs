using UnityEngine;

namespace CarXCheatedRacingOnline
{
    public class Loader : MonoBehaviour
    {
        #region Properties
        public static GameObject objMain { get; private set; } = null;
        public static CarXCheatedRacingOnline Instance { get; private set; } = null;
        #endregion

        public static void CallMeToHook()
        {
            if (objMain == null)
                objMain = new GameObject();
            if (Instance == null)
                Instance = objMain.AddComponent<CarXCheatedRacingOnline>();

            DontDestroyOnLoad(objMain);
        }
    }
}
