using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyar;
using UnityEngine.SceneManagement;

public class TargetsCreationScriopt : MonoBehaviour
{
    public GameObject targetPrefab;
    public GameObject tracker;
    // Start is called before the first frame update
    void Start()
    {
        string pathM = "Markers/";
        var markers = Resources.LoadAll(pathM);

        string pathP = "Prefebs/";
        var prefabs = Resources.LoadAll(pathP);

        for (int i = 0; i < prefabs.Length; i++)
        {
            GameObject target = GameObject.Instantiate(targetPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            var imgTargetController = target.GetComponent<ImageTargetController>();
            //Streaming Assets
            imgTargetController.ImageFileSource.Path += markers[i * 2].name + ".jpg";
            imgTargetController.Tracker = tracker.GetComponent<ImageTrackerFrameFilter>();
            imgTargetController.GetComponent<Unlocker>().index = i;

            GameObject model = GameObject.Instantiate((GameObject)prefabs[i], new Vector3(0, 0, 0), Quaternion.identity);
            model.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
            model.transform.SetParent(target.transform);
        }


    }

    public void BackToBack()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
