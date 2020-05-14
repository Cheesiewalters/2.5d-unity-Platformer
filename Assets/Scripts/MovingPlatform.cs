using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    [SerializeField]
    private float _speed = 2.0f;
    private bool _reachedPointB = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if( _reachedPointB == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, Time.deltaTime * _speed);
            if(transform.position == _targetB.position)
            {
             _reachedPointB = true;
            }
        }

        if(_reachedPointB == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, Time.deltaTime * _speed);
            if(transform.position == _targetA.position)
            {
                _reachedPointB = false;
            }
        }

    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Player")
        {
           other.transform.parent = this.transform;
        }
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        if(other.transform.name == "Player")
        {
            other.transform.parent = null;
        }
    }
}
