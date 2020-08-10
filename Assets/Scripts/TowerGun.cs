using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceArcade
{
    public class TowerGun : MonoBehaviour
    {
        [Header("Характеристики пушки")]
        [Tooltip("Время между выстрелами")]
        public float shootDelay = 0.1f;

        [Header("Характеристики снаряда")]
        [Tooltip("Снаряд для пушки")]
        public GameObject currentProjectille;
        [Tooltip("Скорость пули")]
        public float speedProject = 5;
        [Tooltip("Время жизни снаряда")]
        public float timeLiveProhect = 0.5f;


        protected float shootDelayCounter;

        internal Transform thisTransform;

        static GameController gameController;

        void Awake()
        {
            thisTransform = this.transform;
            if (gameController == null) gameController = GameObject.FindObjectOfType<GameController>();
        }

        void FixedUpdate()
        {

            if (currentProjectille && Input.GetMouseButton(0))
            {
                Shoot();
            }
            LockAtMouse();
        }

        /// <summary>
        /// Данный метод позволяет повернуть ствол прям в сторону мышки
        /// </summary>
        public void LockAtMouse()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = (mousePosition - thisTransform.position).normalized;
            float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            thisTransform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
        }
        
        /// <summary>
        /// Выстрел
        /// </summary>
        private void Shoot()
        {
            shootDelayCounter += Time.deltaTime;
            if (shootDelayCounter >= shootDelay)
            {
                var bullet = Instantiate(currentProjectille, thisTransform.position, thisTransform.rotation);
                var b = bullet.GetComponent<Bullet>();
                b.flightSpeed = speedProject;
                b.thisTransform = thisTransform;
                b.isActive = true;
                
                Destroy(bullet, timeLiveProhect);
                shootDelayCounter = 0;
            }
        }
    }
}