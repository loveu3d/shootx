#pragma strict

var currentScore = 0;

var firstMotivationThreshold = 100;
var firstMotivationMessage = "First Motivational Message";

var secondMotivationThreshold = 500;
var secondMotivationMessage = "Second Motivational Message";

var awesomeAchievementThreshold = 1000;
var awesomeAchievementMessage = "Awesome Achievement Unlocked";

private var currentScoreState = ScoreState.InitialState;

enum ScoreState {
    InitialState,
    FirstMotivationShown,
    SecondMotivationShown,
    AwesomeAchievementShown
}

function Start() {
    while (true) {
        currentScore += 30;
        yield WaitForSeconds(1F);
    }
}

function Update() {
    CheckScoreState();
}

function CheckScoreState() {
    switch (currentScoreState) {
        case ScoreState.InitialState:
            if (currentScore > firstMotivationThreshold) {
                ScoreFlash.Push(firstMotivationMessage);
                currentScoreState = ScoreState.FirstMotivationShown;
            }
            break;
        case ScoreState.FirstMotivationShown:
            if (currentScore > secondMotivationThreshold) {
                ScoreFlash.Push(secondMotivationMessage);
                currentScoreState = ScoreState.SecondMotivationShown;
            }
            break;
        case ScoreState.SecondMotivationShown:
            if (currentScore > awesomeAchievementThreshold) {
                ScoreFlash.Push(awesomeAchievementMessage);
                currentScoreState = ScoreState.AwesomeAchievementShown;
            }
            break;
    }
}