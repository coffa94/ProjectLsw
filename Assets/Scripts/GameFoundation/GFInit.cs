using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.GameFoundation;
using UnityEngine.GameFoundation.DefaultLayers;
using UnityEngine.Promise;

public class GFInit : MonoBehaviour
{
    [SerializeField] private GFInventory gfInventory;
    [SerializeField] private GFCurrency gfCurrency;



    //initialization of game foundation
    IEnumerator Start() {

        // Creates a new data layer for Game Foundation,
        // with the default parameters.
        MemoryDataLayer dataLayer = new MemoryDataLayer();

        // - Initializes Game Foundation with the data layer.
        // - We use a using block to automatically release the deferred promise handler.
        using (Deferred initDeferred = GameFoundationSdk.Initialize(dataLayer)) {
            yield return initDeferred.Wait();

            if (initDeferred.isFulfilled)
                OnInitSucceeded();
            else
                OnInitFailed(initDeferred.error);
        }
    }

    // Called when Game Foundation is successfully initialized.
    void OnInitSucceeded() {
        Debug.Log("Game Foundation is successfully initialized");

        gfInventory.CreateInstance("boot_01");
        int cost;
        gfInventory.GetStaticProperty("boot_01", "Cost", out cost);
        Debug.Log("cost: " + cost + ", type: " + cost.GetType());

    }

    // Called if Game Foundation initialization fails 
    void OnInitFailed(System.Exception error) {
        Debug.LogException(error);
    }
}
