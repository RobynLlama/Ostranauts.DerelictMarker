using HarmonyLib;

public class GUIOrbitDraw_Patches
{
  [HarmonyPatch(typeof(GUIOrbitDraw), nameof(GUIOrbitDraw.UpdateShipDraw))]
  [HarmonyPostfix]
  internal static void UpdateShipDraw_Postfix(GUIOrbitDraw __instance)
  {

    if (__instance.GetKnobLabelsState == 0)
      return;

    /*
        This is called in an update loop in GUIOrbitDraw so I may need
        to intentionally throttle update times to keep performance cost
        down.
      */

    /*
      Modify each ShipDraw entry in the table based on if the player
      has its navigation info and has docked on it before
    */

    foreach (var item in __instance.aShipDraws)
    {
      if (DerelictMarker.Utils.GetVesselIsKnownButNotExplored(item.sDisplayRegID))
      {
        //DerelictMarker.DerelictMarkerPlugin.Log.LogMessage($"Modifying Text Label for: {item.sDisplayRegID}");
        item.txtLabel.text += "*";
        continue;
      }

      //DerelictMarker.DerelictMarkerPlugin.Log.LogMessage($"Not modifying Text Label for: {item.sDisplayRegID}");
    }
  }
}
