using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithCar : MonoBehaviour
{
    public GameObject hint;

    private bool isOnCar = false;
    private CarMovement car;

    private void Start()
    {
        hint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isOnCar)
        {
            // 1 ¬ключить управление машиной
            car.isActive = true;

            // 2. ¬ключить физику машинке
            car.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            car.GetComponent<CapsuleCollider2D>().enabled = true;

            // 3 —крыть персонажа
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        car = collision.gameObject.GetComponent<CarMovement>();

        isOnCar = true;
        hint.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        car = null;

        isOnCar = false;
        hint.SetActive(false);
    }
}
