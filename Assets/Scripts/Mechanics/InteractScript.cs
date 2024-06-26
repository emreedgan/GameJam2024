using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractScript : MonoBehaviour
{
    public bool inRange;
    [SerializeField] UnityAction action;
    public KeyCode key;
    public TextMesh text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(key))
            {
                action.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Player")
        {
            inRange = true;
            Debug.Log("In");
            text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            inRange = false;
            Debug.Log("Out");
            text.gameObject.SetActive(false);
        }
    }
}
