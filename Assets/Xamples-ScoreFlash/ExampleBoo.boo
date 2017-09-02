import UnityEngine

class ExampleBoo (MonoBehaviour): 

    public posY as single = 250
    public width as single = 180
    public height as single = 20
    public padding as single = 10

    public text as string = "Boo Text"

    def OnGUI():
        rect = Rect(Screen.width - (width + padding), posY, width, height)

        GUI.Label(rect, "Boo Example");

        rect.y += rect.height + padding;
        text = GUI.TextField(rect, text);

        rect.y += rect.height + padding;
        if GUI.Button(rect, "Flash Score from Boo"):
            ScoreFlash.Push(text); // <--- this is all there is to it!!!
