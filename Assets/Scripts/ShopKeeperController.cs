using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperController : MonoBehaviour
{
    [SerializeField] private Canvas canvasDialouge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //start first dialogue with the player
    public void StartDialogue() {
        Debug.Log("Dialogue started");
        canvasDialouge.gameObject.SetActive(true);
    }
}
