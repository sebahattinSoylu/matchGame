using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform dragHolder,dropHolder;
    [SerializeField] List<DragManager> dragList;

    [SerializeField] DropManager dropPrefab;


    private void Start() {
        ObjeleriOlustur();
    }
    void ObjeleriOlustur()
    {
        dragList=dragList.OrderBy(i=>Random.value).Take(3).ToList();

        for (int i = 0; i < dragList.Count; i++)
        {
            DragManager dragObje=Instantiate(dragList[i],dragHolder.GetChild(i).position,Quaternion.identity);
            dragObje.transform.parent=dragHolder;

            DropManager dropObje=Instantiate(dropPrefab,dropHolder.GetChild(i).position,Quaternion.identity);
            dropObje.transform.parent=dropHolder;

            dropObje.GetComponent<SpriteRenderer>().sprite=dragObje.GetComponent<SpriteRenderer>().sprite;
            dragObje.GetComponent<DragManager>().InitFNC(dropObje);
        }
    }
}
