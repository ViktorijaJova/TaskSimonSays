using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //light color shade
    public Material lmat;
    //normal color shade
    public Material nmat;
    private Renderer myR;
    private Vector3 mytransformposition;
    public int myNumber=99;
    public SimonLogic myLogic;
    public delegate void ClickEvent(int number);

    public event ClickEvent onClick;
   
    
    void Awake()

    {
        myR = GetComponent<Renderer>();
        myR.enabled = true;
        mytransformposition = transform.position;
    }


    private void OnMouseDown()
    {
        if (myLogic.player)
        {
            ClickedColor();
            transform.position = new Vector3(mytransformposition.x, -.2f, mytransformposition.z);
            onClick.Invoke(myNumber);
            
        }
   
    }

    private void OnMouseUp()
    {
        OffClickedColor();
        transform.position = new Vector3(mytransformposition.x, mytransformposition.y, mytransformposition.z);

    }

    public void ClickedColor()
    {
        myR.sharedMaterial = nmat;
    }

    public void OffClickedColor()
    {
        myR.sharedMaterial = lmat;
    }
}