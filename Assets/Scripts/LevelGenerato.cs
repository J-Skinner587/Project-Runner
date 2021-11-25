using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerato : MonoBehaviour
{
    [SerializeField] private Transform levelPart_1;

    private void awake()
    {
        Instantiate(levelPart_1, new Vector3(38, 4, -83), Quaternion.identity);
    }

}

