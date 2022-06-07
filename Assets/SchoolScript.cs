using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SchoolScript : MonoBehaviour
{

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<VisualElement>("MiddelbaarHolder").RegisterCallback<MouseOverEvent>(OnHoverIcon);
        root.Q<VisualElement>("HogeschoolHolder").RegisterCallback<MouseOverEvent>(OnHoverIcon2);
    }

    void OnHoverIcon(MouseOverEvent type)
    {

    }

    void OnHoverIcon2(MouseOverEvent type)
    {

    }
}
