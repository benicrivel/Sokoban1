using UnityEngine;

public static class ArrayMath
{
    public static GameObject[] AddGameObjects(GameObject[] List, GameObject[] ListToAdd)
    {
        GameObject[] aux = new GameObject[List.Length + ListToAdd.Length];

        for(int i = 0; i < aux.Length; i++)
        {
            if(i < List.Length)
            {
                aux[i] = List[i];
            }
            else
            {
                aux[i] = ListToAdd[i - List.Length];
            }
        }

        return aux;
    }

    public static GameObject[] AddGameObject(GameObject[] List, GameObject GameObjectToAdd)
    {
        GameObject[] aux = new GameObject[List.Length + 1];

        for(int i = 0; i < (aux.Length - 1); i++)
        {
            aux[i] = List[i];
        }

        aux[aux.Length - 1] = GameObjectToAdd;
        
        return aux;
    }
}
