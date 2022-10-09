using System.Collections.Generic;
using UnityEngine;

public class CellsGenerator : MonoBehaviour
{
    //Properties for cells generation

    [SerializeField] BaseCell cellPrefab;
    [SerializeField] int width = 5;
    [SerializeField] int height = 5;
    [SerializeField] List<BaseCell> cellsList;

    [SerializeField] float xSpacing = 0.2f;
    [SerializeField] float ySpacing = 0.2f;

    //Properties for blocks generation

    [SerializeField] int totalBlocks = 15;

    [SerializeField] BaseBlock RedBlock;
    [SerializeField] BaseBlock OrangeBlock;
    [SerializeField] BaseBlock YellowBlock;


    private void Start()
    {
        int blocksPerColor = totalBlocks / 3;
        GenerateBlocks(RedBlock, blocksPerColor);
        GenerateBlocks(OrangeBlock, blocksPerColor);
        GenerateBlocks(YellowBlock, blocksPerColor);

    }

    private void GenerateBlocks(BaseBlock block, int totalBlocks)
    {
        for (int i = 0; i < totalBlocks; i++)
        {

            BaseCell cell = cellsList[Random.Range(0, cellsList.Count)];
            if (cell.CellState == CellState.EMPTY)
            {
                BaseBlock newBlock = Instantiate(block);
                cell.PutInNewBlock(newBlock);
            }
            else
            {
                i--;
            }
        }
    }

    [ContextMenu("Generate Cells")]
    private void GenerateBaseCells()
    {

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                BaseCell newCell = Instantiate(cellPrefab);
                newCell.transform.parent = transform;
                newCell.transform.localPosition = new Vector3(i + xSpacing * i, j + ySpacing * j);
                newCell.Init(i, j);
            }
        }
    }
}
