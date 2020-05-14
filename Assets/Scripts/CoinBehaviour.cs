using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    [SerializeField]
    private UIManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Player")
        {
            _uiManager.UpdateCoinDisplay(10);
            Destroy(this.gameObject);
        }
    }
}
