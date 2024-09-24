using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public AudioClip gold , hit;
    public GameControl gameC;
    private float velocity =10;
    private Rigidbody rb;  // Rigidbody referansı
    public float knockbackForce = 10f;  // Geri itme kuvveti

    // Start is called before the first frame update
    void Start()
    {
         gameC = FindObjectOfType<GameControl>();  
         // Scene'deki GameControl objesini bulur.

         rb = GetComponent<Rigidbody>();  // Rigidbody'yi al
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

        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
         Debug.Log("Horizontal: " + x + ", Vertical: " + y);  // Girişleri log'la

        x*=Time.deltaTime* velocity ;
        y*=Time.deltaTime*velocity;

        transform.Translate(x,0f,y);
      }
    }

    void OnTriggerEnter(Collider other)
{
    if (other.gameObject.tag.Equals("gold"))
        { 
        GetComponent<AudioSource>().PlayOneShot(gold,1f);
        Debug.Log("Altın alındı!");
        gameC.GoldIncrease();
        Destroy(other.gameObject);
         }
         
    }

    // Düşmanlar için fiziksel çarpışma yöntemi
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("enemy"))
        {
              GetComponent<AudioSource>().PlayOneShot(hit,1f);
            Debug.Log("Düşmanla çarpışıldı!");
            gameC.gameContiniue = false;  // Oyun durduruluyor

            // Geri itme işlemi
            Vector3 knockbackDirection = transform.position - collision.transform.position;
            knockbackDirection.y = 0;  // Oyuncunun yukarı doğru gitmesini istemiyorsak Y eksenini sıfırlıyoruz
            knockbackDirection.Normalize();

            rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);  // Geri itme kuvveti
        }
    }
}
