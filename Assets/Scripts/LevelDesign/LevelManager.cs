using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

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

    [Header("Animation")]
    public float scaleDuration = 0.5f;
    public float scaleTimeBetweenPieces = 0.1f;
    public Ease scaleEase = Ease.OutBack;

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
        var types = (ArtManager.ArtType[])System.Enum.GetValues(typeof(ArtManager.ArtType));
        artType = types[Random.Range(0, types.Length)];

        ClearSpawnedPieces();

        SpawnSpecificPiece(startPiecePrefab);

        for (int i = 0; i < pieceNumber; i++)
        {
            var randomPiece = levelPieces[Random.Range(0, levelPieces.Count)];
            SpawnSpecificPiece(randomPiece);
        }

        SpawnSpecificPiece(endPiecePrefab);

        Color_Manager.Instance.ChangeColorByType(artType);
       
        StartCoroutine(ScalePiecesByTime());
        
       
    }
    IEnumerator ScalePiecesByTime()
    { 
        yield return new WaitForEndOfFrame();

        foreach (var p in _spawnedPieces)
        { 
            p.transform.localScale = Vector3.zero;
        }

        yield return null;

        for (int i = 0; i < _spawnedPieces.Count; i++)
        { 
            _spawnedPieces[i].transform.DOScale(1, scaleDuration).SetEase(scaleEase);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);
        }

        CoinsAnimationManager.Instance.StartAnimations();
    }


    private void ClearSpawnedPieces()
    {
        for (int i = _spawnedPieces.Count - 1; i >= 0; i--)
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