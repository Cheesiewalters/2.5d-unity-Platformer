using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private GameObject _respawnPoint;
    [SerializeField]
    private UIManager _uiManager;
    void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.Damage();
            CharacterController _cc = other.GetComponent<CharacterController>();
            if(_cc != null)
            {
                _cc.enabled = false;
                StartCoroutine(restartCC(_cc));
            }
            other.transform.position = _respawnPoint.transform.position;
        }
    }

    IEnumerator restartCC(CharacterController _cc) {
        yield return new WaitForSeconds(0.5f);
        _cc.enabled = true;
    }
}
