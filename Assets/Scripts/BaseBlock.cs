using UnityEngine;

public enum BlockColors
{
    NONE = 0,
    RED = 1,
    ORANGE = 2,
    YELLOW = 3

}
public class BaseBlock : MonoBehaviour
{
    public BlockColors BlockColor { get => _blockColors; }
    [SerializeField] private BlockColors _blockColors;

}
