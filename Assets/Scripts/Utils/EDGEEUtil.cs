using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using DG.Tweening;

public static class EDGEEUtil
{
    public static void Scale(this Transform t, float size = 1.2f)
    {
        t.localScale = Vector3.one * size;
    }

    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

}
