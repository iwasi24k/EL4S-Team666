
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static bool m_hasFadeCanvasFlag = false;//Canvas召喚フラグ

    private bool m_fadeInFlag = false;//フェードインするフラグ
    private bool m_fadeOutFlag = false;//フェードアウトするフラグ

    private float m_fadeAlpha = 0.0f;//透過率

    [Header("▼フェードの時間")]
    [SerializeField]public float m_fadeTime = 0.5f;//フェードに掛かる時間

    void Start()
    {
        if (!m_hasFadeCanvasFlag)//起動時
        {
            DontDestroyOnLoad(this);
            m_hasFadeCanvasFlag = true;
        }
        else//起動時以外は重複しないようにする
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if (m_fadeInFlag)
        {
            m_fadeAlpha -= Time.deltaTime / m_fadeTime;

            if (m_fadeAlpha <= 0.0f)//透明になったら、フェードインを終了
            {
                m_fadeInFlag = false;
                m_fadeAlpha = 0.0f;
            }

            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, m_fadeAlpha);
        }
        else if (m_fadeOutFlag)
        {
            m_fadeAlpha += Time.deltaTime / m_fadeTime;

            if (m_fadeAlpha >= 1.0f)//真っ黒になったら、フェードアウトを終了
            {
                m_fadeOutFlag = false;
                m_fadeAlpha = 1.0f;
            }

            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, m_fadeAlpha);
        }
    }

    //フェードイン
    public void FadeIn()
    {
        m_fadeInFlag = true;
        m_fadeOutFlag = false;
    }

    //フェードアウト
    public void FadeOut()
    {
        m_fadeOutFlag = true;
        m_fadeInFlag = false;
    }
}
