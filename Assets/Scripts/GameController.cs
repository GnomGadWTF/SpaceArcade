using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceArcade
{
    public class GameController : MonoBehaviour
    {
        [Header("Граунд")]
        [Tooltip("объект пола")]
        public Ground groundObject;
        //Стартовое положение в координатах
        float positionX = 0.0f; 

        [Header("Игрок")]
        [Tooltip("Объект корабля игрока")]
        public SpaceShip playerObject;


        [Header("Канвасы")]
        [Tooltip("Игровое меню")]
        public Canvas menuCanvas;
        [Tooltip("Сама игра")]
        public Canvas gameCanvas;

        private void Awake()
        {
           // if (gameCanvas) Instantiate(playerObject);
        }

        void FixedUpdate(){
           positionX += 0.1f;
        }

        void LateUpdate()
        {
            if (groundObject)
            {
                //При наличии гроунда и материала - хуевертить его
                groundObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(positionX, 5) * groundObject.groundTextureSpeed);
            }

        }
    }
}