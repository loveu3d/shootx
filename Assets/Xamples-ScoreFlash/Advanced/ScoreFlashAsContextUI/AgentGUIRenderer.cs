using UnityEngine;
using System.Collections;

using NarayanaGames.Common;
using NarayanaGames.ScoreFlashComponent;

public class AgentGUIRenderer : ScoreFlashRendererBase, IHasOnGUI {
    public Vector2 buttonSize = new Vector2(50, 20);
    public GUISkin skin;

    private bool isHoveringOverGUI = false;
    private bool isGUIActivated = false;
    private bool isGUIDone = false;

    private ScoreMessage msg;

    private AgentGUIController controller = null;
    public AgentGUIController Controller {
        set { controller = value; }
    }

    // disable "disappearing" while we're doing something with the GUI
    public bool KeepGUI {
        get { return !isGUIDone && (isGUIActivated || isHoveringOverGUI); }
    }

    #region Implementation of methods required by ScoreFlashRendererBase

    // returns false because we use our own skin
    public override bool UsesGUISkin {
        get { return false; }
    }

    /// <summary>
    ///     Returns <c>false</c> because GUIText does not need a custom parent.
    /// </summary>
    public override bool RequiresCustomParent {
        get { return false; }
    }

    /// <summary>
    ///     Returns the size as it is configured, scaled for high density,
    ///     if necessary.
    /// </summary>
    /// <param name="msg">ignored</param>
    public override Vector2 GetSize(ScoreMessage msg) {
        return NGUtil.Scale(buttonSize);
    }

    /// <summary>
    ///     Update the message. The implementation needs
    ///     to make sure that you update position, scale, color and outline
    ///     color as well as the text.
    /// </summary>
    /// <param name="msg">the current version of the message</param>
    public override void UpdateMessage(ScoreMessage msg) {
        this.msg = msg;
    }

    #endregion Implementation of methods required by ScoreFlashRendererBase

    private bool? leftAlign = null;

    public void OnGUI() {
        if (msg == null) {
            return;
        }

        if (skin != null) {
            GUI.skin = skin;
        }

        // we need to show the buttons left, if the sphere is near the right screen edge
        // do not revert this - but fix it, if the sphere moves towards right edge
        if (!leftAlign.HasValue || !leftAlign.Value) {
            leftAlign = msg.Position.x > Screen.width - buttonSize.x - 30;
        }

        Matrix4x4 originalGUIMatrix = GUI.matrix;

        Vector2 alignBasedOffset = ScoreFlash.GetAlignBasedOffset(msg);

        Rect localPos = msg.Position;
        localPos.x += alignBasedOffset.x;
        localPos.y += alignBasedOffset.y;

        Vector2 pivotPoint = new Vector2(localPos.x + localPos.width * 0.5F, localPos.y + localPos.height * 0.5F);
        GUIUtility.ScaleAroundPivot(new Vector2(msg.Scale, msg.Scale), pivotPoint);
        GUIUtility.RotateAroundPivot(msg.Rotation, pivotPoint);

        GUI.color = msg.CurrentTextColor;

        bool wasHoveringOverGUI = isHoveringOverGUI;
        isHoveringOverGUI = msg.Position.Contains(Event.current.mousePosition);
        if (wasHoveringOverGUI && !isHoveringOverGUI) {
            controller.HideGUIAfterDelay(false);
        }

        if (GUI.Button(localPos, "Actions")) {
            if (!isGUIActivated) {
                isGUIActivated = true;
            } else {
                isGUIDone = true;
                controller.HideGUIAfterDelay(true);
            }
        }

        if (isGUIActivated) {
            Rect pos = new Rect(localPos);
            if (leftAlign.Value) {
                pos.x -= buttonSize.x;
            } else {
                pos.x += msg.Position.width;
            }
            foreach (Transform target in controller.targets) {
                if (GUI.Button(pos, target.name)) {
                    controller.SetTarget(target);
                    isGUIDone = true;
                    controller.HideGUIAfterDelay(true);
                }
                pos.y += pos.height;
            }
        }

        GUI.matrix = originalGUIMatrix;
    }
}
