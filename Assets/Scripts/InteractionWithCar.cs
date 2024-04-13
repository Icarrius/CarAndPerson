using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithCar : MonoBehaviour
{
    public GameObject hint;

    private bool isOnCar = false;
    private bool inCar = false;

    private CarMovement car;

    private void Start()
    {
        hint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isOnCar && !inCar)
        {
            // 1 �������� ���������� �������
            car.isActive = true;

            // 3 ��������� ��������� ������ �������
            transform.SetParent(car.transform);

            // 4 ������ ���������
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

            // 5 ��������� ���������� ����������
            gameObject.GetComponent<PlayerMovement>().isActive = false;

            inCar = true;

            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && inCar)
        {
            // �������� ���������� �������
            car.isActive = false;

            // �������� ���������� ����������
            gameObject.GetComponent<PlayerMovement>().isActive = true;

            // ���������� ���������
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            // ��������� ��������� �� �������
            transform.SetParent(null);

            transform.localRotation = Quaternion.Euler(0, 0, 0);

            inCar = false;

            return;
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
