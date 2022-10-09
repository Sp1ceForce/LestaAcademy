using System;
using System.Collections.Generic;
using UnityEngine;

public class LineObserver : MonoBehaviour
{
    //Required color for line
    public BlockColors RequiredColor;

    public Action OnLineComplete;
    public bool IsComplete { get; private set; }
    Dictionary<BaseCell, bool> cellsDict = new Dictionary<BaseCell, bool>();
    [SerializeField] List<BaseCell> cellsInLine;
    void Start()
    {
        foreach (var cell in cellsInLine)
        {
            cellsDict.Add(cell, CheckColor(cell));
            cell.OnCellUpdate += OnCellUpdate;
        }
        CheckForCompletion();
    }

    void OnCellUpdate(BaseCell updatedCell)
    {
        cellsDict[updatedCell] = CheckColor(updatedCell);
        CheckForCompletion();
    }

    private void CheckForCompletion()
    {
        IsComplete = true;
        foreach (var keyValue in cellsDict)
        {
            if (!keyValue.Value) IsComplete = false;
        }
        if (IsComplete) OnLineComplete?.Invoke();
    }

    private bool CheckColor(BaseCell cellToCheck)
    {
        bool isRightColor = false;
        if (cellToCheck.BlockInside != null) isRightColor = cellToCheck.BlockInside.BlockColor == RequiredColor;
        return isRightColor;
    }
}
