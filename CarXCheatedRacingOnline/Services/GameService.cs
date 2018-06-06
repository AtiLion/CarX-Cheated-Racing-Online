using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarXCheatedRacingOnline.Menus;
using EZHax.Interfaces;

namespace CarXCheatedRacingOnline.Services
{
    public class GameService : IService
    {
        #region Variables
        private GameMenu _GameMenu;
        #endregion

        #region Properties
        public bool Running => true;
        #endregion

        #region Fields
        [DI.Dependency]
        private GamePrefs m_prefs;
        #endregion

        public void Load()
        {
            // Set the variables
            _GameMenu = EZHax.EZHax.GetMenu<GameMenu>();

            // Set events
            m_prefs.money.OnMoneyChanged += OnMoneyChange;
        }

        public void Unload()
        {
            // Unset the variables
            _GameMenu = null;

            // Unset events
            m_prefs.money.OnMoneyChanged -= OnMoneyChange;
        }

        #region Functions
        public void OnGUI()
        {
            
        }

        public void OnUpdate()
        {
            
        }
        #endregion

        #region Event Functions
        private void OnMoneyChange(int value, ECurrencyType currencyType)
        {
            if (_GameMenu.StaticMoney && int.TryParse(_GameMenu.Money, out int money))
                m_prefs.money.coins = money;
        }
        #endregion
    }
}
