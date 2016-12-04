/*�ǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢ�

�� ������ �� �̻�ȣ
�� ������ �� 2015�� 09�� 19��
�� E-Mail �� shmhlove@naver.com
�� Desc   �� �� Ŭ������ HUD UI�� �����մϴ�.

�ǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢǢ�*/
using UnityEngine;
using System.Collections;

public enum eHUDType
{
    HealthGauge,
}

public class S2UIHUD : MonoBehaviour
{
    // HUD ������Ʈ
    public S2UIHUD_Health m_pHealth = null;

    // ���� ��ġ ������Ʈ
    private Transform m_pTop     = null;
    private Transform m_pBottom  = null;

    // ��Ÿ
    private bool     m_bIsActive = false;

    // �ý��� : ����
    void Start()
    {
        transform.localPosition = Vector3.zero;
        transform.localScale    = new Vector3(1.0f, 1.0f, 1.0f);
    }

    // �������̽� : �ʱ�ȭ
    public void Initialize(Transform pTop, Transform pBottom)
    {
        m_pTop      = pTop;
        m_pBottom   = pBottom;

        if (null != m_pHealth)
            m_pHealth.SetFollowTarget(m_pTop);

        SetActive(false);
    }

    // �������̽� : ����
    public void Destroy()
    {
        S2GameEngineSGT.DestroyObject(gameObject);
    }

    // �������̽� : Active On/Off
    public void SetActive(bool bIsActive)
    {
        gameObject.SetActive(m_bIsActive = bIsActive);
    }
    public void SetActive(eHUDType eType, bool bIsActive)
    {
        if (true == bIsActive)
        {
            SetActive(bIsActive);
        }

        switch (eType)
        {
            case eHUDType.HealthGauge: SetActiveToHealth(bIsActive); break;
        }
    }
    void SetActiveToHealth(bool bIsActive)
    {
        if (null == m_pHealth)
            return;

        m_pHealth.SetActive(bIsActive);
    }

    // �������̽� : Health������ ������Ʈ
    public void SetHealthGauge(float fPercent)
    {
        if (null == m_pHealth)
            return;

        m_pHealth.SetPercent(fPercent);
    }
}