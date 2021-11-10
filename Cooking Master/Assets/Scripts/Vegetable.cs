using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public enum VegetableType
    {
        Spinach,
        Celery,
        Lettuce,
        Carrot,
        Tomato,
        Onion
    }
    //reference for vegetable type
    public VegetableType type;
}
