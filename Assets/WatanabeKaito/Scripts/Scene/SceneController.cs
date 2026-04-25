using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [Header("▼フェードのキャンバス")]
    [SerializeField] private GameObject m_fadeCanvas;

    [Header("▼フェードのディレイ(フェードの時間(秒))")]
    [SerializeField] private float m_fadeDelayTime;

    void Start()
    {
        //フェードキャンバスがないときは生成する
        if (!FadeManager.m_hasFadeCanvasFlag)
        {
            Instantiate(m_fadeCanvas, new Vector3(0, 0, 0), Quaternion.identity);
        }

        //起動時用にCanvasの召喚をちょっと待つ
        Invoke("FindFadeObject", 0.02f);

        //フェードの時間をミリ秒に変換
        m_fadeDelayTime = m_fadeDelayTime * 1000;
    }

    void FindFadeObject()
    {
        //FadeCanvasをみつける
        m_fadeCanvas = GameObject.FindGameObjectWithTag("FADE");

        //フェードインフラグを立てる
        m_fadeCanvas.GetComponent<FadeManager>().FadeIn();
    }

    //シーン遷移
    public async void SceneChange(string sceneName)
    {
        //フェードアウトフラグを立てる
        m_fadeCanvas.GetComponent<FadeManager>().FadeOut();

        //暗転するまで待つ
        await Task.Delay((int)m_fadeDelayTime);

        //シーンチェンジ
        SceneManager.LoadScene(sceneName);
    }
}
