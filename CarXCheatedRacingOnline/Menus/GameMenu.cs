using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EZHax.Interfaces;
using UnityEngine;
using DB.Meta;

namespace CarXCheatedRacingOnline.Menus
{
    public class GameMenu : IMenu
    {
        #region Properties
        public string Title => "Game Menu";
        public string ButtonText => "Game";
        public bool Enabled => true;

        public bool Visible { get; set; }
        public Rect Window { get; set; }
        #endregion

        #region Hacks
        public string Money = "0";
        public bool StaticMoney = false;
        public string Level = "1";
        #endregion

        #region Fields
        [DI.Dependency]
        private GamePrefs m_prefs;
        [DI.Dependency]
        private DB.BaseModel m_model;
        #endregion

        public void Load()
        {
            Visible = false;
            Window = new Rect(10, 10, 200, 300);
        }

        public void Unload()
        {
            // Dicks
        }

        #region Functions
        public void OnDraw()
        {
            GUILayout.Label("Coins:");
            Money = GUILayout.TextField(Money);
            if(GUILayout.Button("Set coins"))
                if (int.TryParse(Money, out int money))
                    m_prefs.money.coins = money;
            StaticMoney = GUILayout.Toggle(StaticMoney, "Static money");
            GUILayout.Label("Level:");
            Level = GUILayout.TextField(Level);
            if (GUILayout.Button("Set level"))
                if (int.TryParse(Level, out int level))
                    for (int i = m_prefs.playerProfile.level; i < level; i++)
                        m_prefs.playerProfile.exp += m_prefs.playerProfile.nextLevelExp;
            if(GUILayout.Button("Unlock all available cars"))
                foreach(PlayerCar car in m_model.QueryAll<PlayerCar>())
                    m_prefs.locks.SetCarLockState(car.id, false);
            if (GUILayout.Button("Unlock all available profiles"))
                foreach (PlayerCarProfile profile in m_model.QueryAll<PlayerCarProfile>())
                    m_prefs.locks.SetProfileLockState(profile.id, false);
            if (GUILayout.Button("Unlock all available tracks"))
                foreach (DB.Meta.Track track in m_model.QueryAll<DB.Meta.Track>())
                    m_prefs.locks.SetTrackLockState(track.id, false);
        }

        public void OnToggle(bool newState)
        {
            Money = m_prefs.money.coins.ToString();
            Level = m_prefs.playerProfile.level.ToString();
        }
        #endregion
    }
}
