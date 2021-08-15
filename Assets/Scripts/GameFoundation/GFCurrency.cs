using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.GameFoundation;
using UnityEngine.GameFoundation.DefaultLayers;
using UnityEngine.Promise;

public class GFCurrency : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Currency FindDefinition(string definitionKey) {
        // Use the key you've used in the previous tutorial.
        //const string definitionKey = "boot_01";

        // Finding a definition takes a non-null string parameter.
        Currency definition = GameFoundationSdk.catalog.Find<Currency>(definitionKey);


        // Make sure you retrieved a valid definition.
        if (definition is null) {
            Debug.Log($"Definition {definitionKey} not found");
            return null;
        } else {

            // You should be able to get information from your definition now.
            Debug.Log($"Definition {definition.key} ({definition.type}) '{definition.displayName}' found.");

            //return the result
            return definition;
        }

    }

    public long GetBalance(string definitionKey) {
        Currency definition = FindDefinition(definitionKey);

        // You can get the balance of a currency with the WalletManager.
        long balance = GameFoundationSdk.wallet.Get(definition);

        Debug.Log($"The balance of '{definition.displayName}' is {balance.ToString()}");

        return balance;
    }

    public void SetBalance(string definitionKey, long newCurrencyValue) {
        Currency definition = FindDefinition(definitionKey);

        // Set replaces the current balance by a new one.
        bool success = GameFoundationSdk.wallet.Set(definition, newCurrencyValue);

        if (!success) {
            Debug.LogError($"Failed in setting a new value for '{definition.displayName}'");
            return;
        }

        var newBalance = GameFoundationSdk.wallet.Get(definition);

        Debug.Log($"The new balance of '{definition.displayName}' is {newBalance.ToString()}");
    }

    public void AddBalance(string definitionKey, long addCurrencyValue) {
        Currency definition = FindDefinition(definitionKey);

        // Add a value to the current balance.
        bool success = GameFoundationSdk.wallet.Add(definition, addCurrencyValue);

        if (!success) {
            Debug.LogError($"Failed in adding a value to '{definition.displayName}'");
            return;
        }

        var newBalance = GameFoundationSdk.wallet.Get(definition);

        Debug.Log($"The new balance of '{definition.displayName}' is {newBalance.ToString()}");
    }

    public void SubtractBalance(string definitionKey, long subtractCurrencyValue) {
        Currency definition = FindDefinition(definitionKey);

        // Substract a value from the current balance.
        bool success = GameFoundationSdk.wallet.Add(definition, -subtractCurrencyValue);

        if (!success) {
            Debug.LogError($"Failed in subtracting a value to '{definition.displayName}'");
            return;
        }

        var newBalance = GameFoundationSdk.wallet.Get(definition);

        Debug.Log($"The new balance of '{definition.displayName}' is {newBalance.ToString()}");
    }
}
