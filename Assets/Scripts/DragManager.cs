using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DragManager : MonoBehaviour
{
    AudioSource audioSource;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    AudioClip tutmaClibi,birakmaClibi;

    bool tasinabilirmi;

    Vector2 mouseUzaklik;

    Vector3 baslangicPos;

    DropManager dropObje;

    bool yerlestimi;

    private void Awake() {
        audioSource=GetComponent<AudioSource>();
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    private void Start() {
        baslangicPos=transform.position;
    }

    public void InitFNC(DropManager drop)
    {
        dropObje=drop;
    }
    private void Update()
    {
        if(!tasinabilirmi) return;
        if(yerlestimi) return;

        Vector2 mousePosition=MousePosizyonChange();
        transform.position=mousePosition-mouseUzaklik;
    }

    private void OnMouseDown()
    {
        if(!yerlestimi)
        {
             tasinabilirmi=true;
        audioSource.PlayOneShot(tutmaClibi);
        spriteRenderer.sortingOrder=100;
        mouseUzaklik=MousePosizyonChange()-(Vector2)transform.position;

        }
       
    }

    void OnMouseUp()
    {
        if(!yerlestimi)
        {
             if(Vector2.Distance(transform.position,dropObje.transform.position)<1)
            {
                yerlestimi=true;
                transform.position=dropObje.transform.position;
                dropObje.YerlestiFNC();

            }    else
            {
                tasinabilirmi=false;
                audioSource.PlayOneShot(birakmaClibi);
                transform.DOMove(baslangicPos,.2f).OnComplete(()=>spriteRenderer.sortingOrder=1);
            }
        }

       

        
    }


    Vector2 MousePosizyonChange()
    {
        return (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
