using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TestRenderer : MonoBehaviour
{

    public Renderer m_Renderer;

    float m_R = 0.4f;
    float m_G = 0.5f;
    float m_B = 0.3f;
    float m_Alpha = 1f;

    void Start()
    {
        m_Renderer.material.color = new Color(m_R, m_G, m_B, m_Alpha);
    }

    void Update()
    {

    }
}