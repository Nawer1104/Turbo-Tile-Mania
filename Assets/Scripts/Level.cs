using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<GameObject> gameObjects;

    public List<Block> blocksSelected;

    public void AddBlock(Block block)
    {
        if (!blocksSelected.Contains(block))
        {
            blocksSelected.Add(block);
            block.Select();

            if (blocksSelected.Count == 3)
            {
                CheckBlock();
            }
        }
        else
        {
            blocksSelected.Remove(block);
            block.UnSelect();
        }
    }

    public void CheckBlock()
    {
        if (blocksSelected[0].GetComponent<SpriteRenderer>().sprite == blocksSelected[1].GetComponent<SpriteRenderer>().sprite && blocksSelected[0].GetComponent<SpriteRenderer>().sprite == blocksSelected[2].GetComponent<SpriteRenderer>().sprite)
        {
            blocksSelected[0].DestroyBlock();
            blocksSelected[1].DestroyBlock();
            blocksSelected[2].DestroyBlock();
            blocksSelected.Clear();
        }
        else
        {
            blocksSelected[0].UnSelect();
            blocksSelected[1].UnSelect();
            blocksSelected[2].UnSelect();
            blocksSelected.Clear();
        }
    }

    public static List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }
}
