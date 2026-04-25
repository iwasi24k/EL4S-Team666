using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SlotTexture : MonoBehaviour
{
    [SerializeField] public List<Image> images;

    [SerializeField] public List<Image> tgt;
    [SerializeField] public List<Image> sym;
    //[SerializeField] public List<Image> ;

    [SerializeField]
    private SlotData slotData;
    private void Update()
    {
        Texture(slotData);
    }
        

    void Texture(SlotData data)
    {
    }



}
