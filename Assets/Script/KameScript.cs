using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class KameScript : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float timeInScreen;
    public GlobalMovement gokuMoveOwner;
    private GlobalMovement enemyGlobalM;
    public Animator animPlayer;
    public void ScribFather(GlobalMovement global,Animator anim, GlobalMovement enemyGM)
    {
        gokuMoveOwner = global;
        animPlayer = anim;
        enemyGlobalM = enemyGM;

    }
    void Update()
    {
        GameObject.Destroy(gameObject,timeInScreen);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") && gokuMoveOwner.player1 != collision.gameObject.GetComponent<GlobalMovement>().player1)
        {
            if (collision.gameObject.GetComponent<GlobalMovement>().isInDefence)
            {
                collision.gameObject.GetComponent<HealthManager>().DamageTake(damage*0.1f);
                collision.gameObject.GetComponent<GlobalMovement>().Ondefence = true;
            }
            else
            {
                collision.gameObject.GetComponent<HealthManager>().DamageTake(damage);
                collision.gameObject.GetComponent<GlobalMovement>().paralyzed = true;
            }
        }
    }

    private void OnDestroy()
    {
        gokuMoveOwner.standing = false;
        animPlayer.SetInteger("Punch", 0);
        enemyGlobalM.Ondefence = false;
    }
}
