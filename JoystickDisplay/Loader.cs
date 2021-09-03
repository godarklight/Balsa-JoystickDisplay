using System;
using BalsaCore;
using UnityEngine;

namespace JoystickDisplay
{
    [BalsaAddon]
    public class Loader
    {
        [BalsaAddonInit]
        public static void BalsaInit()
        {
            GameEvents.Game.OnSessionStart.AddListener(StartMod);
        }

        private static void StartMod(NetworkLogic.SessionMode mode)
        {
            GameObject go = new GameObject("JoystickDisplay");
            JoystickDisplayMain jdm = go.AddComponent<JoystickDisplayMain>();
        }

        //Game exit
        [BalsaAddonFinalize]
        public static void BalsaFinalize()
        {
        }
    }
}
