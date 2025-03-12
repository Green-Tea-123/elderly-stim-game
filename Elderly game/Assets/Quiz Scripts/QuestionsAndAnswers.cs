[System.Serializable]

public class QuestionsAndAnswers
{
    public string Question;
    public string[] Answers;
    public int CorrectAnswer;

    public QuestionsAndAnswers(string question, string answer1, string answer2, string answer3, string answer4, int correctAnswer) {
        this.Question = question;
        this.Answers = new[] { answer1, answer2, answer3, answer4 };
        this.CorrectAnswer = correctAnswer;
    }
}
