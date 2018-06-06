using UnityEngine;

namespace EZHax
{
    public class CheatMenu : MonoBehaviour
    {
        #region Variables
        private Rect _Window = new Rect(10, 10, 200, 300);
        public bool Visible = false;
        #endregion

        #region Mono Functions
        void OnGUI()
        {
            if (Visible)
                _Window = GUILayout.Window(0, _Window, OnWindow, EZHax.Name);
        }

        void Update()
        {
            if (Input.GetKeyDown(EZHax.MenuKey))
                Visible = !Visible;
        }

        void OnWindow(int ID)
        {
            for(int i = 0; i < EZHax.Menus.Length; i++)
            {
                if (!EZHax.Menus[i].Enabled)
                    continue;

                if (GUILayout.Button(EZHax.Menus[i].ButtonText))
                {
                    EZHax.Menus[i].OnToggle(!EZHax.Menus[i].Visible);
                    EZHax.Menus[i].Visible = !EZHax.Menus[i].Visible;
                }
            }
            if (GUILayout.Button("Exit"))
                Visible = false;
            GUI.DragWindow();
        }
        #endregion
    }
}
