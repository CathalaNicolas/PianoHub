using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.UX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public MusicView        preFabMusic;
    public KeyManager       preFabKeyManager;
    public TCPTestServer    preFabServer;
    public GameObject       preFabSlider;
    public GameObject       preFabCollisionBar;
    public ScoreManager       preFabScore;
    public GameObject       preFabPiano;
    public ComboManager      preFabCombo;
    public MusicTimer       preFabTimer;

    public TCPTestServer server;
    public MusicView     music;
    public KeyManager keyManager;
    public MusicTimer musicTimer;

    private GameObject collisionBar = null;
    private GameObject pianoIG = null;
    public ScoreManager score = null;
    public ComboManager combo = null;
    private List<GameObject> sliders = null;

    public bool gamePaused = false;

    void Start()
    {
        sliders = new List<GameObject>();
        pianoIG = Instantiate(preFabPiano);

        DontDestroyOnLoad(pianoIG);
        DontDestroyOnLoad(this.gameObject);

        initSliders();
        initCollisionBar();
        initKeyManager();
        initServer();
    }
    
    //Init the Collision Bar which will destroy note upon collision
    //Position of the collision bar:
    //In X:     The bar is centred on the piano position in x.
    //In Y:     The bar got the same height as the piano
    //In Z:     The bar have an offset position in Z, so it doesn't touch the piano.

    public void initCollisionBar()
    {
        Vector3 position = pianoIG.GetComponent<Transform>().localPosition;
        Vector3 localScale = pianoIG.GetComponent<Transform>().localScale;
        Quaternion rotation = pianoIG.GetComponent<Transform>().localRotation;

        collisionBar = Instantiate(preFabCollisionBar);
        collisionBar.transform.SetParent(pianoIG.transform);
        collisionBar.transform.position = new Vector3(position.x,
            position.y, (position.z + (0.1F / localScale.z)));
        collisionBar.transform.Rotate(rotation.x, rotation.y, 0);
    }
   
    //Init the 88 sliders corresponding to the piano keys.
    //Position of a Slider:
    //In X :   the position in X is the spacing between sliders, starting at the left top border of the piano
    //In Y:    the position in Y correspond to the height of the piano, (lower Y will put the slider below the piano).
    //In Z:    the position in Z correspond to the distance at which the slider will be from the piano.

    public void initSliders()
    {
        Vector3 position = pianoIG.GetComponent<Transform>().localPosition;
        Vector3 localScale = pianoIG.GetComponent<Transform>().localScale;
        Quaternion rotation = pianoIG.GetComponent<Transform>().localRotation;

        float pos = position.x - (localScale.x / 2);
        float spacing = (localScale.x / 88.0f);

        for (int i = 0; i < 88; i++)
        {
            GameObject tmp = Instantiate(preFabSlider);
            tmp.transform.SetParent(pianoIG.transform);

            sliders.Add(tmp);

            tmp.transform.localScale = new Vector3(0.005f, 0.005f, 13f);

            tmp.transform.position = new Vector3(pos + spacing / 2,
            position.y + (position.y / 2),
             position.z + ((tmp.transform.localScale.z / 2) * localScale.z) + (0.1F / localScale.z));

            pos += spacing;
        }
    }

    public void initScore()
    {
        Vector3 position = pianoIG.GetComponent<Transform>().localPosition;
        Vector3 localScale = pianoIG.GetComponent<Transform>().localScale;

        score = Instantiate(preFabScore);
        score.transform.position = new Vector3(position.x - (localScale.x + 1F), position.y, position.z);
        DontDestroyOnLoad(score);
    }

    public void initCombo()
    {
        combo = Instantiate(preFabCombo);
        if (!combo)
            Debug.LogError("GameManager: can't init combo!");
        DontDestroyOnLoad(combo);
    }

    public void initGame()
    {
        initScore();
        initCombo();
        initTimer();
    }

    public void initKeyManager()
    {
        keyManager = Instantiate(preFabKeyManager);
        if (!keyManager)
            Debug.Log("No key manager created.");
        DontDestroyOnLoad(keyManager);
    }

    public void initTimer()
    {
        musicTimer = Instantiate(preFabTimer);
        if (!musicTimer)
            Debug.Log("No music timer created.");
        DontDestroyOnLoad(musicTimer);
    }

    public void initServer()
    {
      server = Instantiate(preFabServer);
        if (!server)
            Debug.Log("Serveur can't be created.");
        server.Connect("127.0.0.1", "10080");
        DontDestroyOnLoad(server);
    }

    public void initMusic()
    {
        music = Instantiate(preFabMusic);
        if (!music)
            Debug.Log("Music can't be created.");
        DontDestroyOnLoad(music);
    }

    public void testDelete()
    {
        Destroy(pianoIG.GetComponent<BoundingBox>());
        Destroy(pianoIG.GetComponent<BoxCollider>());
        Destroy(pianoIG.GetComponent<MeshRenderer>());
    }
    
    // Update is called once per frame
    void Update()
    {
        
        List<int> active =  keyManager.getActiveKey();

        for (int i = 0; i < active.Count; i++)
        {
            Vector3 tmp;

            tmp = sliders[active[i]].transform.localScale;
            sliders[active[i]].transform.localScale += new Vector3(0.2F, 0.2F, 0);
            for (int y = 0; y < 20000; y++) ;
            sliders[active[i]].transform.localScale = tmp;
        }

    }
}
