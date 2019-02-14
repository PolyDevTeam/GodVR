/**
 * @file NPC.cs
 * @brief IA de tout les PNJ
 * @author Guillaume MICHON
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/**
 * @class NPC
 * @brief IA de tout les PNJ (Personnage non joueur)
 */
public abstract class NPC : MonoBehaviour
{
    /**
     * @enum Str_err_e
     * @brief Type d'attaque d'un PNJ
     */
    enum AttackTypeVal
    {
        KICK = 1,
        FIST = 2,
        FIST_OFF = 3
    };

    /**
     * @class SpeedValues
     * @brief Objet qui contient les différentes constantes de vitesse pour un PNJ
     */
    public class SpeedValues
    {
        public static float WALK = 0.5f;
        public static float RUN = 1.0f;
    }

    /**
     * @enum Tasks
     * @brief Listes des tâches que peut faire un PNJ
     */
    protected enum Tasks
    {
        MOVE_RANDOM = 1,
        DANCE = 2,
    }

    protected Animator anim; /*!< Liste des morceaux*/
    private float Speed; /*!< Valeur de la vitesse de mouvement */
    private int Life; /*!< Point de vie*/
    private int AttackType; /*!< Type d'attaque à utiliser */
    private bool DoChiken; /*!< Lance l'animation Chicken si vrai */
    private bool DoCower; /*!< Lance l'animation Cower si vrai*/
    private bool DoDance; /*!< Lance l'animation Dance si vrai */
    private bool DoCry; /*!< Lance l'animation Cry si vrai */
    private bool DoStrangulate; /*!< Lance l'animation Strangulate si vrai */
    private bool DoStanding; /*!< Lance l'animation Standing si vrai */

    protected bool DoLoot; /*!< Lance l'animation Loot si vrai */
    protected bool DoMeditate; /*!< Lance l'animation Meditate si vrai */

    NavMeshAgent agent; /*!< NavMeshAgent de NPC */
    Vector3 startPosition; /*!< Point de départ dans le pathing */

    // Target point for debug purpose
    // protected static GameObject prefab;

    private bool move = false; /*!< Si vrai modification de la vitesse autorisé */
    private Vector3 targetPoint; /*!< Point d'arrivé dans le pathing */
    private Quaternion targetRotation; /*!< Rotation d'arrivé */
    protected GameObject target; /*!< PNJ à taper */

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

        InvokeRepeating("ChoiceTask", 2.0f, 30.0f);
        InvokeRepeating("Live", 60.0f, 1.0f);
    }

    // Update is called once per frame
    protected void Update()
    {
        updateAnimationVariables();

        if (Life == 0)
        {
            setSpeed(0.0f);
            move = false;
            return;
        }

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

    /**
     * @fn GameObject GetClosestObject(string tag)
     * @brief Recherche l'objet le plus proche de l'objet courant qui porte le tag
     * @param tag Tag de l'objet à rechercher
     * @return Renvoie l'objet le plus proche portant le tag, sinon renvoie NULL.
     */
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

    /**
     * @fn int getLife()
     * @return Les points de vie restant du PNJ
     */
    public int getLife()
    {
        return this.Life;
    }

    /**
     * @fn void setLife(int Life)
     * @brief Modifie les points de vie du PNJ (si celui est à 0 il jouera l'animation de mort)
     * @param Life Nombre de point de vie qu'aura le PNJ
     */
    public void setLife(int Life)
    {
        this.Life = Life;
        anim.SetInteger("Life", Life);
    }

    /**
     * @fn float getSpeed()
     * @return La vitesse du PNJ
     */
    public float getSpeed()
    {
        return this.Speed;
    }

    /**
     * @fn void setSpeed(float speed)
     * @brief Modifie la vitesse du PNJ
     * @param speed Vitesse qu'aura le PNJ
     */
    public void setSpeed(float speed)
    {
        this.Speed = speed;
        anim.SetFloat("Speed", Speed);
    }

    /**
     * @fn int getAttackType()
     * @return Le type d'attaque
     */
    public int getAttackType()
    {
        return this.AttackType;
    }

    /**
     * @fn void setAttackType(int attackType)
     * @param attackType Type d'attaque à faire
     */
    public void setAttackType(int attackType)
    {
        this.AttackType = attackType;
        anim.SetInteger("AttackType", AttackType);
    }

    /**
     * @fn void updateAnimationVariables()
     * @brief Mets à jours toutes les variables de l'animator avec celle de la classe (Appelé lors de l'Update)
     */
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

    /**
     * @fn void Live()
     * @brief Décrémente la vie du PNJ de 1
     */
    protected void Live()
    {
        if(Life > 0)
        {
            setLife(Life - 1);
        }
    }

    /**
     * @fn void Loot()
     * @brief Lance l'animation Loot
     */
    public void Loot()
    {
        DoLoot = true;
        anim.SetBool("DoLoot", DoLoot);
    }

    /**
     * @fn void Standing()
     * @brief Lance l'animation Standing
     */
    protected void Standing()
    {
        DoStanding = true;
        anim.SetBool("DoStanding", DoStanding);
    }

    /**
     * \fn void MoveRandomPoint()
     * \brief Sélectionne un point au hasard dans un rayon donnée
     */
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

    /**
     * @fn void Dance()
     * @brief Lance l'animation Dance
     */
    public void Dance()
    {
        Debug.Log("Dance until your dead");
        DoDance = !DoDance;
        anim.SetBool("DoDance", DoDance);
    }

    /**
     * @fn void Medidate()
     * @brief Lance l'animation Medidate
     */
    public void Medidate()
    {
        Debug.Log("ZEEEEEEEEEEN");
        DoMeditate = !DoMeditate;
        anim.SetBool("DoMeditate", DoMeditate);
    }

    /**
     * @fn void Chicken()
     * @brief Lance l'animation Chicken
     */
    public void Chicken()
    {
        Debug.Log("Chicken little is in da place !");
        DoChiken = !DoChiken;
        anim.SetBool("DoChiken", DoChiken);
    }

    /**
     * @fn void cower()
     * @brief Lance l'animation Cower
     */
    public void cower()
    {
        Debug.Log("This is the cow !");
        DoCower = !DoCower;
        anim.SetBool("DoCower", DoCower);
    }

    /**
     * @fn void cry()
     * @brief Lance l'animation Cry
     */
    public void cry()
    {
        Debug.Log("Cry in your mother pants little girl");
        DoCry = !DoCry;
        anim.SetBool("DoCry", DoCry);
    }

    /**
     * @fn void strangulate()
     * @brief Lance l'animation Strangulate
     */
    public void strangulate()
    {
        Debug.Log("Take a deep breath lul");
        DoStrangulate = !DoStrangulate;
        anim.SetBool("DoStrangulate", DoStrangulate);
    }

    /**
     * @fn void ChoiceTask()
     * @brief Choisi une tache au hasard et l'execute
     */
    abstract protected void ChoiceTask();

    /**
     * @fn void setTarget(NPC target)
     * @brief Choisi un PNJ en focus (ce tourne vers lui)
     * @param target PNJ à target
     */
    public void setTarget(NPC target)
    {
        this.target = (GameObject) target.gameObject;
    }

    /**
     * @fn void Fight(NPC opponent)
     * @brief Attaque un autre PNJ avec une attaque aléatoire
     * @param opponent PNJ à attaquer
     */
    public void Fight(NPC opponent)
    {
        Debug.Log("FIGHT !!");
        setAttackType(Random.Range(1, 4));
        opponent.setTarget(this);
    }

    /**
     * @fn void MovePosition(Vector3 position, Quaternion rotation)
     * @brief Bouge un PNJ en direction du point donnée et le tourne avec la rotation donnée
     * @param position Point de destination
     * @param rotation Rotation final
     */
    public void MovePosition(Vector3 position, Quaternion rotation)
    {
        agent.destination = position;
        agent.updateRotation = true;
    }
}
