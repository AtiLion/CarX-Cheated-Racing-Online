using System.Linq;
using EZHax.Interfaces;
using UnityEngine;

namespace EZHax
{
    public class EZHax : MonoBehaviour
    {
        #region Variables
        public static IService[] Services = null;
        public static IMenu[] Menus = null;

        public static KeyCode MenuKey = KeyCode.F1;
        public static string Name = "EZHax by AtiLion";
        #endregion

        #region Properties
        public static EZHax Instance { get; private set; }
        public static CheatMenu CheatMenu { get; private set; }
        #endregion

        #region Mono Functions
        void Start()
        {
            Instance = this;
            CheatMenu = gameObject.AddComponent<CheatMenu>();

            foreach (IService service in Services)
                service.Load();
            foreach (IMenu menu in Menus)
                menu.Load();
        }

        void Update()
        {
            for (int i = 0; i < Services.Length; i++)
                if (Services[i].Running)
                    Services[i].OnUpdate();
        }

        void OnGUI()
        {
            for (int i = 0; i < Services.Length; i++)
                if (Services[i].Running)
                    Services[i].OnGUI();
            if (!CheatMenu.Visible)
                return;
            for(int i = 0; i < Menus.Length; i++)
                if (Menus[i].Visible)
                    Menus[i].Window = GUILayout.Window((i + 1), Menus[i].Window, OnWindow, Menus[i].Title);
        }

        void OnDestroy()
        {
            foreach (IMenu menu in Menus)
                menu.Unload();
            foreach (IService service in Services)
                service.Unload();
        }

        void OnWindow(int ID)
        {
            Menus[(ID - 1)].OnDraw();
            GUI.DragWindow();
        }
        #endregion

        #region Functions
        public static T GetMenu<T>() where T : IMenu => (T)Menus.FirstOrDefault(a => a.GetType() == typeof(T));
        public static T GetService<T>() where T : IService => (T)Services.FirstOrDefault(a => a.GetType() == typeof(T));
        #endregion
    }
}
