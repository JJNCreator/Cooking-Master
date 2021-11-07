using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "vegetableMaterialsSO.asset", menuName = "Create Vegetable Materials Asset")]
public class VegetableMaterialsSO : ScriptableObject
{
    public Material spinachMaterial;
    public Material celeryMaterial;
    public Material lettuceMaterial;
    public Material carrotMaterial;
    public Material tomatoMaterial;
    public Material onionMaterial;

    public Material GetVegetableMaterial(string vegetableName)
    {
        //return value
        Material returnValue = spinachMaterial;
        //switch case
        switch(vegetableName)
        {
            case "Spinach":
                returnValue = spinachMaterial;
                break;
            case "Celery":
                returnValue = celeryMaterial;
                break;
            case "Lettuce":
                returnValue = lettuceMaterial;
                break;
            case "Carrot":
                returnValue = carrotMaterial;
                break;
            case "Tomato":
                returnValue = tomatoMaterial;
                break;
            case "Onion":
                returnValue = onionMaterial;
                break;
        }
        //return material value
        return returnValue;
    }
}
