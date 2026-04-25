using Unity.VisualScripting;
using UnityEngine;

public class SlotPlay : MonoBehaviour
{
    [SerializeField] private SlotData data;

    private int[] SlotIdNum = new int[3] { 0, 0, 0 };
    private bool[] SlotPlayFlg = new bool[3] { false, false, false };

    public enum SlotState
    {
        Idle,
        Spinnig,
        Stop1,
        Stop2,
        Stop3,
        Result,
    }
    SlotState state;

    public void PlaySlot()
    {
        for (int i = 0; i < 3; i++)
        {
            SlotPlayFlg[i] = true;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressd();
        }
    }
    // スペース押された時の効果
    void OnSpacePressd()
    {
        switch (state)
        {
            case SlotState.Idle:
                Spin();
                state = SlotState.Spinnig;
                break;
            case SlotState.Spinnig:

                Spin();

                StopReel(0);
                state = SlotState.Stop1;
                break;
            case SlotState.Stop1:
                Spin();
                StopReel(1);
                state = SlotState.Stop2;
                break;
            case SlotState.Stop2:
                StopReel(2);
                state = SlotState.Stop3;
                break;
            case SlotState.Stop3:
                state = SlotState.Idle;
                break;
        }
    }

    void Spin()
    {
        for (int i = 0; i < 3; i++)
        {
            if (SlotPlayFlg[i])
            {
                SlotIdNum[i]++;
            }
        }

        if (SlotIdNum[0] >= data.SlotTargets.Count)
        {
            SlotIdNum[0] %= data.SlotTargets.Count;
        }

        if (SlotIdNum[1] >= data.SlotSymbols.Count)
        {
            SlotIdNum[1] %= data.SlotSymbols.Count;
        }

        if (SlotIdNum[2] >= data.ParameterMult.Count)
        {
            SlotIdNum[2] %= data.ParameterMult.Count;
        }
    }

    void StopReel(int reelnum)
    {
        SlotPlayFlg[reelnum] = false;
    }
}
