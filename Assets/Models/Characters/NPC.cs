using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class NPC : MonoBehaviour
{
    enum AttackTypeVal
    {
        KICK = 1,
        FIST = 2,
        FIST_OFF = 3
    };

    public class SpeedValues
    {
        public static float WALK = 0.5f;
        public static float RUN = 1.0f;
    }

    protected enum Tasks
    {
        MOVE_RANDOM = 1,
        DANCE = 2,
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
    private bool DoStanding;

    protected bool DoLoot;
    protected bool DoMeditate;

    NavMeshAgent agent;
    Vector3 startPosition;

    // Target point for debug purpose
    // protected static GameObject prefab;

    private bool move = false;
    private Vector3 targetPoint;
    private Quaternion targetRotation;
    protected GameObject target;

    // Start is called before the first frame update
    protected void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

       /*if(NPC.prefab == null)
       {
          prefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
       }*/

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
            move = false;
        }

        if (target != null)
        {
            //find the vector pointing from our position to the target
            targetPoint = (target.transform.position - transform.position).normalized;

            //create the rotation we need to be in to look at the target
            targetRotation = Quaternion.LookRotation(targetPoint);
            targetRotation *= Quaternion.Euler(0, 90, 0); // this adds a 90 degrees Y rotation

            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10.0f);

            Transform targetPosition = target.transform;

            setSpeed(SpeedValues.RUN);
            agent.destination = targetPosition.position;
            agent.speed = Speed;

            NPC opponent = target.GetComponent<NPC>();
            
            if(Vector3.Distance(transform.position, target.transform.position) <= 1.0f)
            {
                setSpeed(0.0f);
                Fight(opponent);
            }
        }

        if(move)
        {
            targetRotation = Quaternion.LookRotation(agent.destination);
            targetRotation *= Quaternion.Euler(0, 90, 0); // this adds a 90 degrees Y rotation

            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10.0f);

            agent.updateRotation = false;
            agent.speed = SpeedValues.RUN;
            setSpeed(agent.speed);
        }
    }

    public GameObject GetClosestObject(string tag)
    {
        float radius = 100.0f;
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        GameObject closestObject = null;

        foreach (GameObject obj in objectsWithTag)
        {
            // Skip itself
            if(obj.transform.position == this.transform.position)
            {
                continue;
            }

            if (closestObject == null)
            {
                closestObject = obj;
            }

            // Compares distances
            if (Vector3.Distance(transform.position, obj.transform.position) <= Vector3.Distance(transform.position, closestObject.transform.position))
            {
                closestObject = obj;
            }
        }

        return closestObject;
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
        DoStanding = anim.GetBool("DoStanding");
    }

    protected void Live()
    {
        if(Life > 0)
        {
            setLife(Life - 1);
        }
    }

    public void Loot()
    {
        DoLoot = true;
        anim.SetBool("DoLoot", DoLoot);
    }

    protected void Standing()
    {
        DoStanding = true;
        anim.SetBool("DoStanding", DoStanding);
    }

    public void MoveRandomPoint()
    {
        Debug.Log("Move to a random point");

        // Move to a random position
        float roamRadius = 10.0f;
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
        randomDirection += startPosition;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);
        Vector3 finalPosition = hit.position;
        agent.destination = finalPosition;
        targetPoint = agent.destination;
        move = true;
        // Instantiate(NPC.prefab, finalPosition, Quaternion.identity);
    }

    public void Dance()
    {
        Debug.Log("Dance until your dead");
        DoDance = !DoDance;
        anim.SetBool("DoDance", DoDance);
    }
    
    public void Medidate()
    {
        Debug.Log("ZEEEEEEEEEEN");
        DoMeditate = !DoMeditate;
        anim.SetBool("DoMeditate", DoMeditate);
    }

    public void Chicken()
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

    abstract protected void ChoiceTask();

    public void setTarget(NPC target)
    {
        this.target = (GameObject) target.gameObject;
    }

    public void Fight(NPC opponent)
    {
        Debug.Log("FIGHT !!");
        setAttackType(Random.Range(1, 4));
        opponent.setTarget(this);
    }

    public void MovePosition(Vector3 position, Quaternion rotation)
    {
        agent.destination = position;
        agent.updateRotation = true;
    }
}
