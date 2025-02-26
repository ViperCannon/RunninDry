using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkDialogueVariables
{
    private Dictionary<string, Ink.Runtime.Object> variables;
    
    public InkDialogueVariables(Story story)
    {
        variables = new Dictionary<string, Ink.Runtime.Object>();

        foreach (string name in story.variablesState)
        {
            Ink.Runtime.Object value = story.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("Initialized Global Dialogue Variable: " + name + " = " + value);
        }
    }

    public void SyncVariablesAndStartListening(Story story)
    {

    }

    public void StopListening(Story story)
    {

    }

    public void SyncVariablesAndStartListening(string name, Ink.Runtime.Object value)
    {

    }

    private void SyncVariablesToStory(Story story)
    {

    }
}
