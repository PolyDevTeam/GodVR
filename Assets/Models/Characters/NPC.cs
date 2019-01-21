using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    enum AttackTypeVal
    {
        KICK = 1,
        FIST = 2,
        FIST_OFF = 3
    };

    protected enum Tasks
    {
        MOVE_RANDOM = 1,
        DANCE = 2,
        MEDITATE = 3,
        CHICKEN = 4,
    }

    protected Animator anim;
    private float Speed;
    private int Life;
    private int AttackType;
    private bool DoChiken;
    private bool DoCower;
    private bool DoDance;
    private bool DoCry;
    private bool DoStrangulate;

    protected bool DoLoot;
    protected bool DoMeditate;

    NavMeshAgent agent;
    Vector3 startPosition;

    // Target point for debug purpose
    // protected static GameObject prefab;

    // Start is called before the first frame update
    protected void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

       // if(NPC.prefab == null)
       // {
       //     prefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
       // }

        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        InvokeRepeating("ChoiceTask", 0.3f, 30.0f);
        InvokeRepeating("Live", 60.0f, 1.0f);
    }

    // Update is called once per frame
    protected void Update()
    {
        updateAnimationVariables();

        if (transform.position == agent.destination)
        {
            setSpeed(0.0f);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            setSpeed(1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            setLife(0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            setSpeed(0.0f);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            setAttackType(Random.Range(1, 4));
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            chicken();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            medidate();
        }
    }

    public int getLife()
    {
        return this.Life;
    }

    public void setLife(int Life)
    {
        this.Life = Life;
        anim.SetInteger("Life", Life);
    }

    public float getSpeed()
    {
        return this.Speed;
    }

    public void setSpeed(float speed)
    {
        this.Speed = speed;
        anim.SetFloat("Speed", Speed);
    }

    public int getAttackType()
    {
        return this.AttackType;
    }

    public void setAttackType(int attackType)
    {
        this.AttackType = attackType;
        anim.SetInteger("AttackType", AttackType);
    }

    private void updateAnimationVariables()
    {
        Speed = anim.GetFloat("Speed");
        Life = anim.GetInteger("Life");
        AttackType = anim.GetInteger("AttackType");
        DoChiken = anim.GetBool("DoChiken");
        DoLoot = anim.GetBool("DoLoot");
        DoCower = anim.GetBool("DoCower");
        DoMeditate = anim.GetBool("DoMeditate");
        DoDance = anim.GetBool("DoDance");
        DoCry = anim.GetBool("DoCry");
        DoStrangulate = anim.GetBool("DoStrangulate");
    }

    protected void Live()
    {
        if(Life > 0)
        {
            setLife(Life - 1);
        }
    }

    public void moveRandomPoint()
    {
        Debug.Log("Move to a random point");
        // Move to a random position
        //float roamRadius = 10.0f;

        //Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
        //randomDirection += startPosition;

        //NavMeshHit hit;
        //NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);
        //Vector3 finalPosition = hit.position;
        //agent.destination = finalPosition;
        //// Instantiate(NPC.prefab, finalPosition, Quaternion.identity);

        //agent.speed = 1.0f;
        //setSpeed(agent.speed);
    }

    public void dance()
    {
        Debug.Log("Dance until your dead");
        DoDance = !DoDance;
        anim.SetBool("DoDance", DoDance);
    }
    
    public void medidate()
    {
        Debug.Log("ZEEEEEEEEEEN");
        DoMeditate = !DoMeditate;
        anim.SetBool("DoMeditate", DoMeditate);
    }

    public void chicken()
    {
        Debug.Log("Chicken little is in da place !");
        DoChiken = !DoChiken;
        anim.SetBool("DoChiken", DoChiken);
    }

    public void cower()
    {
        Debug.Log("This is the cow !");
        DoCower = !DoCower;
        anim.SetBool("DoCower", DoCower);
    }

    public void cry()
    {
        Debug.Log("Cry in your mother pants little girl");
        DoCry = !DoCry;
        anim.SetBool("DoCry", DoCry);
    }

    public void strangulate()
    {
        Debug.Log("Take a deep breath lul");
        DoStrangulate = !DoStrangulate;
        anim.SetBool("DoStrangulate", DoStrangulate);
    }

    protected void ChoiceTask()
    {
        Tasks task = (Tasks) Random.Range(1, Tasks.GetNames(typeof(Tasks)).Length + 1);

        switch(task)
        {
            case Tasks.MOVE_RANDOM:
                moveRandomPoint();
                break;
            case Tasks.DANCE:
                dance();
                break;
            case Tasks.MEDITATE:
                medidate();
                break;
            case Tasks.CHICKEN:
                chicken();
                break;
            default:
                Debug.Log("Unknown tasks");
                break;
        }
    }

}
