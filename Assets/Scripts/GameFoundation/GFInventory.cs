using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.GameFoundation;
using UnityEngine.GameFoundation.DefaultLayers;
using UnityEngine.Promise;

public class GFInventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private InventoryItemDefinition FindDefinition(string definitionKey) {
        // Use the key you've used in the previous tutorial.
        //const string definitionKey = "boot_01";

        // Finding a definition takes a non-null string parameter.
        InventoryItemDefinition definition = GameFoundationSdk.catalog.Find<InventoryItemDefinition>(definitionKey);


        // Make sure you retrieved a valid definition.
        if (definition is null) {
            Debug.Log($"Definition {definitionKey} not found");
            return null;
        } else {

            // You should be able to get information from your definition now.
            Debug.Log($"Definition {definition.key} '{definition.displayName}' found.");

            //return the result
            return definition;
        }

    }

    public InventoryItem CreateInstance(string definitionKey) {

        InventoryItemDefinition definition = FindDefinition(definitionKey);


        //creation of an inventoryItem istance
        InventoryItem item = GameFoundationSdk.inventory.CreateItem(definition);

        Debug.Log($"Item {item.id} of definition '{item.definition.key}' created");

        return item;
    }

    public void DeleteInstance(InventoryItem item) {
        //deleting of an inventoryItem istance
            bool removed = GameFoundationSdk.inventory.Delete(item);

            if (!removed) {
                Debug.LogError($"Unable to remove item {item.id}");
                return;
            }

            Debug.Log("item rimosso");
            //Debug.Log($"Item {item.id} successfully removed. Its discarded value is {item.hasBeenDiscarded.ToString()}");
            
    }

    public void GetStaticProperty<T>(string definitionKey, string propertyKey, out T valueFound) {

        InventoryItemDefinition definition = FindDefinition(definitionKey);


        // A safer way to get the property is by using TryGetStaticProperty to make sure the key is right.
        if (definition.TryGetStaticProperty(propertyKey, out Property valueProperty)) {

            Debug.Log($"Static property '{propertyKey}' found; value: '{valueProperty}'");

            switch (valueProperty.type) {
                case PropertyType.Long:
                    valueFound = (T)(object)valueProperty.AsInt();
                    Debug.Log(valueFound.GetType());
                    break;
                /*case PropertyType.Bool:
                    return valueProperty.AsBool();
                case PropertyType.Double:
                    return valueProperty.AsDouble();
                case PropertyType.String:
                    return valueProperty.AsString();
                case PropertyType.ResourcesAsset:
                    return valueProperty.AsAsset<Sprite>();
                */
                    default:
                    valueFound = (T)(object)2;
                    break;
            }
            



        } else {
            // The key couldn't be found, maybe we made a type in the editor or in this script.
            Debug.LogError($"Static property {propertyKey} not found");

            //return null;
            valueFound = (T)(object)2;
        }
    }
}
