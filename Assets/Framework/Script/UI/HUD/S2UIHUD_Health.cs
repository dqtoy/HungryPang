/*�ǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢ�

�� ������ �� �̻�ȣ
�� ������ �� 2015�� 09�� 19��
�� E-Mail �� shmhlove@naver.com
�� Desc   �� �� Ŭ������ HUD Health UI�� �����մϴ�.

�ǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢ�*/
using UnityEngine;
using System.Collections;

public class S2UIHUD_Health : MonoBehaviour
{
    // ������Ʈ
    public UISlider              m_pHealth       = null;
    public UISprite              m_pThumb        = null;
    
    // ���
    public float                 m_fLerpSpeed    = 0.001f;

    // FollowTarget
    private S2UIHUD_FollowTarget m_pFollowTarget = null;

    // ��Ÿ
    private float   m_fPercent  = 0.0f;
    private bool    m_bIsActive = false;
    private float   m_fLerp     = 0.0f;

    // �ý��� : ������Ʈ ������ �����Ҷ�
    void Start()
    {
        SetActive(false);
    }

    // �ý��� : ������Ʈ
    void Update()
    {
        if (null == m_pHealth)
            return;

        if (m_pHealth.value == m_fPercent)
        {
            m_fLerp = 0.0f;
            if (null != m_pThumb)
                m_pThumb.enabled = false;
            return;
        }

        m_fLerp += m_fLerpSpeed * (0.5f + Mathf.Abs(m_pHealth.value - m_fPercent));
        m_pHealth.value = Mathf.Lerp(m_pHealth.value, m_fPercent, m_fLerp);

        if (null != m_pThumb)
            m_pThumb.enabled = true;
    }

    // �������̽� : Ȱ��ȭ
    public void SetActive(bool bIsActive)
    {
        gameObject.SetActive(m_bIsActive = bIsActive);
    }

    // �������̽� : FollowTarget����
    public void SetFollowTarget(Transform pTransform)
    {
        if (null == m_pFollowTarget)
            m_pFollowTarget = gameObject.AddComponent<S2UIHUD_FollowTarget>();

        Vector3 vLocalScale = transform.localScale;
        if (null != m_pHealth.backgroundWidget)
            vLocalScale = S2Math.MulToVector(m_pHealth.backgroundWidget.localSize, transform.localScale);

        m_pFollowTarget.SetTarget(pTransform, -vLocalScale.x * 0.5f, -vLocalScale.y);
    }

    // �������̽� : ������ ������Ʈ
    public void SetPercent(float fPercent)
    {   
        m_fPercent = fPercent;
    }
}