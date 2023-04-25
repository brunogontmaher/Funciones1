using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Mosca : MonoBehaviour
{
    Vector3 initialPosition;
    public bool hasKey;
    public int livesCount = 0;
    public int ScoreCount = 0;
    public TextMeshProUGUI txtLives;
    public TextMeshProUGUI txtScore;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        txtLives.text = livesCount.ToString();
        txtScore.text = ScoreCount.ToString();


    }

    private void Update()
    {
        if (hasKey)
        {
            Debug.Log("Tiene la llave");
        }
    }


    //Destruir la mosca si colisiona con el ventilador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damager"))
        {
            LoseALife();
        }

        else if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            hasKey = true;
            ScorePoint();
        }
    }
    //Funciones
    void LoseALife() //pierde una vida
    {
        transform.position = initialPosition;
        livesCount--;
        txtLives.text = livesCount.ToString();
        if (livesCount == 0)
        {
            PlayerDeath();


        }
    }
    void PlayerDeath() //muere el objeto
    {

        Destroy(gameObject);
        //reprducir sonido
        //ejecutar una animacion
    }

   public void ScorePoint()
    {

        ScoreCount++;
        txtScore.text = ScoreCount.ToString();
        if (ScoreCount == 3)
        {
            Debug.Log("Has ganado");
            Destroy(gameObject);
        }




    }
}

