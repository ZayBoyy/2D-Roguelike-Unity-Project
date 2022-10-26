using UnityEngine;
using System.Collections;

public class Bandit : MonoBehaviour {

    //[SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 7.5f;

    public float speed = 1.0f;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = false;
    private bool                m_combatIdle = false;
    private bool                m_isDead = false;

    public Transform enemyT;

    public GameObject player;
    public Transform playerT;
   
    public float distToPlayer;

    public float airtime;
    public float timeWatcher;

    private Vector3 displacementToPlayer;

     private Vector3 directionToPlayer; 

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        airtime = 0;
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
    }
	
	// Update is called once per frame
	void Update () {
        //Check if character just landed on the ground
        if (airtime >= 60 || airtime == 0) {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, 0);
            airtime = 0;
        }

        //Check if character just started falling
        if(airtime >= 30) {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, -m_jumpForce);

        }

        // -- Handle input and movement --
        if (m_grounded == true) {
        displacementToPlayer = playerT.position - enemyT.position;
        distToPlayer = displacementToPlayer.magnitude;
        directionToPlayer = displacementToPlayer / distToPlayer;
        }

        if (m_grounded == false) { 
            for (; airtime < 60; airtime++) {
            if (Time.deltaTime > timeWatcher){
            timeWatcher = Time.deltaTime;
            }
            }
        }


        // Swap direction of sprite depending on walk direction
        if (playerT.position.x > 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (playerT.position.x < 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Move
       // m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
        

        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

        // -- Handle Animations --
        //Death
        if (Input.GetKeyDown("e")) {
            if(!m_isDead)
                m_animator.SetTrigger("Death");
            else
                m_animator.SetTrigger("Recover");

            m_isDead = !m_isDead;
        }
            
        //Hurt
        else if (Input.GetKeyDown("q"))
            m_animator.SetTrigger("Hurt");

        //Attack
        else if(Input.GetMouseButtonDown(0)) {
            m_animator.SetTrigger("Attack");
        }

        //Change between idle and combat idle
        else if (Input.GetKeyDown("f"))
            m_combatIdle = !m_combatIdle;

        //Jump
        else if (Input.GetKeyDown("space") && m_grounded) {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
        }

        //Run
        else if (distToPlayer <= 2.5f) {
            m_animator.SetInteger("AnimState", 2);
            enemyT.position += speed*directionToPlayer*Time.deltaTime;
        }

        //Combat Idle
        else if (m_combatIdle)
            m_animator.SetInteger("AnimState", 1);

        //Idle
        else
            m_animator.SetInteger("AnimState", 0);
    }
}
