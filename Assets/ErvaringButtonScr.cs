using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErvaringButtonScr : MonoBehaviour
{
    [SerializeField]private float m_Size = 1600;
    [SerializeField]private float m_Up = 150;

    [SerializeField]private float m_SizeSpeed = 2; //in sec
    [SerializeField]private float m_UpSpeed = 1;

    ErvaringHandler m_Handler;

    private Vector2 m_StartSize;
    private float m_Timer = 0;

    private bool m_Running = false;
    private bool m_IsBig = false;
    private bool m_IsUp = false;
    private bool m_Open = false;

    public RectTransform Button;
    public RectTransform Text;

    private void Start()
    {
        m_StartSize = Button.sizeDelta;
        m_Handler = transform.parent.GetComponent<ErvaringHandler>();
    }

    private void Update()
    {
        if(m_Running)
        {
            if(!m_Open)
                Opening();
            else
                Closing();
        }
    }

    public void OnButton()
    {
        if (m_Running)
            return;

        m_Handler.CloseAll();
        Open();
    }

    public void Close()
    {
        if (m_Running && m_Open)
            return;

        if(m_Running) //in animation
        {
            m_Open = true;

            if(m_IsBig) //going up
            {
                m_IsUp = true;
                m_Timer = m_UpSpeed - m_Timer;
            }
            else //getting bigger
            {
                m_IsBig = true;
                m_Timer = m_SizeSpeed - m_Timer;
            }
        }

        if(m_Open)
            m_Running = true;
    }

    public void Open()
    {
        m_Running = true;
    }

    private void Opening()
    {
        if (m_Open)
            return;

        if (!m_IsBig) //first stage
        {
            if (m_Timer < m_SizeSpeed)
            {
                Vector2 size = new Vector2();
                size.x = m_StartSize.x + m_Size * (m_Timer / m_SizeSpeed);
                size.y = m_StartSize.y;
                Button.sizeDelta = size;
                Text.sizeDelta = size;
                m_Timer += Time.deltaTime;
            }
            else
            {
                m_Timer = 0;
                m_IsBig = true;
                Text.gameObject.SetActive(true);
            }
            return;
        }
        if (!m_IsUp) //second stage
        {
            if (m_Timer < m_UpSpeed)
            {
                Vector2 pos = new Vector2();
                pos.y = m_Up * (m_Timer / m_UpSpeed);
                pos.x = Button.localPosition.x;
                Button.localPosition = pos;
                m_Timer += Time.deltaTime;
            }
            else
            {
                m_Timer = 0;
                m_IsUp = true;
                m_Open = true;
                m_Running = false;
            }
            return;
        }
    }
    private void Closing()
    {
        if (m_IsUp) //first stage - going down
        {
            if (m_Timer < m_UpSpeed)
            {
                Vector2 pos = new Vector2();
                pos.y = m_Up - m_Up * (m_Timer / m_UpSpeed);
                pos.x = Button.localPosition.x;
                Button.localPosition = pos;
                m_Timer += Time.deltaTime;
            }
            else
            {
                m_Timer = 0;
                m_IsUp = false;
                Text.gameObject.SetActive(false);
            }
            return;
        }
        if (m_IsBig) //second stage - getting smaller
        {
            if (m_Timer < m_SizeSpeed)
            {
                Vector2 size = new Vector2();
                size.x = m_StartSize.x + (m_Size - m_Size * (m_Timer / m_SizeSpeed));
                size.y = m_StartSize.y;
                Button.sizeDelta = size;
                Text.sizeDelta = size;
                m_Timer += Time.deltaTime;
            }
            else
            {
                m_Timer = 0;
                m_IsBig = false;
                m_Open = false;
                m_Running = false;
            }
            return;
        }
    }
}
