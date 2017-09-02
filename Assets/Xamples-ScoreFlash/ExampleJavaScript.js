var posY:float = 130;
var width:float = 180;
var height:float = 20;
var padding:float = 10;

var text:String = "JavaScript Text";

function OnGUI() {
    var rect:Rect = Rect(Screen.width - (width + padding), posY, width, height);

    GUI.Label(rect, "JavaScript Example");

    rect.y += rect.height + padding;
    text = GUI.TextField(rect, text);

    rect.y += rect.height + padding;
    if (GUI.Button(rect, "Flash Score from JavaScript")) {
        ScoreFlash.Push(text); // <-- this is all there is to it!!!
    }
}