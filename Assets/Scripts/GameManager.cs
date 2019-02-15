using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public MusicLoader loader;
    public MusicManager musicManager;
    public GameObject preFabSlider;
    public GameObject Piano;
    public GameObject collisionBar;
    public MusicView music;
    Vector3 position = new Vector3(0f, 0f, 0f);
    Vector3 localScale = new Vector3(0f, 0f, 0f);
    public List<GameObject> sliders = null;
    bool test = false;
    // Start is called before the first frame update

    void Start()
    {
        //DontDestroyOnLoad(Piano);
        sliders = new List<GameObject>();

        /*Music music2 = GameObject.FindWithTag("Music").GetComponent<Music>();
        //ajoutez les notes
        musicManager.addMusic(music2);*/
        DontDestroyOnLoad(this.gameObject);
    }

    public void initSliders()
    {
        float pos = 0;
        float spacing = (localScale.x / 88.0f);

        for (int i = 0; i < 88; i++)
        {

            Vector3 sliderPos = new Vector3(
            position.x - (localScale.x / 2),
            position.y - (localScale.y / 2),
            position.z + (localScale.z / 2));

            GameObject tmp = Instantiate(preFabSlider, sliderPos, Quaternion.identity);
            sliders.Add(tmp);
            DontDestroyOnLoad(tmp);
        }
        foreach (GameObject slider in sliders)
        {

            slider.transform.localScale = new Vector3(0.005f, 0.005f, 3f);
            slider.transform.localPosition += new Vector3(pos + (spacing / 2),
                position.y + (position.y / 2),
                (slider.transform.localScale.z / 2) + (localScale.z / 2));
            pos += spacing;
        }
        collisionBar.transform.position = new Vector3(position.x + (position.x / 2), position.y + (position.y / 2), (sliders[0].transform.position.z) - (sliders[0].transform.localScale.z / 2) + 0.2F);
        collisionBar = Instantiate(collisionBar);
        DontDestroyOnLoad(collisionBar);
    }
    // Update is called once per frame
    void Update()
    {

            Piano = GameObject.FindWithTag("Piano");
            if (Piano != null)
            {
                position = Piano.transform.position;
                localScale = Piano.transform.localScale;
                if (test == false)
                {
                    test = true;
                    DontDestroyOnLoad(Piano);
                }
            }
        }
}
