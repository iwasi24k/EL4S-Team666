using UnityEngine;

public class TitleManager : MonoBehaviour
{
    //シーンコントローラー
    SceneController m_sceneController;

    [Header("▼次のシーンの名前")]
    [SerializeField] private string m_nextSceneName;

    void Start()
    {
        //シーンコントローラーを取得
        m_sceneController = GetComponent<SceneController>(); 
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
