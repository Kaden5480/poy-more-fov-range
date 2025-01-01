using HarmonyLib;
using UnityEngine;

#if BEPINEX

using BepInEx;

namespace MoreFOVRange {
    [BepInPlugin("com.github.Kaden5480.poy-more-fov-range", "MoreFOVRange", PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin {
        /**
         * <summary>
         * Executes when the plugin is being loaded.
         * </summary>
         */
        public void Awake() {
            Harmony.CreateAndPatchAll(typeof(PatchFOVRange));
        }

#elif MELONLOADER

using MelonLoader;

[assembly: MelonInfo(typeof(MoreFOVRange.Plugin), "MoreFOVRange", PluginInfo.PLUGIN_VERSION, "Kaden5480")]
[assembly: MelonGame("TraipseWare", "Peaks of Yore")]

namespace MoreFOVRange {
    public class Plugin: MelonMod {

#endif

        /**
         * <summary>
         * Patches the FOV slider to have a greater range.
         * </summary>
         */
        [HarmonyPatch(typeof(GraphicsOptions), "Awake")]
        static class PatchFOVRange {
            static void Postfix(GraphicsOptions __instance) {
                __instance.fovSlider.minValue = 0f;
                __instance.fovSlider.maxValue = 180f;
            }
        }

    }
}
