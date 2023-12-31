using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // dit script zorgt ervoor de de speler damage krijgt als deze tegen de enemy aanloopt.
    // Zet achter de GameObject.Find de naam van de playern in de hiarchy
    // geef een damage int mee aan de enemy sprite
    // set KBtotaltime to anything above 0

    public int damage;
    public PlayerHealth playerhealth;
    public Playermove playermovement;

    private void Start()
    {
        playerhealth = GameObject.Find("Ellie").GetComponent<PlayerHealth>();
        playermovement = GameObject.Find("Ellie").GetComponent<Playermove>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
  
            playerhealth.TakeDamage(damage);
        }
    }
}
