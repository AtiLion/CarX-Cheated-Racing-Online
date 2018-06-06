using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarXCheatedRacingOnline.Menus;
using CarXCheatedRacingOnline.Services;
using EZHax.Interfaces;
using UnityEngine;

namespace CarXCheatedRacingOnline
{
    public class CarXCheatedRacingOnline : MonoBehaviour
    {
        #region Properties
        public EZHax.EZHax HaxMenu { get; private set; }
        #endregion

        #region Mono Functions
        void Start()
        {
            // Init EZHax
            EZHax.EZHax.Menus = new IMenu[]
            {
                new GameMenu(),
                new PlayerMenu()
            };
            EZHax.EZHax.Services = new IService[]
            {
                new GameService()
            };
            EZHax.EZHax.Name = "CarX Cheat by AtiLion";
            foreach(IMenu menu in EZHax.EZHax.Menus)
                DI.DependencyInjector.InjectObjectsInto(menu);
            foreach (IService service in EZHax.EZHax.Services)
                DI.DependencyInjector.InjectObjectsInto(service);
            HaxMenu = gameObject.AddComponent<EZHax.EZHax>();
        }
        #endregion
    }
}
