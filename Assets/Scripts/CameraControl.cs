using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControl : MonoBehaviour

{
    public GameControl gameC;
    float sensibility=5f;
    float softness=2f;

    Vector2 transitionPos;
    Vector2 camPos;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gameC = FindObjectOfType<GameControl>();  // Scene'deki GameControl objesini bulur.
        player=transform.parent.gameObject;

        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameC == null)
    {
        Debug.LogError("GameControl referansı atanmadı!");
        return;
    }

        if(gameC.gameContiniue){
      
        Vector2 mousePos=new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Debug.Log("Mouse X: " + mousePos.x + ", Mouse Y: " + mousePos.y);  // Girişleri log'la

        
        mousePos = Vector2.Scale(mousePos, new Vector2(sensibility*softness, sensibility*softness));
        transitionPos.x=Mathf.Lerp(transitionPos.x, mousePos.x, 1f/softness);
        transitionPos.y=Mathf.Lerp(transitionPos.y, mousePos.y, 1f/softness);
        camPos += transitionPos;

        transform.localRotation = Quaternion.AngleAxis(-camPos.y, Vector3.right);
        //GİZMOLAR kendi ekseni etrafında dönücek
        //yukarı aşağı

        player.transform.localRotation=Quaternion.AngleAxis(camPos.x,player.transform.up);
        }

    }
}
