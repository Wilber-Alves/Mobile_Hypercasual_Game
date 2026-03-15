using UnityEngine;
using System.Collections.Generic;
using EDGEE.Core.Singleton;

public class ArtManager : Singleton <ArtManager>
{
    public enum ArtType
    {
        PFB_Default,
        PFB_Castle,
        PFB_Woods,
        PFB_Cave
    }

    public List<ArtSetup> artSetups;

    public ArtSetup GetSetupByType(ArtType artType)
    {
       return artSetups.Find(i => i.artType == artType);
    }
}

[System.Serializable]


public class ArtSetup
{
    public ArtManager.ArtType artType;
    public GameObject gameObject;

}
