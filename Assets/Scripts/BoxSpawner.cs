using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject box_Prefab;

    public void SpawnBox()
    {
        GameObject box_obj = Instantiate(box_Prefab);

        Vector3 temp = transform.position;
        temp.z = 0;
        box_obj.transform.position = temp;
    }
}
