using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBank
{
    public static List<QuestionsAndAnswers>  generateQuestions() {
        List<QuestionsAndAnswers> questions = new List<QuestionsAndAnswers>();
        questions.Add(new QuestionsAndAnswers(
            "Who is the first prime minister of Singapore?", 
            "Lee Kuan Yew", 
            "Stamford Raffles", 
            "Lawrence Wong", 
            "Lee Hsien Loong", 
            1));
        questions.Add(new QuestionsAndAnswers(
            "What year did Singapore gain independence?",
            "1959",
            "1963",
            "1965",
            "1968", 
            3));
        questions.Add(new QuestionsAndAnswers(
            "What is the tallest building in Singapore?",
            "Marina Bay Sands",
            "Guoco Tower",
            "UOB Plaza",
            "The Pinnacle@Duxton",
            2));
        return questions;
    }
}
