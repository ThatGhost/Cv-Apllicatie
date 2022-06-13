using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErvaringHandler : MonoBehaviour
{
    [SerializeField] List<ErvaringButtonScr> buttons;

    public void CloseAll()
    {
        foreach(ErvaringButtonScr b in buttons)
        {
            b.Close();
        }
    }
}
