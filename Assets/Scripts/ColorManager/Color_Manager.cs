using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EDGEE.Core.Singleton;

public class Color_Manager : Singleton<Color_Manager>
{
    public List<Material> materials;
    public List<ColorSetup> colorSetups;

    public void ChangeColorByType(ArtManager.ArtType artType)
    {
       var setup = colorSetups.Find(i => i.artType == artType);

        for(int i = 0; i < materials.Count; i++)
        {
            if (i < setup.colors.Count)
            {
                materials[i].SetColor("_BaseColor", setup.colors[i]);
            }
        }

    } 
}
[System.Serializable]
public class ColorSetup
{
    public ArtManager.ArtType artType;
    public List<Color> colors;

}

