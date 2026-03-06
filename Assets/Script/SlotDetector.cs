using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Collections;

public class SlotDetector : MonoBehaviour
{
    public GameObject slot1; // Reference to slot 1
    public GameObject slot2; // Reference to slot 2
    public GameObject slot3; // Reference to slot 3
    public GameObject slot4; // Reference to slot 4
    public GameObject crafted1;//first crafted object
    public GameObject crafted2;//crafted object
    public GameObject crafted3;//crafted object
    public GameObject crafted4;//crafted object
    public GameObject crafted5;//crafted object
    public GameObject crafted6;//crafted object

    public TMP_Text missing_stuff;//show on panel what is missing
    public TMP_Text step;//show step
    public TMP_Text now_have;//show what is on it now

    public GameObject portal;

    public Texture Texture1;
    public Texture Texture2;
    public Texture Texture3;
    public Texture Texture4;
    public Texture Texture5;
    public Texture Texture6;
    public GameObject targetGameObject;//these are capture of the user manual

    public GameObject originSwitch;//make items go origin

    string listContent;
    int counter = 0;//ref for step

    private GameObject currentTopObject;

    public float detectionHeight = 0.1f; // Height above the slot to detect objects

    // List of required object names
    private List<string> requiredNames = new List<string> { "nut", "motor", "motor_stabler", "screw" };
    void Start()
    {
        DelayedMethod();
        counter = 0;
        ChangeTexture(targetGameObject, Texture1);
        portal.SetActive(false);
        crafted1.SetActive(false);
        crafted2.SetActive(false);
        crafted3.SetActive(false);
        crafted4.SetActive(false);
        crafted5.SetActive(false);
        crafted6.SetActive(false);
    }
    void Update() // Trigger when the player clicks on the GameObject
    {
        // Get the names of the objects on the slots
        List<string> slotContents = new List<string>
        {
            GetObjectNameOnSlot(slot1),
            GetObjectNameOnSlot(slot2),
            GetObjectNameOnSlot(slot3),
            GetObjectNameOnSlot(slot4)
        };
        listContent = string.Join(", ", requiredNames);
        missing_stuff.text = listContent;
        now_have.text = string.Join(", ", slotContents);
        step.text = "Step: "+(counter+1).ToString();

        // Check if the slot contents match the required names
        if (AreRequiredNamesPresent(slotContents))
        {
            switch (counter)
            {
                case 0:
                    Debug.Log("step 1");
                    originSwitch.SetActive(true);
                    crafted1.SetActive(true);
                    DelayedMethod();
                    crafted1.transform.position = new Vector3((float)-3.53, (float)0, (float)-4.85);
                    requiredNames = new List<string> { "screw", "combinded_motor", "wheel", "car_board" };
                    ChangeTexture(targetGameObject, Texture2);
                    break;
                case 1:
                    Debug.Log("step 2");
                    originSwitch.SetActive(true);
                    crafted2.SetActive(true);
                    crafted1.SetActive(false);
                    DelayedMethod();
                    crafted2.transform.position = new Vector3((float)-3.53, (float)0, (float)-4.85);
                    requiredNames = new List<string> { "screw", "copper_pillar", "camera", "camera_stableized_PCB" };
                    ChangeTexture(targetGameObject, Texture3);
                    break;
                case 2:
                    Debug.Log("step 3");
                    originSwitch.SetActive(true);
                    crafted3.SetActive(true);
                    DelayedMethod();
                    crafted3.transform.position = new Vector3((float)-3.53, (float)0, (float)-4.85);
                    requiredNames = new List<string> { "camera_rack", "combined_camera", "air", "air" };
                    ChangeTexture(targetGameObject, Texture4);
                    break;
                case 3:
                    Debug.Log("step 4");
                    originSwitch.SetActive(true);
                    crafted4.SetActive(true);
                    crafted3.SetActive(false);
                    DelayedMethod();
                    crafted4.transform.position = new Vector3((float)-3.53, (float)0, (float)-4.85);
                    requiredNames = new List<string> { "fully_combined_camera", "line_following_module", "car_with_wheel_and_motor", "air" };
                    ChangeTexture(targetGameObject, Texture5);
                    break;
                case 4:
                    Debug.Log("step 5");
                    originSwitch.SetActive(true);
                    crafted5.SetActive(true);
                    crafted4.SetActive(false);
                    crafted2.SetActive(false);
                    DelayedMethod();
                    crafted5.transform.position = new Vector3((float)-3.53, (float)0, (float)-4.85);
                    requiredNames = new List<string> { "car_with_camera", "Arduino_uno_r3_v2", "battery", "copper_pillar" };
                    ChangeTexture(targetGameObject, Texture6);
                    break;
                case 5:
                    originSwitch.SetActive(true);
                    crafted6.SetActive(true);
                    crafted5.SetActive(false);
                    DelayedMethod();
                    crafted6.transform.position = new Vector3((float)-3.53, (float)0, (float)-4.85);
                    requiredNames = new List<string> { "Congratulation, All Step Completed!" };
                    Debug.Log("All step complete");
                    portal.SetActive(true);
                    break;

            }
            Debug.Log("Detected: " + listContent);
            counter++;
        }
        else
        {
            //Debug.Log("Not Detected: " + listContent);
        }
    }

    string GetObjectNameOnSlot(GameObject slot)
    {
        
        // Perform a raycast to detect objects above the slot
        RaycastHit hit;
        /*
        if (Physics.Raycast(slot.transform.position, Vector3.up, out hit, detectionHeight))
        {
            Debug.Log(slot +" have: "+ hit.collider.gameObject.name);
            // Return the name of the detected object
            return hit.collider.gameObject.name;
        }
        else
        {
            Debug.Log(slot + " have: air");
            // Return "air" if no object is detected
            return "air";
        }*/
        if (Physics.Raycast(slot.transform.position, Vector3.up, out hit, detectionHeight))
        {

            currentTopObject = hit.collider.gameObject;
            //Debug.Log(slot + "  Object detected on top: " + currentTopObject.name, currentTopObject);
            return currentTopObject.name;
        }
        else
        {
            //Debug.Log("No object detected on top  " + slot);
            currentTopObject = null;
            return "air";
        }
    }

    bool AreRequiredNamesPresent(List<string> slotContents)
    {
        // Create a copy of the required names list
        List<string> remainingNames = new List<string>(requiredNames);

        // Check if each required name is present in the slot contents
        foreach (string name in slotContents)
        {
            if (remainingNames.Contains(name))
            {
                remainingNames.Remove(name); // Remove the name from the list
            }
        }

        // If all required names are found, the list will be empty
        return remainingNames.Count == 0;
    }

    private void ChangeTexture(GameObject obj, Texture newTexture)
    {
        // Ensure the GameObject has a Renderer component
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            if (newTexture != null)
            {
                // Change the main texture of the object's material to the new texture
                renderer.material.mainTexture = newTexture;
            }
            else
            {
                Debug.LogWarning("No texture assigned to the TextureChanger script.");
            }
        }
        else
        {
            Debug.LogWarning("The GameObject does not have a Renderer component.");
        }
    }
    IEnumerator DelayedMethod()
    {
        yield return new WaitForSeconds(4f); // 4-second delay
        // Code to execute after delay
        Debug.Log("4 seconds have passed!");
    }
}