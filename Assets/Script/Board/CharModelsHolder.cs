using Assets.Script.Enums;
using UnityEngine;

public class CharModelsHolder : MonoBehaviour
{
    [SerializeField] GameObject[] chars3dModels;



    public GameObject GetCharByReference(EnumPlayerReference playerReference)
    {
        foreach (GameObject character in chars3dModels)
        {
            if (character.GetComponent<Player>().GetPlayerReference() == playerReference)
            {
                return character;
            }
        }

        Debug.LogError("Nenhuma refer�ncia encontrada!");
        return null;
    }


}
