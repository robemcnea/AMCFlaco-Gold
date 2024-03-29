﻿using BepInEx;
using dark.efijiPOIWikjek;
using ShibaGTTemplate.Backend;
using ShibaGTTemplate.UI;
using HarmonyLib;
using Loading;
using System;
using System.Diagnostics;
using UnityEngine;
using static ShibaGTTemplate.Plugin;
using Object = UnityEngine.Object;

namespace ShibaGTTemplate
{
    [BepInPlugin(Name, GUID, Version)]
    public class Plugin : BaseUnityPlugin
    {
        public const string Name = "AMCFLACOGOLD";
        public const string GUID = "AMCFLACOGOLD";
        public const string Version = "0.2";

        private bool patchedHarmony = false;
        private static GameObject Gameobject;
        [System.Serializable]
        public class LoginData
        {
            public string license;

        }
        void Awake()
        {
            if (!patchedHarmony && Loader.loaded == false)
            {
                Harmony harmony = new Harmony(GUID);
                harmony.PatchAll();
                patchedHarmony = true;
                Loader.loaded = true;

            }
        }
    }
    [HarmonyPatch(typeof(GorillaLocomotion.Player), "FixedUpdate")]
    internal class UpdatePatch
    {
        private static bool alreadyInit;
        public static GameObject Gameobject;

        static void Postfix()
        {
           
            if (!alreadyInit)
            {
                alreadyInit = true;
                Gameobject = new GameObject();
                Gameobject.AddComponent<Plugin>();
                Gameobject.AddComponent<WristMenu>();
                Gameobject.AddComponent<RigShit>();
                Gameobject.AddComponent<Mods>();
                Gameobject.AddComponent<GhostPatch>();
                Gameobject.AddComponent<GTAG_NotificationLib.NotifiLib>();
                Mods.Load();
                Object.DontDestroyOnLoad(Gameobject);
            }
        }
    }
}
