using UnityEngine;

public class GridObject : MonoBehaviour
{
    [SerializeField] private GridLayer _layer;
    [SerializeField] private int _chance;
    [SerializeField] private ObjectType _type;

    public GridLayer Layer => _layer;
    public int Chance => _chance;
    public ObjectType Type => _type;

    private void OnValidate() => _chance = Mathf.Clamp(_chance, 1, 100);
}
