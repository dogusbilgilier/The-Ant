using UnityEngine;
using UnityEngine.AI;

public class Shoe : MonoBehaviour
{
    GameObject shoeAnim;
    float wanderTimer;
    NavMeshAgent agent;
    float timer;
    public Material[] colors= new Material[6];
    [SerializeField]SkinnedMeshRenderer tong, shoe;
    private void OnEnable()
    {
        shoeAnim = gameObject.transform.GetChild(0).gameObject;
    }
    void Start()
    {
        timer = wanderTimer;
        wanderTimer = Random.Range(5, 10);
        agent = GetComponent<NavMeshAgent>();

        //Ayakkabıları renklendirme terliklarin animasyon hızını ayarlama
        if (gameObject.name.Contains("Shoe"))
        {
            tong = transform.GetChild(0).Find("Tongue").GetComponent<SkinnedMeshRenderer>();
            shoe = transform.GetChild(0).Find("colliderObj").GetComponent<SkinnedMeshRenderer>();
            GetColored(tong);
            GetColored(shoe);
        }
        else
            gameObject.GetComponentInChildren<Animator>().speed = 0.8f;
       
    }

    void Update()
    {
        // Ayakkabıların ve terliklerin animasyon ve yürüme kontrolleri
        if (shoeAnim.transform.position.y > 1.5f)
        {
            agent.isStopped = false;
            if (timer >= wanderTimer)
            {
                Vector3 newPos =new Vector3(Random.Range(-20,20),0.1f,transform.position.z+Random.Range(-26,26));
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
        else
            agent.isStopped = true;

        timer += Time.deltaTime;
        
    }
    public void GetColored(SkinnedMeshRenderer renderer)
    {
        renderer.material = colors[Random.Range(0, 5)];
    }


}