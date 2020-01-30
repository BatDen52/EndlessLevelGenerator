using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GridObject[] _templates;
    [SerializeField] private Transform _player;
    [SerializeField] private float _viewRadius;
    [SerializeField] private float _cellSize;

    private HashSet<Vector3Int> _collisionsMatrix = new HashSet<Vector3Int>();

    void Update()
    {
        FillRadious(_player.position, _viewRadius);
    }

    private void FillRadious(Vector3 center, float viewRadius)
    {
        int cellCountOnAxis = (int)(_viewRadius / _cellSize);
        Vector3Int fillAreaCenter = WorldToGridPosition(center);

        for (int x = -cellCountOnAxis; x < cellCountOnAxis; x++)
        {
            for (int z = -cellCountOnAxis; z < cellCountOnAxis; z++)
            {
                TryCreateOnLayer(GridLayer.Ground, fillAreaCenter + new Vector3Int(x, 0, z));
                TryCreateOnLayer(GridLayer.OnGround, fillAreaCenter + new Vector3Int(x, 0, z));
            }
        }
    }

    private void TryCreateOnLayer(GridLayer layer, Vector3Int gridPosition)
    {
        gridPosition.y = (int)layer;

        if (_collisionsMatrix.Contains(gridPosition))
            return;
        else
            _collisionsMatrix.Add(gridPosition);

        GridObject tamplate = GetRandomTemplate(layer);

        if (tamplate == null)
            return;

        Vector3 position = GridToWorldPosition(gridPosition);

        GameObject gameObj = Instantiate(tamplate, position, Quaternion.identity, transform).gameObject;
        Destroy(gameObj, _player.gameObject.GetComponent<PlayerController>().Speed/_cellSize);
    }

    private GridObject GetRandomTemplate(GridLayer layer)
    {
        var variants = _templates.Where(template => template.Layer == layer);

        if (variants.Count() == 1)
            return variants.First();

        foreach (var template in variants)
        {
            if (template.Chance > Random.Range(0, 100))
            {
                return template;
            }
        }

        return null;
    }

    private Vector3 GridToWorldPosition(Vector3Int gridPosition)
    {
        return new Vector3(
            gridPosition.x * _cellSize,
            gridPosition.y * _cellSize,
            gridPosition.z * _cellSize);
    }

    private Vector3Int WorldToGridPosition(Vector3 worldPosition)
    {
        return new Vector3Int(
            (int)(worldPosition.x / _cellSize),
            (int)(worldPosition.y / _cellSize),
            (int)(worldPosition.z / _cellSize));
    }
}
