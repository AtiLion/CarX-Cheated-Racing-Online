using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EZHax.Interfaces;
using UnityEngine;

namespace CarXCheatedRacingOnline.Menus
{
    public class PlayerMenu : IMenu
    {
        #region Properties
        public string Title => "Player Menu";
        public string ButtonText => "Player";
        public bool Enabled => true;

        public bool Visible { get; set; }
        public Rect Window { get; set; }
        #endregion

        public void Load()
        {
            Visible = false;
            Window = new Rect(10, 10, 200, 300);
        }

        public void Unload()
        {
            // More dicks
        }

        #region Functions
        public void OnDraw()
        {
            if(GUILayout.Button("Finish race"))
            {
                ConfigurationManager configurationManager = UnityEngine.Object.FindObjectOfType<ConfigurationManager>();
                if (configurationManager == null)
                    return;
                CheckpointsData dataByType = configurationManager.GetDataByType<CheckpointsData>();
                if (dataByType == null)
                    return;
                SetupCarDescUI setupCarDescUI = UnityEngine.Object.FindObjectOfType<SetupCarDescUI>();
                if (setupCarDescUI == null)
                    return;

                foreach (Checkpoint cp in dataByType.GetPoints())
                {
                    if (cp.OnCarEnterEvent != null)
                        cp.OnCarEnterEvent(cp, setupCarDescUI.car);
                }
                setupCarDescUI.car.transform.position = dataByType.GetStartLine().transform.position;
            }
        }

        public void OnToggle(bool newState)
        {
        }
        #endregion
    }
}
