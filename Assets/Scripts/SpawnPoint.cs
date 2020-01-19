using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;


public class SpawnPoint : MonoBehaviour
{

    [SerializeField]
    private Realtime _realtime; // Wire this up in the Unity Editor
    [SerializeField]
    private RealtimeAvatarManager _realtimeAM;

    public GameObject spawnHolder; 

    [SerializeField]
    private Transform[] _spawnPoints = new Transform[2];

    [SerializeField]
    public GameObject orb;

    [SerializeField]
    public GameObject[] LightPath = new GameObject[2];

    public static bool spawnOrb = false;

    RenderSettings skybox; 
   
    public GameObject[] seq1 = new GameObject[3];
    public GameObject[] seq2 = new GameObject[3];

    int sceneIndex = 0;
    
    Material skybox1;
    Material skybox2;
    Material rend;

    void Start()
    {
      //  rend = GetComponent<Renderer>();

     //   Main

        // At start, use the first material
     //   rend.material = skybox1;
     rend = RenderSettings.skybox;

    // RenderSettings.skybox.SetColor()
    }

    private void Awake()
    {
        // Subscribe to the didConnectToRoom event
        DisableScenes();
        _realtime.didConnectToRoom += DidConnectToRoom;

       // if (_realtime)

       // if (!_realtimeAM)    
        //    _realtimeAM = GetComponent<RealtimeAvatarManager>();
            // make sure disabled
        if (_realtimeAM != null)
            _realtimeAM.GetComponent<RealtimeAvatarManager>().enabled = false;

    //    if (!spawnHolder)
     //       spawnHolder = GameObject.FindGameObjectWithTag("spawnPoints");

      //  PopulateSpawnPoints();


    }

    private void Update()
    {
        if (spawnOrb) {
        // enable that shit
            orb.SetActive(true);
        } 

        if (TriggerToStart.start) {
            // increment scene
            IncrementScene();
            TriggerToStart.start = false;
        }

        if (TextFade.nextBreath)
        {
            // increment scene
            IncrementScene();
            TextFade.nextBreath = false;
        }
        if (TextFade.nextTouch)
        {
            // increment scene
            IncrementScene();
            TextFade.nextTouch = false;
        }
        if (TextFade.nextWalk)
        {
            // increment scene
           // IncrementScene();
            TextFade.nextWalk = false;
        }

        if (sceneIndex >= 4) {
        // this mean game is over
            IncrementScene();
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the didConnectToRoom event
        _realtime.didConnectToRoom -= DidConnectToRoom;
    }

    private void DidConnectToRoom(Realtime realtime)
    {
        // This method will be called by Realtime when it connects to the room.

        // Fetch this client's clientID
        int localPlayerClientID = _realtime.clientID;

        print("client # " + localPlayerClientID + " just joined");

        // Clamp the spawnPointIndex between 0 and the total number of spawn points
        int spawnPointIndex = localPlayerClientID;
        if (spawnPointIndex < 0) spawnPointIndex = 0;
        if (spawnPointIndex >= _spawnPoints.Length) spawnPointIndex = _spawnPoints.Length - 1;

        Transform spawnPoint = _spawnPoints[spawnPointIndex];

        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;

        print("client " + localPlayerClientID + " spawned at " + transform.position + " with rotation " + transform.rotation);

        _realtimeAM.GetComponent<RealtimeAvatarManager>().enabled = true;

        StartSceneSequence();

    }

    void PopulateSpawnPoints() {
     print("attempting to populate");
        for (int i = 0; i < _spawnPoints.Length; i++) {
            _spawnPoints[i] = spawnHolder.transform.GetChild(i);
        }
    }

    public void SkyboxBTW () {
   // RenderSettings.skybox.SetColor()
        //rend.material.Lerp(skybox1, skybox2, Time.deltaTime);
        //rend
    }

    void IncrementScene() {
        print("incrementing scenes");
        DisableScene(sceneIndex);
        sceneIndex++;
        if (sceneIndex < 4)
            SetScene(sceneIndex);
            else {
            SkyboxBTW();
            }
    }

    void SetScene(int index) {
        //sceneIndex = index;
        seq1[index].SetActive(true);
        seq2[index].SetActive(true);
    } 

    void DisableScene(int i) {
        seq1[i].SetActive(false);
        seq2[i].SetActive(false);
    }

    void DisableScenes() {
        print("Disable scenes");
        for (int i = 0; i < seq1.Length; i++) {
            seq1[i].SetActive(false);
            seq2[i].SetActive(false);
        }
    }

    void StartSceneSequence() {
        print("Attempting to start scene sequence");
        seq1[0].SetActive(true);
        seq2[0].SetActive(true);
    }

}
