using System.Collections.Generic;
using UnityEngine;

public class BlocksMover : MonoBehaviour
{
    public static BlocksMover Instance { get; private set; }
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Больше одного объекта класса BlocksMover");
        }
    }

    BaseCell FirstCell;
    public void OnCellClick(BaseCell clickedCell)
    {
        if (FirstCell == null && clickedCell.BlockInside != null)
        {
            FirstCell = clickedCell;
            FirstCell.IsActivated = true;
        }
        else if (FirstCell != null)
        {
            if (clickedCell.CellState == CellState.EMPTY)
            {
                TryToMoveBlock(FirstCell, clickedCell);
            }
            FirstCell.IsActivated = false;
            FirstCell.SetDefaultColor();
            FirstCell = null;
        }
    }

    private void TryToMoveBlock(BaseCell firstCell, BaseCell secondCell)
    {
        Vector2Int fCellPos = firstCell.Position;

        List<Vector2Int> availablePositions = new List<Vector2Int>();
        availablePositions.Add(new Vector2Int(fCellPos.x, fCellPos.y + 1));
        availablePositions.Add(new Vector2Int(fCellPos.x, fCellPos.y - 1));
        availablePositions.Add(new Vector2Int(fCellPos.x + 1, fCellPos.y));
        availablePositions.Add(new Vector2Int(fCellPos.x - 1, fCellPos.y));
        bool canMove = availablePositions.Contains(secondCell.Position);
        if (canMove)
        {
            BaseBlock tempBlock = firstCell.BlockInside;
            firstCell.RemoveBlock();
            secondCell.PutInNewBlock(tempBlock);
        }
    }
    
}
