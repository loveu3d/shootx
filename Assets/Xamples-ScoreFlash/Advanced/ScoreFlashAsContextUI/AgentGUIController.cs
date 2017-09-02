using System.Collections;
using UnityEngine;

using NarayanaGames.ScoreFlashComponent;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
// controls how the GUI appears / disappears on mouse over (on the agent - the orange sphere)
public class AgentGUIController : MonoBehaviour {

    // needed for pushing the GUI above the agent's "head" ;-)
    public ScoreFlashFollow3D follow3D;

    // the ScoreFlashRenderer that renders the GUI
    public AgentGUIRenderer agentGUIRendererPrefab;

    // the NavMeshAgent that controls the movement
    private UnityEngine.AI.NavMeshAgent navAgent;

    // the possible targets
    public Transform[] targets;

    // how long does the player have time to mouse over the GUI
    public float mouseOverDelay = 0.5F;

    // reference to the ScoreMessage representing the GUI
    private ScoreMessage scoreMessageGUI = null;

    private AgentGUIRenderer currentGUIRenderer;

    private bool isMouseHovering = false;

    public void Awake() {
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // when player hovers over the agent with the mouse, let the GUI appear
    public void OnMouseEnter() {
        isMouseHovering = true;
        if (scoreMessageGUI == null) {
            currentGUIRenderer = (AgentGUIRenderer) agentGUIRendererPrefab.CreateInstance(this.transform);
            currentGUIRenderer.Controller = this;
            
            scoreMessageGUI = ScoreFlash.Instance.PushWorld(follow3D, currentGUIRenderer);
            // make the message freeze time once it reaches the beginning of "read"
            scoreMessageGUI.FreezeOnRead = true;
        }
    }

    // when player leaves the agent with the mouse, let the GUI disappear ... after a delay
    public void OnMouseExit() {
        isMouseHovering = false;
        if (scoreMessageGUI != null && !currentGUIRenderer.KeepGUI) {
            StartCoroutine(HideGUIAfterDelayCo(false));
        }
    }

    public void HideGUIAfterDelay(bool skipDelay) {
        StartCoroutine(HideGUIAfterDelayCo(skipDelay));
    }

    // after a set delay, let the GUI disappear - unless the player 
    private IEnumerator HideGUIAfterDelayCo(bool skipDelay) {
        if (!skipDelay) {
            yield return new WaitForSeconds(mouseOverDelay);
        }
        if (!isMouseHovering && scoreMessageGUI != null && !currentGUIRenderer.KeepGUI) {
            // re-activate the animation of the message so it can disappear
            scoreMessageGUI.LocalTimeScale = 1F;
            scoreMessageGUI = null;
            currentGUIRenderer = null;
        }
    }

    public void SetTarget(Transform target) {
        navAgent.SetDestination(target.position);
    }
}
