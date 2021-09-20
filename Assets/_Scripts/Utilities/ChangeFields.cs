using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeFields : MonoBehaviour
{
    [SerializeField] Selectable firstInput;
    EventSystem system;

    void Start()
    {
        system = EventSystem.current;
        firstInput.Select();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null)
            {
                next.Select();
            }
            else
            {
                firstInput.Select();
            }
        }
    }
}
