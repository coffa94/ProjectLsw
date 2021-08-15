using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueShopKeeperController : MonoBehaviour
{
    [SerializeField] private PlayerInteraction playerInteraction;
    [SerializeField] private PlayerMovement playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitButton() {
        //reactivation of playerMovement and playerInteraction scripts
        playerInteraction.enabled = true;
        playerMovement.enabled = true;

        //deactivation of canvasDialogue
        gameObject.SetActive(false);
    }
}
