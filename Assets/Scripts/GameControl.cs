using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public bool gameContiniue =true;
    public int goldNumber=0;
    public UnityEngine.UI.Text goldNumberText;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GoldIncrease(){
    goldNumber += 1;
    Debug.Log("Toplam Altın: " + goldNumber);  // Altın sayısını log'la
    goldNumberText.text = "" + goldNumber;
    }

   
}
