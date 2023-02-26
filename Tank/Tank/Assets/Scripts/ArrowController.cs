using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_arrow = null;
    [SerializeField]
    private GameObject m_player = null;
    InputAction m_shotBullet;
    Vector2 m_axis = Vector2.zero;
    float m_angle = 0.0f;
    [SerializeField]
    float m_radius = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        var actionMap = m_player.GetComponent<PlayerInput>().currentActionMap;
        m_shotBullet = actionMap["SHOT_BULLET"];
    }

    // Update is called once per frame
    void Update()
    {
        if (m_shotBullet.triggered)
        {
            m_axis = m_shotBullet.ReadValue<Vector2>();
            m_angle = Mathf.Atan2(m_axis.y, m_axis.x) * Mathf.Rad2Deg;
            Debug.Log(m_angle);
            Vector3 angle = m_arrow.transform.eulerAngles;
            angle.z = m_angle - 90.0f;
            m_arrow.transform.eulerAngles = angle;
            Vector3 pos = new Vector3(Mathf.Cos(m_angle * Mathf.Deg2Rad), 0.0f, Mathf.Sin(m_angle * Mathf.Deg2Rad)) * m_radius;
            m_arrow.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(pos);
        }
    }
}
