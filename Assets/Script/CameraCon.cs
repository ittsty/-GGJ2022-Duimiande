using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    [SerializeField] GameObject target; 

    void Update()
    {
        this.gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -20);
    }
}
