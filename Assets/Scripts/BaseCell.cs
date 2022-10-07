using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellState
{
    EMPTY,
    OCCUPIED,
    BLOCKED,
}
public enum BlockColors
{
    NONE = 0,
    RED = 1,
    ORANGE = 2,
    YELLOW = 3

}
public class BaseCell : MonoBehaviour
{
    //÷вета €чейки(чисто косметическа€ вещь)
    public Color BlockedColor;
    public Color OnHoverColor;
    public Color BaseColor;
    //ѕозици€ €чейки в матрице
    public Vector2Int Position;
    //“ребуемый цвет линии
    public BlockColors RequiredColor;

    public bool IsActive;
    public CellState CellState { get => cellState; }
    [SerializeField] private CellState cellState;
    private CellsController myCellController;
    private void Start()
    {
        if (!IsActive) return;
        SetDefaultColor();
    }
    //—менить цвет €чейки в зависимости от еЄ типа
    private void SetDefaultColor()
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

    public void Init(int x, int y, CellsController cellsController, bool isActive)
    {
        Position = new Vector2Int(x, y);
        myCellController = cellsController;
        IsActive = isActive;
    }
    private void OnMouseDown()
    {
        if (CellState == CellState.BLOCKED || !IsActive) return;
        
    }
    private void OnMouseEnter()
    {
        if (CellState == CellState.BLOCKED || !IsActive) return;
        GetComponent<SpriteRenderer>().color = OnHoverColor;
    }

    private void OnMouseExit()
    {
        if (CellState == CellState.BLOCKED || !IsActive) return;
        GetComponent<SpriteRenderer>().color = BaseColor;
    }
}
