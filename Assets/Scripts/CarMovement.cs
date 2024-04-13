using UnityEngine;

public class CarMovement : MonoBehaviour
{
 
        public bool isActive = true;

        public float speed = 2f;

        private Rigidbody2D rb;

     
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            float x = Input.GetAxis("Horizontal");

            if (isActive)
            {
               rb.velocity = new Vector2(x * speed, rb.velocity.y);
            }
        }
    }
