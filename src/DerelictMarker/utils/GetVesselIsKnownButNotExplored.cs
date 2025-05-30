using Ostranauts.ShipGUIs.Utilities;

namespace DerelictMarker;

public static partial class Utils
{
  /// <summary>
  /// Checks if the player knows of a vessel but has not explored it <br /><br />
  /// Requirements: <br />
  ///  * The ship must exist (GetShipByRegID can return null) <br />
  ///  * It must be identified by the player <br />
  ///  * It must have been docked with by the player before
  /// </summary>
  /// <param name="strRegID">The registration ID of the vessel</param>
  /// <returns></returns>
  public static bool GetVesselIsKnownButNotExplored(string strRegID)
  {
    Ship realShip = CrewSim.system.GetShipByRegID(strRegID);

    if (realShip is not Ship validShip)
      return false;

    ShipInfo si = new(validShip);

    if (!si.Known || validShip.fLastVisit > 0.0f)
      return false;

    return true;
  }
}
