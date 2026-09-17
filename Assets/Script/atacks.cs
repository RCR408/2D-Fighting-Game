using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class atacks : MonoBehaviour
{
    private GlobalMovement GMscript;
    [SerializeField] private Animator animatorController;
    [SerializeField] private float[] cooldownPunches;
    [SerializeField] private float[] startCooldownPunches; 

    [SerializeField] private Vector2[] boxColliederRange;
    [SerializeField] private Transform[] boxColliderPoint;
    [SerializeField] private GlobalMovement EnemyGM;
    public LayerMask playerLayerMask;

    [SerializeField] private float[] damages;
    
    // Input Motion

    public static List<int> dirBuffer = new List<int>();
    public static List<int> dirBuffer2 = new List<int>();
    private int horiz, vert, dpad = 0;
    private int horiz2, vert2, dpad2 = 0;

    //Special attacks

    InputMotionClass kamehame = new InputMotionClass("Kamehameha").Add(2, 60, true).Add(6, 60, true);
    public GameObject kameObject;
    public Transform kameTrans;

    //paralis

    [SerializeField] private float extraParalizedTime;

    // alive

    private HealthManager healthScript;

    void Start()
    {
        GMscript = GetComponent<GlobalMovement>();
        animatorController = GetComponent<Animator>();
        healthScript = GetComponent<HealthManager>();

        for (int i = 0; i < cooldownPunches.Length; i++)
        {
            startCooldownPunches[i] = cooldownPunches[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript.alive)
        {
            //cooldown
            for (int i = 0; i < cooldownPunches.Length; i++)
            {
                cooldownPunches[i] -= Time.deltaTime;
            }
            //Animation
            Punches(cooldownPunches, startCooldownPunches);
            kamehame.Mirror(GMscript.mirrorFacing);
            InputMotion(GMscript.player1);
        }
        else
        {
            animatorController.SetBool("DeadNigga",true);
        }
    }

    private void Punches(float[] cooldown, float[] startCoolDown)
    {
        if (GMscript.paralyzed == false)
        {
            if (GMscript.player1 == true)
            {
                if (Input.GetKeyDown(KeyCode.F) && cooldown[0] <= 0)
                {
                    animatorController.SetInteger("Punch", 1);
                    cooldown[0] = startCoolDown[0];
                    Collider2D[] hitConfirm = Physics2D.OverlapBoxAll(boxColliderPoint[0].position, boxColliederRange[0], playerLayerMask);

                    foreach (Collider2D col in hitConfirm)
                    {
                        HealthManager live = col.gameObject.GetComponent<HealthManager>();
                        GlobalMovement enemyPlayer = col.gameObject.GetComponent<GlobalMovement>();

                        if (GMscript.player1 != enemyPlayer.player1)
                        {
                            if (!enemyPlayer.isInDefence)
                            {
                                live.DamageTake(damages[0]);
                                enemyPlayer.paralyzed = true;
                                if (enemyPlayer.paralyzedTimer < enemyPlayer.paralyzedTime && enemyPlayer.paralyzedTimer > 0)
                                {
                                    enemyPlayer.paralyzedTimer += extraParalizedTime;
                                }
                            }
                            else
                            {
                                live.DamageTake(damages[0] * 0.2f);
                                enemyPlayer.Ondefence = true;
                            }
                        }
                    }
                }
                else if (Input.GetKeyDown(KeyCode.T) && cooldown[1] <= 0)
                {

                    if (kamehame.checkValidInput())
                    {
                        if (GMscript.standing == false)
                        {
                            Debug.Log(kamehame.name + "!!");
                            animatorController.SetInteger("Punch", 5);
                            GMscript.standing = true;
                        }
                    }
                    else
                    {
                        animatorController.SetInteger("Punch", 2);
                        cooldown[1] = startCoolDown[1];
                        Collider2D[] hitConfirm = Physics2D.OverlapBoxAll(boxColliderPoint[1].position, boxColliederRange[1], playerLayerMask);

                        foreach (Collider2D col in hitConfirm)
                        {
                            HealthManager live = col.gameObject.GetComponent<HealthManager>();
                            GlobalMovement enemyPlayer = col.gameObject.GetComponent<GlobalMovement>();

                            if (GMscript.player1 != enemyPlayer.player1)
                            {
                                if (!enemyPlayer.isInDefence)
                                {
                                    live.DamageTake(damages[1]);
                                    enemyPlayer.paralyzed = true;
                                    if (enemyPlayer.paralyzedTimer < enemyPlayer.paralyzedTime && enemyPlayer.paralyzedTimer > 0)
                                    {
                                        enemyPlayer.paralyzedTimer += extraParalizedTime;
                                    }
                                }
                                else
                                {
                                    live.DamageTake(damages[1] * 0.2f);
                                    enemyPlayer.Ondefence = true;
                                }
                            }
                        }
                    }
                }

                else if (Input.GetKeyDown(KeyCode.G) && cooldown[2] <= 0)
                {
                    animatorController.SetInteger("Punch", 3);
                    cooldown[2] = startCoolDown[2];
                    Collider2D[] hitConfirm = Physics2D.OverlapBoxAll(boxColliderPoint[2].position, boxColliederRange[2], playerLayerMask);

                    foreach (Collider2D col in hitConfirm)
                    {
                        HealthManager live = col.gameObject.GetComponent<HealthManager>();
                        GlobalMovement enemyPlayer = col.gameObject.GetComponent<GlobalMovement>();

                        if (GMscript.player1 != enemyPlayer.player1)
                        {
                            if (!enemyPlayer.isInDefence)
                            {
                                live.DamageTake(damages[2]);
                                enemyPlayer.paralyzed = true;
                                if (enemyPlayer.paralyzedTimer < enemyPlayer.paralyzedTime && enemyPlayer.paralyzedTimer > 0)
                                {
                                    enemyPlayer.paralyzedTimer += extraParalizedTime;
                                }
                            }
                            else
                            {
                                live.DamageTake(damages[2] * 0.2f);
                                enemyPlayer.Ondefence = true;
                            }
                        }
                    }

                }
                else if (Input.GetKeyDown(KeyCode.H) && cooldown[3] <= 0)
                {
                    animatorController.SetInteger("Punch", 4);
                    cooldown[3] = startCoolDown[3];
                    Collider2D[] hitConfirm = Physics2D.OverlapBoxAll(boxColliderPoint[3].position, boxColliederRange[3], playerLayerMask);

                    foreach (Collider2D col in hitConfirm)
                    {
                        HealthManager live = col.gameObject.GetComponent<HealthManager>();
                        GlobalMovement enemyPlayer = col.gameObject.GetComponent<GlobalMovement>();

                        if (GMscript.player1 != enemyPlayer.player1)
                        {
                            if (!enemyPlayer.isInDefence)
                            {
                                live.DamageTake(damages[3]);
                                enemyPlayer.paralyzed = true;
                                if (enemyPlayer.paralyzedTimer < enemyPlayer.paralyzedTime && enemyPlayer.paralyzedTimer > 0)
                                {
                                    enemyPlayer.paralyzedTimer += extraParalizedTime;
                                }
                            }
                            else
                            {
                                live.DamageTake(damages[3] * 0.2f);
                                enemyPlayer.Ondefence = true;
                            }
                        }
                    }
                }
                else
                {
                    animatorController.SetInteger("Punch", 0);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.V) && cooldown[0] <= 0)
                {
                    animatorController.SetInteger("Punch", 1);
                    cooldown[0] = startCoolDown[0];
                    Collider2D[] hitConfirm = Physics2D.OverlapBoxAll(boxColliderPoint[0].position, boxColliederRange[0], playerLayerMask);

                    foreach (Collider2D col in hitConfirm)
                    {
                        HealthManager live = col.gameObject.GetComponent<HealthManager>();
                        GlobalMovement enemyPlayer = col.gameObject.GetComponent<GlobalMovement>();

                        if (GMscript.player1 != enemyPlayer.player1)
                        {
                            if (!enemyPlayer.isInDefence)
                            {
                                live.DamageTake(damages[0]);
                                enemyPlayer.paralyzed = true;
                                if (enemyPlayer.paralyzedTimer < enemyPlayer.paralyzedTime && enemyPlayer.paralyzedTimer > 0)
                                {
                                    enemyPlayer.paralyzedTimer += extraParalizedTime;
                                }
                            }
                            else
                            {
                                live.DamageTake(damages[0] * 0.2f);
                                enemyPlayer.Ondefence = true;
                            }
                        }
                    }
                }
                else if (Input.GetKeyDown(KeyCode.B) && cooldown[1] <= 0)
                {
                    animatorController.SetInteger("Punch", 2);
                    cooldown[1] = startCoolDown[1];
                    Collider2D[] hitConfirm = Physics2D.OverlapBoxAll(boxColliderPoint[1].position, boxColliederRange[1], playerLayerMask);


                    if (kamehame.checkValidInput())
                    {
                        if (GMscript.standing == false)
                        {
                            Debug.Log(kamehame.name + "!!");
                            animatorController.SetInteger("Punch", 5);
                            GMscript.standing = true;
                        }
                    }

                    foreach (Collider2D col in hitConfirm)
                    {
                        HealthManager live = col.gameObject.GetComponent<HealthManager>();
                        GlobalMovement enemyPlayer = col.gameObject.GetComponent<GlobalMovement>();

                        if (GMscript.player1 != enemyPlayer.player1)
                        {
                            if (!enemyPlayer.isInDefence)
                            {
                                live.DamageTake(damages[1]);
                                enemyPlayer.paralyzed = true;
                                if (enemyPlayer.paralyzedTimer < enemyPlayer.paralyzedTime && enemyPlayer.paralyzedTimer > 0)
                                {
                                    enemyPlayer.paralyzedTimer += extraParalizedTime;
                                }
                            }
                            else
                            {
                                live.DamageTake(damages[1] * 0.2f);
                                enemyPlayer.Ondefence = true;
                            }
                        }
                    }
                }
                else if (Input.GetKeyDown(KeyCode.N) && cooldown[2] <= 0)
                {
                    animatorController.SetInteger("Punch", 3);
                    cooldown[2] = startCoolDown[2];
                    Collider2D[] hitConfirm = Physics2D.OverlapBoxAll(boxColliderPoint[2].position, boxColliederRange[2], playerLayerMask);

                    foreach (Collider2D col in hitConfirm)
                    {
                        HealthManager live = col.gameObject.GetComponent<HealthManager>();
                        GlobalMovement enemyPlayer = col.gameObject.GetComponent<GlobalMovement>();

                        if (GMscript.player1 != enemyPlayer.player1)
                        {
                            if (!enemyPlayer.isInDefence)
                            {
                                live.DamageTake(damages[2]);
                                enemyPlayer.paralyzed = true;
                                if (enemyPlayer.paralyzedTimer < enemyPlayer.paralyzedTime && enemyPlayer.paralyzedTimer > 0)
                                {
                                    enemyPlayer.paralyzedTimer += extraParalizedTime;
                                }
                            }
                            else
                            {
                                live.DamageTake(damages[2] * 0.2f);
                                enemyPlayer.Ondefence = true;
                            }
                        }
                    }
                }
                else if (Input.GetKeyDown(KeyCode.M) && cooldown[3] <= 0)
                {
                    animatorController.SetInteger("Punch", 4);
                    cooldown[3] = startCoolDown[3];
                    Collider2D[] hitConfirm = Physics2D.OverlapBoxAll(boxColliderPoint[3].position, boxColliederRange[3], playerLayerMask);

                    foreach (Collider2D col in hitConfirm)
                    {
                        HealthManager live = col.gameObject.GetComponent<HealthManager>();
                        GlobalMovement enemyPlayer = col.gameObject.GetComponent<GlobalMovement>();

                        if (GMscript.player1 != enemyPlayer.player1)
                        {
                            if (!enemyPlayer.isInDefence)
                            {
                                live.DamageTake(damages[3]);
                                enemyPlayer.paralyzed = true;
                                if (enemyPlayer.paralyzedTimer < enemyPlayer.paralyzedTime && enemyPlayer.paralyzedTimer > 0)
                                {
                                    enemyPlayer.paralyzedTimer += extraParalizedTime;
                                }
                            }
                            else
                            {
                                live.DamageTake(damages[3] * 0.2f);
                                enemyPlayer.Ondefence = true;
                            }
                        }
                    }
                }
                else
                {
                    animatorController.SetInteger("Punch", 0);
                }
            }
       
        }
    }
    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < boxColliderPoint.Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(boxColliderPoint[i].position, boxColliederRange[i]);
        }
    }
    
    private void InputMotion(bool player)
    {
        if (player)
        {
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                dpad = 5;
                horiz = 0;
                vert = 0;
            }
            else 
            {
                if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    horiz = 0;
                }
                else if(Input.GetKey(KeyCode.A))
                {
                    horiz = -1;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    horiz = 1;
                }

                if(Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.W)||!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
                {
                    vert = 0;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    vert = -1;
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    vert = 1;
                }
            }
            dpad = horiz + 2 + ((vert + 1) * 3);

            //Limpia la cantidad de dirreciones almacenadas



            while (dirBuffer.Count > 60)
            {
                dirBuffer.RemoveAt(dirBuffer.Count - 1);
            }
            if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.W) || Input.GetKeyUp(KeyCode.S)|| Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                dirBuffer.Insert(0, dpad);
            }
            else
            {
                dirBuffer.Insert(0, 5);
            }
        } 
        else
        {
            if (!Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L) && !Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.I))
            {
                dpad2 = 5;
                horiz2 = 0;
                vert2 = 0;
            }
            else
            {
                if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.L) || !Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L))
                {
                    horiz2 = 0;
                }
                else if (Input.GetKey(KeyCode.L))
                {
                    horiz2 = -1;
                }
                else if (Input.GetKey(KeyCode.J))
                {
                    horiz2 = 1;
                }

                if (Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.K) || !Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.I))
                {
                    vert2 = 0;
                }
                else if (Input.GetKey(KeyCode.K))
                {
                    vert2 = -1;
                }
                else if (Input.GetKey(KeyCode.I))
                {
                    vert2 = 1;
                }
            }
            dpad2 = horiz2 + 2 + ((vert2 + 1) * 3);

            while (dirBuffer2.Count > 60)
            {
                dirBuffer2.RemoveAt(dirBuffer2.Count - 1);
            }
            if (Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyUp(KeyCode.K) || Input.GetKeyUp(KeyCode.L) || Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.I) || Input.GetKeyUp(KeyCode.K))
            {
                dirBuffer2.Insert(0, dpad2);
            }
            else
            {
                dirBuffer2.Insert(0, 5);
            }
        }
    }
    public void installKame()
    {
        GameObject inst = Instantiate(kameObject,kameTrans.position,kameTrans.rotation);
        inst.GetComponent<KameScript>().ScribFather(gameObject.GetComponent<GlobalMovement>(),gameObject.GetComponent<Animator>(),EnemyGM);
    }

    public void Bloqueo()
    {
        EnemyGM.Ondefence = false;
    }
}
