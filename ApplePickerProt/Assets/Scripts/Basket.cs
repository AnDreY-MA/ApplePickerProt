using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynacally")]
    public Text scoreGT;

    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter"); //Получение ссылки на игровой объект ScoreCounter

        scoreGT = scoreGO.GetComponent<Text>(); // получение компонента Text этого игрового объекта

        scoreGT.text = "0";
    }

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition; //Получение координат мыши

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); //Преобразование точки на 2D плоскости в 3D координаты

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        //Поиск яблока, попашее в эту корзину
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            int score = int.Parse(scoreGT.text); //Преобразование текст в scoreGT в целое число
            score += 100;
            scoreGT.text = score.ToString();

            //Запомнить высшее достижение
            if(score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}