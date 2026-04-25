using UnityEngine;
using UnityEngine.InputSystem;

public class SlotRead : MonoBehaviour
{
    public enum target
    {
        Player,
        Enemy,
        Bullet,
    }

    target tgt;

    private PlayerStatusController plsts;
    private EnemyBaseParameter enpara;
    private Bullet blt;

    void ConnectSlot(float mul)
    {
        switch (tgt)
        {
            case target.Player:
                plsts = GetComponent<PlayerStatusController>();
                plsts.Speed *= mul;

                plsts.transform.localScale *= mul;
                plsts.Cooldown *= mul;
            
                break;

            case target.Enemy:
                enpara = GetComponent<EnemyBaseParameter>();
                EnemyManager mag = GetComponent<EnemyManager>();

                mag.SetMoveSpeed(enpara._MoveSpeed * mul);

                mag.SetHitBoxSize(enpara._HitBoxSize * mul);

                mag.SetAlpha(mul);

                mag.SetBulletInterval(enpara._BulletInterval * mul);

                mag.SetBulletSize(enpara._BulletSize * mul);
                break;
            case target.Bullet:
                blt = GetComponent<Bullet>();

                blt.speed *= mul;
                blt.transform.localScale *= mul;

                break;
        }

    }
}
