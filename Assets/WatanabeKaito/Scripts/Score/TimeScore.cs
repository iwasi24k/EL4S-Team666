using UnityEngine;

public class TimeScore : MonoBehaviour
{
   private TimeScoreData m_timeScoreData;

    public float m_timeScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_timeScore = 0;

        m_timeScoreData = GameObject.Find("TimeScoreData").GetComponent<TimeScoreData>();
    }

    // Update is called once per frame
    void Update()
    {
        m_timeScore += Time.deltaTime;

        m_timeScoreData .SetTimeScore(m_timeScore);
    }

    public float GetTimeScore()
    {
        return m_timeScore;
    }
}
