using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float m_speed = 5.0f;
    private Vector2 m_direction;
    public Vector2 Direction 
    {
        get { return m_direction; }
        set { m_direction = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(m_direction.x, 0.0f, m_direction.y) * m_speed;
    }
}
