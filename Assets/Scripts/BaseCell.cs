using System;
using UnityEngine;

public enum CellState
{
    EMPTY,
    OCCUPIED,
    BLOCKED,
}

public class BaseCell : MonoBehaviour
{
    public Action<BaseCell> OnCellUpdate;

    //Default cell colors
    [Header("Colors")]
    public Color BlockedColor;
    public Color OnHoverColor;
    public Color BaseColor;

    //Position of cell in matrix
    [Header("Position")]
    public Vector2Int Position;


    public bool IsActivated;

    public CellState CellState { get => cellState; }
    [SerializeField] private CellState cellState;

    public BaseBlock BlockInside { get; private set; }

    private void Start()
    {
        SetDefaultColor();
    }

    public void SetDefaultColor()
    {
        if (cellState == CellState.BLOCKED)
        {
            GetComponent<SpriteRenderer>().color = BlockedColor;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = BaseColor;
        }
    }

    public void Init(int x, int y)
    {
        cellState = CellState.EMPTY;
        Position = new Vector2Int(x, y);

    }
    private void OnMouseDown()
    {
        if (CellState == CellState.BLOCKED || IsActivated) return;
        BlocksMover.Instance.OnCellClick(this);
    }
    public void PutInNewBlock(BaseBlock newBlock)
    {
        newBlock.transform.parent = transform;
        newBlock.transform.localPosition = Vector2.zero;
        BlockInside = newBlock;
        cellState = CellState.OCCUPIED;
        OnCellUpdate?.Invoke(this);
    }
    public void RemoveBlock()
    {
        cellState = CellState.EMPTY;
        BlockInside = null;
        OnCellUpdate?.Invoke(this);

    }
    private void OnMouseEnter()
    {
        if (CellState == CellState.BLOCKED || IsActivated) return;
        GetComponent<SpriteRenderer>().color = OnHoverColor;
    }

    private void OnMouseExit()
    {
        if (CellState == CellState.BLOCKED || IsActivated) return;
        GetComponent<SpriteRenderer>().color = BaseColor;
    }
}
