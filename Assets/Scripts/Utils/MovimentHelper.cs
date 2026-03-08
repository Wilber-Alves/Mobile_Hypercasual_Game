using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class MovimentHelper : MonoBehaviour
{
    public List<Transform> positions;
    public float duration = 1f;

    private int _index = 0;

    private void Start()
    {
        positions[0].transform.position = transform.position;
        NextIndex();
        StartCoroutine(StartMoviment());
    }

    private void NextIndex()
    {
        _index++;
        if (_index >= positions.Count)
        {
            _index = 0;
        }
    }

    IEnumerator StartMoviment()
    { 
        float time = 0;

        while (true)
        { 
            var currentposition = transform.position;

            while (time < duration)
            {
                time += Time.deltaTime;
                transform.position = Vector3.Lerp(currentposition, positions[_index].transform.position, (time / duration));
                yield return null;
            }
                NextIndex();
                time = 0;
                yield return null;
        }

    }

}
