using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceArcade
{
    /// <summary>
    /// Скрипт пули
    /// Пуля должна иметь скорость полета
    /// Она должна лететь в направлении мыши
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        [Header("Снаряд")]
        [Tooltip("Скорость полета снаряда м/c\nЗначение можно поменять в пушке")]
        public float flightSpeed = 1;

        [Tooltip("Если пуля стреляная, то true")]
        public bool isActive = false;

        static GameController gameController;

        internal Transform thisTransform;
        internal Rigidbody2D rb;

        

        void Awake()
        {
            thisTransform = this.transform;
            if (gameController == null) gameController = GameObject.FindObjectOfType<GameController>();
            rb = gameObject.GetComponent<Rigidbody2D>();
        }


        void FixedUpdate()
        {
            if (isActive)
            {
                Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                direction = (direction - new Vector2(thisTransform.position.x, thisTransform.position.y));
                rb.AddForce(direction.normalized * flightSpeed, ForceMode2D.Impulse);
            }
        }
    }
}