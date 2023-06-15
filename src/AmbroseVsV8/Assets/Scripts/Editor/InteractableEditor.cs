using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Interactable), true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var interactable = (Interactable)target;
        if(target.GetType() == typeof(EventOnlyInteractable))
        {
            interactable.PromptMessage = EditorGUILayout.TextField("Prompt Message", interactable.PromptMessage);
            EditorGUILayout.HelpBox("EventOnlyInteract can ONLY use UnityEvents.", MessageType.Info);
            if(interactable.GetComponent<InteractionEvent>() is null)
            {
                interactable.UseEvents = true;
                interactable.gameObject.AddComponent<InteractionEvent>();
            }
        }
        else
        {
            base.OnInspectorGUI();

            if (interactable.UseEvents)
            {
                if (interactable.GetComponent<InteractionEvent>() is null)
                {
                    interactable.gameObject.AddComponent<InteractionEvent>();
                }
            }
            else
            {
                if (interactable.GetComponent<InteractionEvent>() is not null)
                {
                    Debug.Log("Destroying immediately");
                    DestroyImmediate(interactable.GetComponent<InteractionEvent>());
                }
            }
        }
    }
}
