using HarmonyLib;
using Ostranauts.ShipGUIs.MFD;
using Ostranauts.ShipGUIs.Utilities;

internal class MFDShipSelect_Patches
{
  [HarmonyPatch(typeof(MFDShipSelect.DisplayMode), nameof(MFDShipSelect.DisplayMode.GetDisplayName))]
  [HarmonyPostfix]
  internal static void GetDisplayName_Postfix(ShipInfo si, ref string __result)
  {
    if (DerelictMarker.Utils.GetVesselIsKnownButNotExplored(si._strRegID))
    {
      //DerelictMarker.DerelictMarkerPlugin.Log.LogMessage($"Modifying: {si._strRegID}");
      __result += "*";
    }

    //DerelictMarker.DerelictMarkerPlugin.Log.LogMessage($"Not modifying: {si._strRegID}");
    return;
  }
}
