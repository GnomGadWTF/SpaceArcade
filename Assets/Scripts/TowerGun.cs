using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceArcade
{
    public class TowerGun : MonoBehaviour
    {
        //[Header("Пушка")]

        private Vector3 mousePosition;
        internal Transform thisTransform;
        static GameController gameController;

        void Awake()
        {
            thisTransform = this.transform;
            if (gameController == null) gameController = GameObject.FindObjectOfType<GameController>();
        }

        void Start()
        {
        }

        void FixedUpdate()
        {
            Shoot();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                
            }
            LockAtMouse();
        }

        /// <summary>
        /// Данный метод позволяет повернуть ствол прям в сторону мышки
        /// </summary>
        public void LockAtMouse()
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = (mousePosition - thisTransform.position).normalized;
            float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            thisTransform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
        }
        public GameObject currentProjectille;

        public float shootDelay;

        public Transform shootPostion; // пустой объект на дуле пушки

        protected float shootDelayCounter;

        private Rigidbody2D myRigidbody;
      
        private void Shoot()
        {
            shootDelayCounter += Time.deltaTime;

            if (Input.GetMouseButton(0))
            {
                RotateToClick();

                if (shootDelayCounter >= shootDelay)
                {
                    var bullet = Instantiate(currentProjectille, shootPostion.position, shootPostion.rotation);
                    bullet.GetComponent<Bullet>().targetPosition = mousePosition1*10;
                    Destroy(bullet, 0.5f);
                    shootDelayCounter = 0;
                }
            }
        }

        private Vector3 mousePosition1;

        private float angle;

        void RotateToClick()
        {
            //позиция мыши в мировых координатах
            mousePosition1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Угол между объектами
            angle = Vector2.Angle(Vector2.right, mousePosition1 - transform.position); //угол между вектором от объекта к мыше и осью х

            // Мгновенное вращение
            transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition1.y ? angle : -angle);

            // Вращение с задержкой (не успеет повернуться, если в направлении клика стрелять)
            // transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.Euler (0, 0, transform.position.y < mousePosition.y ? angle : -angle), RotateSpeed * Time.deltaTime);
        }









    }
}