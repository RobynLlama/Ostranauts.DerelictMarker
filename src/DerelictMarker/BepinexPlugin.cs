using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace DerelictMarker;

[BepInPlugin(LCMPluginInfo.PLUGIN_GUID, LCMPluginInfo.PLUGIN_NAME, LCMPluginInfo.PLUGIN_VERSION)]
public class DerelictMarkerPlugin : BaseUnityPlugin
{
  internal static ManualLogSource Log = null!;

  private void Awake()
  {
    Log = Logger;
    Log.LogInfo($"Plugin {LCMPluginInfo.PLUGIN_NAME} version {LCMPluginInfo.PLUGIN_VERSION} is loaded!");

    try
    {
      Harmony patcher = new(LCMPluginInfo.PLUGIN_GUID);
      patcher.PatchAll(typeof(MFDShipSelect_Patches));
      patcher.PatchAll(typeof(GUIOrbitDraw_Patches));
      Log.LogMessage("Derelict Marker patches applied");
    }
    catch (Exception ex)
    {
      Log.LogError($"Unable to apply patches, stack trace:\n{ex}\n");
    }

  }

}
