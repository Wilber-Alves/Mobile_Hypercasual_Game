using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using DG.Tweening;
//using UnityEditor;

public static class EDGEEUtil
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("EDGEE/New_Sphere %#&s")]
    public static void NewSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = Vector3.zero;
        Debug.Log("New Sphere Created");
    }

    [UnityEditor.MenuItem("EDGEE/New_Cube %#&c")]
    public static void NewCube()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = Vector3.zero;
        Debug.Log("New Cube Created");
    }
#endif

    public static void Scale(this Transform t, float size = 1.2f)
    {
        t.localScale = Vector3.one * size;
    }

    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

}
