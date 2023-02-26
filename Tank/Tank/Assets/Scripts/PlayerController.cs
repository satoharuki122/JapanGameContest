using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_player = null;
    [SerializeField]
    private GameObject m_shield = null;
    [SerializeField]
    private GameObject m_bullet = null;
    InputAction m_moveShieldAction;
    InputAction m_shotBullet;
    Vector2 m_axis = Vector2.zero;
    float m_angle = 0.0f;
    [SerializeField]
    float m_radius = 3.0f;
    [SerializeField]
    float m_shotTime = 5.0f;
    float m_nowTime = 0.0f;
    Vector2 m_shotDir = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        var actionMap = GetComponent<PlayerInput>().currentActionMap;
        m_moveShieldAction = actionMap["MOVE_SHIELD"];
        m_shotBullet = actionMap["SHOT_BULLET"];
    }

    // Update is called once per frame
    void Update()
    {
        if (m_moveShieldAction.triggered)
        {
            m_axis = m_moveShieldAction.ReadValue<Vector2>();
            m_angle = Mathf.Atan2(m_axis.x, m_axis.y) * Mathf.Rad2Deg;
            Debug.Log(m_angle);
            Vector3 angle = m_shield.transform.eulerAngles;
            angle.y = m_angle;
            m_shield.transform.eulerAngles = angle;
            m_shield.transform.position = new Vector3(Mathf.Sin(m_angle*Mathf.Deg2Rad), 0.0f, Mathf.Cos(m_angle*Mathf.Deg2Rad)) * m_radius;
        }
        m_nowTime += Time.deltaTime;
        if ( m_nowTime>= m_shotTime)
        {
            m_nowTime = 0.0f;
            Vector2 dir = m_shotBullet.ReadValue<Vector2>();
            if (dir == Vector2.zero)
            {
                dir = m_shotDir;
            }
            GameObject bullet = Instantiate(m_bullet);
            bullet.GetComponent<BulletController>().Direction = dir.normalized;
        }

    }
}
