using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceArcade
{
    public class Bullet : MonoBehaviour
    {
        [Header("Снаряд")]
        [Tooltip("Скорость полета снаряда")]
        public float moveSpeed = 1;



        internal Transform thisTransform;
        static GameController gameController;


        void Awake()
        {
            thisTransform = this.transform;
            if (gameController == null) gameController = GameObject.FindObjectOfType<GameController>();
        }


        public Vector3 targetPosition;

        float moveTimeSpeed = 1;

        private Vector2 startPos;

        float t = 0;

        bool onTarget;

        void Start()
        {
            startPos = transform.position;
            onTarget = false;
        }


        void Update()
        {
            if (!onTarget)
            {
                t += Time.deltaTime;
                transform.position = Vector2.Lerp(startPos, targetPosition, t / moveTimeSpeed);
                if (t >= 1)
                {
                    transform.position = targetPosition;
                    onTarget = true;
                    t = 0;
                }
            }
        }
    }
}