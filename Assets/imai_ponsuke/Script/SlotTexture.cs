using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SlotTexture : MonoBehaviour
{
    [SerializeField] public RectTransform content;
    [SerializeField] public GameObject imagePrefab;
    [SerializeField] public List<Image> images;

    [SerializeField]
    private int slotDataSize;

    public void Setup<T>(List<T> list,System.Func<T,Sprite> converter)
    {
        SyncImageCount(list.Count);

        for (int i = 0; i < images.Count; i++)
        {
            var value = list[i % list.Count];
            images[i].sprite = converter(value);
        }
    }

    private void SyncImageCount(int count)
    {
#if UNITY_EDITOR
        while (images.Count < count)
        {
            var obj = UnityEditor.PrefabUtility.InstantiatePrefab(imagePrefab, content) as GameObject;
            images.Add(obj.GetComponent<Image>());
        }

        while (images.Count > count)
        {
            var last = images[images.Count - 1];
            DestroyImmediate(last.gameObject);
            images.RemoveAt(images.Count - 1);
        }
#endif
    }
}
