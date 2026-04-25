using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    [SerializeField] private List<Image> m_leftReel;
    [SerializeField] private List<Image> m_centerReel;
    [SerializeField] private List<Image> m_rightReel;

    [SerializeField] private Image m_topImage;
    [SerializeField] private Image m_bottomImage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var image in m_leftReel)
        {
            image.rectTransform.position -= new Vector3(0, 1, 0) * Time.deltaTime * 100; // ‰æ‘œ‚ð‰º‚ÉˆÚ“®
            if (image.rectTransform.position.y <= m_bottomImage.rectTransform.position.y)
            {
                Vector3 pos = image.rectTransform.position;
                image.rectTransform.position = new Vector3(pos.x, m_topImage.rectTransform.position.y, pos.z);
            }
        }

        foreach (var image in m_centerReel)
        {
            image.rectTransform.position -= new Vector3(0, 1, 0) * Time.deltaTime * 100; // ‰æ‘œ‚ð‰º‚ÉˆÚ“®
            if (image.rectTransform.position.y <= m_bottomImage.rectTransform.position.y)
            {
                Vector3 pos = image.rectTransform.position;
                image.rectTransform.position = new Vector3(pos.x, m_topImage.rectTransform.position.y, pos.z);
            }
        }

        foreach (var image in m_rightReel)
        {
            image.rectTransform.position -= new Vector3(0, 1, 0) * Time.deltaTime * 100; // ‰æ‘œ‚ð‰º‚ÉˆÚ“®
            if (image.rectTransform.position.y <= m_bottomImage.rectTransform.position.y)
            {
                Vector3 pos = image.rectTransform.position;
                image.rectTransform.position = new Vector3(pos.x, m_topImage.rectTransform.position.y, pos.z);
            }
        }
    }
}
