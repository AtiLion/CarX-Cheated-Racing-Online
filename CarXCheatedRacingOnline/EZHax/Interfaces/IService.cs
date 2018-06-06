namespace EZHax.Interfaces
{
    public interface IService : ILoadable
    {
        #region Properties
        bool Running { get; }
        #endregion

        #region Functions
        void OnGUI();
        void OnUpdate();
        #endregion
    }
}
