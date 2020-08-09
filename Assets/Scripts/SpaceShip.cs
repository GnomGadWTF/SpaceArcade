using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace SpaceArcade
{
    public class SpaceShip : MonoBehaviour
    {   
        internal Transform thisTransform;
        static GameController gameController;
        

        void Start()
        {
            thisTransform = this.transform;
            if (gameController == null) gameController = GameObject.FindObjectOfType<GameController>();
        }

        void FixedUpdate()
        {
            //thisTransform.Translate(Vector3.right * Time.deltaTime * 15f, Space.Self);
        }
    }
}