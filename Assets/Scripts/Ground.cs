using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [Header("Класс пола")]
    [Tooltip("Скорость движения текстуры наземного объекта, будто он движется")]
    public float groundTextureSpeed = -0.9f;
    internal Transform groundObject;

    void Awake()
    {
        groundObject = gameObject.GetComponent<Transform>();
    }
}
