using System.Collections.Generic;
using UnityEngine;

public class CellsController : MonoBehaviour
{
    [SerializeField] BaseCell cellPrefab;
    [SerializeField] int width = 5;
    [SerializeField] int height = 5;
    BaseCell[,] cells;

    [SerializeField] float xSpacing = 0.2f;
    [SerializeField] float ySpacing = 0.2f;



    private void Start()
    {
        
    }


    [ContextMenu("Generate Cells")]
    private void GenerateBaseCells()
    {
        cells = new BaseCell[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                BaseCell newCell = Instantiate(cellPrefab);
                newCell.transform.parent = transform;
                newCell.transform.localPosition = new Vector3(i + xSpacing * i, j + ySpacing * j);
                newCell.Init(i, j, this,true);
                cells[j,i] = newCell;
            }
        }
    }
}
