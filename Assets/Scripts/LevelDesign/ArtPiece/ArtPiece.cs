using UnityEngine;
using UnityEngine.Rendering;

public class ArtPiece : MonoBehaviour
{
    public GameObject artPiecePrefab;

    public void ChangePiece(GameObject piece)
    {
        if (artPiecePrefab != null)
        { 
            Destroy(artPiecePrefab);
        }
        artPiecePrefab = Instantiate(piece, transform);
        artPiecePrefab.transform.localPosition = Vector3.zero;

    }

}
