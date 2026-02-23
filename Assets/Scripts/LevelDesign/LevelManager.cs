using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    // Public variables

    public ArtManager.ArtType artType;

    [Header("Level Container")]
    public Transform container;

    [Header("Levels")]
    public List<GameObject> levels;

    [Header("Level Pieces (Random)")]
    public List<LevelPieceBase> levelPieces;
    public int pieceNumber = 10;

    [Header("Fixed Pieces")]
    public LevelPieceBase startPiecePrefab;
    public LevelPieceBase endPiecePrefab;

    // Private variables

    [SerializeField] private int _index;
    private GameObject _currentLevel;

    [Header("Spawned Pieces")]
    private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();


    private void Start()
    {
        //SpawnNextLevel();
        CreateLevelPieces();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNextLevel();
        }
    }

    private void SpawnNextLevel()
    { 
        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;

            if (_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }

        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;

    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }

    private void CreateLevelPieces()
    { 
        ClearSpawnedPieces();

        SpawnSpecificPiece(startPiecePrefab);

        for (int i = 0; i < pieceNumber; i++)
        {
            var randomPiece = levelPieces[Random.Range(0, levelPieces.Count)];
            SpawnSpecificPiece(randomPiece);
        }
        SpawnSpecificPiece(endPiecePrefab);
    }

private void ClearSpawnedPieces()
    {
        for(int i = _spawnedPieces.Count - 1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }
        _spawnedPieces.Clear();
    }

    private void SpawnSpecificPiece(LevelPieceBase piecePrefab)
    {
        //var piece = levelPieces[Random.Range(0, levelPieces.Count)];
        //var spawnedPiece = Instantiate(piece, container);
        
        LevelPieceBase spawnedPiece;

        if (_spawnedPieces.Count > 0)
        {
            //var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            //spawnedPiece.transform.position = lastPiece.endPiece.position;
            //spawnedPiece = Instantiate(piece, lastPiece.endPiece.position, Quaternion.identity, container);

            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spawnedPiece = Instantiate(piecePrefab);

            Vector3 targetPos = lastPiece.endPiece.position;
            targetPos.x = container.position.x;
            targetPos.y = container.position.y;

            Vector3 offset = spawnedPiece.transform.position - spawnedPiece.startPiece.position;
            spawnedPiece.transform.position = lastPiece.endPiece.position + offset;

            spawnedPiece.transform.SetParent(container);
        }
        else
        {
            spawnedPiece = Instantiate(piecePrefab, container);
            spawnedPiece.transform.localPosition = Vector3.zero;

            Vector3 offset = spawnedPiece.transform.position - spawnedPiece.startPiece.position;
            spawnedPiece.transform.position += offset;
        }

        foreach (var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            p.ChangePiece(ArtManager.Instance.GetSetupByType(artType).gameObject);
        }

        _spawnedPieces.Add(spawnedPiece);

    }


}
