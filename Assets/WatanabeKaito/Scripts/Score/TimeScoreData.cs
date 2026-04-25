using UnityEngine;

public class TimeScoreData : MonoBehaviour
{
    public float m_timeScore = 0;

    static bool m_hasTimeScoreDataFlag = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!m_hasTimeScoreDataFlag)//起動時
        {
            DontDestroyOnLoad(this);
            m_hasTimeScoreDataFlag = true;
        }
        else//起動時以外は重複しないようにする
        {
            Destroy(this);
        }
        m_timeScore = 0;
    }

    public void SetTimeScore(float timeScore)
    {
        m_timeScore = timeScore;
    }

    public float GetTimeScore()
    {
        return m_timeScore;
    }
}
