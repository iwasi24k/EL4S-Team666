using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameClearManager : MonoBehaviour
{
    //シーンコントローラー
    SceneController m_sceneController;

    [Header("▼次のシーンの名前")]
    [SerializeField] private string m_nextSceneName;

    private GameObject m_timeScoreDataObject;
    private TimeScoreData m_timeScoreData;

    [Header("▼クリアタイムの表示テキスト")]
    [SerializeField] private Text m_clearTimeText;

    //分
    private int m_minute = 0;
    private float m_second = 0;

    void Start()
    {
        //シーンコントローラーを取得
        m_sceneController = GetComponent<SceneController>();

        m_timeScoreDataObject = GameObject.Find("TimeScoreData");
        m_timeScoreData = m_timeScoreDataObject.GetComponent<TimeScoreData>();

        m_minute = (int)(m_timeScoreData.GetTimeScore() / 60);
        m_second = m_timeScoreData.GetTimeScore() % 60;

        m_clearTimeText.text = "CLEAR TIME : " + m_minute.ToString("00") + ":" + m_second.ToString("00.00");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //シーン遷移
            m_sceneController.SceneChange(m_nextSceneName);
        }
    }
}
