using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;


public class RoomBehaviour : MonoBehaviour
{
    public bool isAccessible;
    public List<GameObject> neighboursList = new List<GameObject>();

    public bool checkNeighbour(string neighbourName)
    {
        MethodInfo methodInfo = typeof(LogicManager).GetMethod(this.gameObject.name); // check gameobject names match logicmanager and spoiler log names perfectly

        // Checks Logic Manager for availibility and sets checkAvailibility
        if (methodInfo != null)
        {
            object[] neighbourNameArray = new object[] { neighbourName };
            object returnValue = methodInfo.Invoke(LogicManager.Instance, neighbourNameArray);

            if (returnValue is bool)
            {
                bool result = (bool)returnValue;

                if (result)
                    return true;
                else
                    return false;
            }
            else
            {
                // If didn't return bool
                Debug.LogError("Method did not return a boolean: " + this.gameObject.name);
                return false;
            }
        }
        else
        {
            // If method name does not exist
            Debug.LogError("Method not found: " + this.gameObject.name);
            return false;
        }
    }
}
