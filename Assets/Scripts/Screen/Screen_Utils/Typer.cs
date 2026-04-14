using UnityEngine;
using System.Collections;   
using System.Collections.Generic;
using TMPro;

public class Typer : MonoBehaviour
{

    public TextMeshProUGUI textMesh;
    public float timeBetweenLetters = 0.1f;

    public string phrase;

    [NaughtyAttributes.Button]

    public void Awake()
    {
        textMesh.text = "";
    }
    public void StartType()
    {
        StartCoroutine(Type(phrase));
    }

    IEnumerator Type (string s)
    {
       textMesh.text = "";
       foreach (char i in s.ToCharArray())
       {
         textMesh.text += i;
         yield return new WaitForSeconds(timeBetweenLetters);
       }
    }
}