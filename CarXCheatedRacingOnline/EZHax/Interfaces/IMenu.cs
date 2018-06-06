using UnityEngine;

namespace EZHax.Interfaces
{
    public interface IMenu : ILoadable
    {
        #region Properties
        string Title { get; }
        string ButtonText { get; }
        bool Enabled { get; }

        bool Visible { get; set; }
        Rect Window { get; set; }
        #endregion

        #region Functions
        void OnDraw();
        void OnToggle(bool newState);
        #endregion
    }
}
