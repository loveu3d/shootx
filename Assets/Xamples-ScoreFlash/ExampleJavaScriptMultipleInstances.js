
function OnGUI() {
    if (GUI.Button(Rect(Screen.width - 150F, 10F, 140F, 30F), "Push to SF_Amadeus")) {
        ScoreFlashManager.Get("SF_Amadeus").PushLocal("SF_Amadeus, yay!");
    }

    if (GUI.Button(Rect(Screen.width - 150F, 50F, 140F, 30F), "Push to SF_Destroy")) {
        ScoreFlashManager.Get("SF_Destroy").PushLocal("SF_Destroy, you see?");
    }

    if (GUI.Button(Rect(Screen.width - 150F, 90F, 140F, 30F), "Push to SF_Eraser")) {
        ScoreFlashManager.Get("SF_Eraser").PushLocal("SF_Eraser, play with me!");
    }

    // this section is just a hack to be able to switch "Autogenerate Messages" on or off
    var instanceA:ScoreFlash = ScoreFlashManager.Get("SF_Amadeus");
    var instanceB:ScoreFlash = ScoreFlashManager.Get("SF_Destroy");
    var instanceC:ScoreFlash = ScoreFlashManager.Get("SF_Eraser");

    // allow the player to auto generate messages ... or not ;-)
    instanceA.isTestAutogenerateMessages
        = GUI.Toggle(Rect(10F, 10F, 200F, 30F), instanceA.isTestAutogenerateMessages, "Autogenerate Messages?");
    instanceB.isTestAutogenerateMessages = instanceA.isTestAutogenerateMessages;
    instanceC.isTestAutogenerateMessages = instanceA.isTestAutogenerateMessages;
}
