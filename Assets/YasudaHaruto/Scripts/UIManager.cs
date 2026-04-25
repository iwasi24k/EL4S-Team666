//-----------------------------------------------
// UIManager.cs
// UIを管理するスクリプト
//-----------------------------------------------
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text m_timeText;       // タイムを表示するテキスト

    [SerializeField] private Image m_hpRoot;        // HPを表示するイメージのルート
    [SerializeField] private int m_maxHp = 15;          // 最大HP
    [SerializeField] private int m_hpImageXInterval = 20; // HPアイコンのX方向の間隔
    [SerializeField] private int m_hpImageYInterval = 10;  // HPアイコンのY方向の間隔

    [SerializeField] private Image m_flashImage;     // フラッシュイメージ
    [SerializeField] private float m_flashAlpha = 0.5f;     // フラッシュのアルファ値
    [SerializeField] private float m_fadeTime = 0.5f;          // フェードの時間

    private int m_hp = 0;
    private List<Image> m_hpImages = new List<Image>();    // HPを表示するイメージのリスト

    private Coroutine m_flashCoroutine; // フラッシュのコルーチン

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_hpImages.Add(m_hpRoot);
        m_hp = 1; // 初期HPを1に設定

        SetTime(0); // タイムを初期化

        SetAlpha(0); // フラッシュイメージのアルファを0に設定
    }


    public void SetTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = (time * 1000) % 1000;

        m_timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    public void AddHp(int value = 1)
    {
        if (m_hp >= m_maxHp)
        {
            return; // HPが最大値に達している場合は追加しない
        }

        m_hp += value;
        if (m_hp > m_maxHp)
        {
            m_hp = m_maxHp;
        }

        for (int i = m_hpImages.Count; i < m_hp; i++)
        {
            CreateHpImage();
        }
    }

    public void SetHp(int hp)
    {
        if (hp < 0)
        {
            hp = 0;
        }
        else if (hp > m_maxHp)
        {
            hp = m_maxHp;
        }
        while (m_hp < hp)
        {
            AddHp();
        }
        while (m_hp > hp)
        {
            RemoveHp();
        }
    }

    private void CreateHpImage()
    {
        Image newHpImage = Instantiate(m_hpRoot, m_hpRoot.transform.parent);
        newHpImage.name = "HpImage_" + m_hp; // HPイメージの名前を設定
        newHpImage.transform.localPosition += new Vector3((m_hp - 1) % 5 * m_hpImageXInterval, -(m_hp - 1) / 5 * m_hpImageYInterval, 0); // HPアイコンを横に並べる
        m_hpImages.Add(newHpImage);
    }

    public void RemoveHp(int value = 1)
    {
        if (m_hp <= 0)
        {
            return; // HPが0以下の場合は削除しない
        }

        m_hp -= value;
        Flash(); // HPが減るときにフラッシュする

        if (m_hp < 0)
        {
            m_hp = 0;
        }
        if (m_hpImages.Count > 1)
        {
            Image lastHpImage = m_hpImages[m_hpImages.Count - 1];
            m_hpImages.RemoveAt(m_hpImages.Count - 1);
            Destroy(lastHpImage.gameObject);
        }
    }

    private void Flash()
    {
        if (m_flashCoroutine != null)
        {
            StopCoroutine(m_flashCoroutine);
        }
        m_flashCoroutine = StartCoroutine(FlashCoroutine());
    }

    private System.Collections.IEnumerator FlashCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < m_fadeTime)
        {
            float alpha = Mathf.Lerp(m_flashAlpha, 0, elapsedTime / m_fadeTime);
            SetAlpha(alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SetAlpha(0); // フラッシュイメージのアルファを0に設定
    }

    private void SetAlpha(float alpha)
    {
        Color color = m_flashImage.color;
        color.a = alpha;
        m_flashImage.color = color;
    }
}
