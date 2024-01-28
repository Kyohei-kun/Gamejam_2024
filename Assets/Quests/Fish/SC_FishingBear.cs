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
    bool done = false;

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
        if(listFish.Count == 0 && !done)
        {
            BearLeave();
            done = true;
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
            GetComponent<Animator>().enabled = true;
            head.transform.rotation = Quaternion.identity;
        }
    }

    void BearReactPlayer()
    { 
        head.transform.LookAt(player.transform.position);
        head.transform.Rotate(Vector3.up,-90);
        head.transform.Rotate(Vector3.forward,-90);
        GetComponent<Animator>().enabled = false;
    }

    private void BearLeave()
    {
        GetComponent<Animator>().SetTrigger("leave");
        QuestSystem.PlayVictoryFX(transform.position);
        CS_QuestUISystem.Validate(8);
    }

    public void Dissapear()
    {
        GameObject fx = GameObject.Instantiate(fxPouf, rigBear.position, Quaternion.identity);
        fx.transform.localScale += Vector3.one * 5;
        GameObject.Destroy(gameObject);
    }
}
