using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerHealth : MonoBehaviour
{

     // in dit script gebeuren er meerdere dingen.
     // de speler krijgt damage als hij tegen een enemy aan loopt
     // de speler word naar een checkpoint gebracht als hij tegen een enemy aan loopt
     // en de healthbar word aangepast als de speler tegen een enemy aan loopt
     // dit moet ook SRP kunnen

    // reguleert de health van de speler en Spawning


    //health
    public int maxHealth = 10;
    public int health;

    //spawn
    private Vector3 SpawnIn;
    private Vector3 Respawn;
    private Rigidbody2D rb;





    //Healthbar
    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite Skull;



    void Start()
    {
        health= maxHealth;
        Respawn = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        foreach(Image img in hearts) 
        {
            img.sprite = Skull;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = FullHeart;
        }
        
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Checkpoint")
        {
            SpawnIn = transform.position;
           
            Debug.Log("Check");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Thread.Sleep(1000);
        transform.position = SpawnIn;
        transform.rotation = Quaternion.identity;
        if (health <= 0)
        {
            Thread.Sleep(1000);
            transform.position = Respawn;
            SceneManager.LoadScene("Scene1");

            
        }
    }
}
