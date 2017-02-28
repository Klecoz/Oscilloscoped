using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowards : MonoBehaviour {

    Vector3 target = new Vector3(0, 0, 0);
    public float speed;
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        transform.Rotate(Vector3.right * Time.deltaTime * 100);
    }

}
