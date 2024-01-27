using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_FishingBear : MonoBehaviour
{
    [SerializeField]
    GameObject head;
    [SerializeField]
    GameObject fxPouf;
    [SerializeField]
    List<AudioClip> clipList = new List<AudioClip>();
    [SerializeField]
    Transform rigBear;

    List<GameObject> listFish = new List<GameObject>();
    bool reactPlayer = false;
    GameObject player;

    public List<GameObject> ListFish
    {   
        get { return listFish; }
        set { listFish = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(listFish.Count == 0)
        {
            BearLeave();
        }

        if(reactPlayer) 
        {
            BearReactPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            player = other.gameObject;
            reactPlayer = true;
            GetComponent<AudioSource>().PlayOneShot(clipList[Random.Range(0, clipList.Count-1)]);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            reactPlayer = false;
            head.transform.rotation = Quaternion.identity;
        }
    }

    void BearReactPlayer()
    { 
        head.transform.LookAt(player.transform.position);
        

    }

    private void BearLeave()
    {
        GetComponent<Animator>().SetTrigger("leave");
        QuestSystem.PlayVictoryFX(transform.position);
    }

    public void Dissapear()
    {
        GameObject fx = GameObject.Instantiate(fxPouf, rigBear.position, Quaternion.identity);
        fx.transform.localScale += Vector3.one * 5;
        GameObject.Destroy(gameObject);
    }
}
