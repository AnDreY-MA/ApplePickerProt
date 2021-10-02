using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject applePrefab; // Шаблон для создания яблок
    public float speed = 1f; // Скорость движения яблони
    public float leftAndRightEdge = 10f; //Растояние изменения движения яблони
    public float chanceToChangeDirections = 0.1f; //Рвероятность случайного изменения направления
    public float secondsBetweenAppleDrops = 1f; //Частота создания яблок

    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    void Update()
    {
        //Перемещение
        Vector3 pos = transform.position; //Хранение текущей позиции яблони
        pos.x += speed * Time.deltaTime; //Time.deltaTime - кол-во секунд, прошедших после отобр. предыд. кадра
        pos.x += 1.0f * 0.01f;
        pos.x += 0.01f;
        transform.position = pos;

        //Изменение направления
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        
    }

    /*void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }*/

}