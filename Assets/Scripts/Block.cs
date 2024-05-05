using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Block : MonoBehaviour
{
    public GameObject vfxDestroy;


    private void OnMouseDown()
    {
        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].AddBlock(this);
    }

    public void Select()
    {
        transform.DOScale(1.2f, 0.2f);
    }

    public void UnSelect()
    {
        transform.DOScale(1f, 0.2f);
    }

    public void DestroyBlock()
    {
        GameObject vfx = Instantiate(vfxDestroy, transform.position, Quaternion.identity) as GameObject;
        Destroy(vfx, 1f);

        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
        GameManager.Instance.CheckLevelUp();

        gameObject.SetActive(false);
    }
}
