using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    private float _collisionTime = 0f;

    private bool _givenDamage = false;

	void OnCollisionEnter(Collision collision)
    {
        forcePush fp = collision.collider.GetComponent<forcePush>();
        if(fp != null)
        {
            _collisionTime = Time.time;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (_givenDamage)
            return;

        forcePush fp = collision.collider.GetComponent<forcePush>();
        if (fp != null)
        {
            if(Time.time - _collisionTime > 1f)
            {
                fp.TakeDamage(1);
                _givenDamage = true;
            }
        }
    }
}
