using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkDialogueVariables
{
    public Dictionary<string, Ink.Runtime.Object> Variables { get; private set; }

    public InkDialogueVariables(Story story)
    {
        Variables = new Dictionary<string, Ink.Runtime.Object>();

        foreach (string name in story.variablesState)
        {
            Ink.Runtime.Object value = story.variablesState.GetVariableWithName(name);
            Variables.Add(name, value);
            Debug.Log("Initialized Global Dialogue Variable: " + name + " = " + value);
        }
    }

    public void SyncVariablesAndStartListening(Story story)
    {
        SyncVariablesToStory(story);
        story.variablesState.variableChangedEvent += UpdateVariableState;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= UpdateVariableState;
    }

    public void UpdateVariableState(string name, Ink.Runtime.Object value)
    {
        // Only maintain Variables initialized from the globals ink file.
        if (!Variables.ContainsKey(name))
        {
            return;
        }

        Variables[name] = value;
        Debug.Log("Updated Dialogue Variable: " + name + " = " + value);
    }

    private void SyncVariablesToStory(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in Variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
