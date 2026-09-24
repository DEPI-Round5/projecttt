Console.Write("Enter number of questions: ");
            int numQuestions = int.Parse(Console.ReadLine());

            if (examType == 1)
            {
                SubjectExam = new PracticalExam(time, numQuestions);
            }
            else
            {
                SubjectExam = new FinalExam(time, numQuestions);
            }

            Console.Clear();

            for (int i = 0; i < numQuestions; i++)
            {
                int qType = 1;
                if (examType == 2) // Final exam has both True/False and MCQ
                {
                    do
                    {
                        Console.Write($"\nPlease choose type for Question {i + 1} (1 for True/False, 2 for MCQ): ");
                    } while (!int.TryParse(Console.ReadLine(), out qType) || (qType != 1 && qType != 2));
                }

                Console.Write("Enter question header: ");
                string header = Console.ReadLine();

                Console.Write("Enter question body: ");
                string body = Console.ReadLine();

                Console.Write("Enter question mark: ");
                int mark = int.Parse(Console.ReadLine());

                if (qType == 1) // True or False
                {
                    TrueFalseQuestion tfQ = new TrueFalseQuestion(header, body, mark);

                    int rightId;
                    do
                    {
                        Console.Write("Enter right answer ID (1 for True, 2 for False): ");
                    } while (!int.TryParse(Console.ReadLine(), out rightId) || (rightId != 1 && rightId != 2));

                    tfQ.RightAnswer = tfQ.AnswerList[rightId - 1];
                    SubjectExam.Questions[i] = tfQ;
                }
                else // MCQ
                {
                    Console.Write("Enter number of choices: ");
                    int numChoices = int.Parse(Console.ReadLine());
                    Answer[] answers = new Answer[numChoices];

                    for (int j = 0; j < numChoices; j++)
                    {
                        Console.Write($"Enter text for choice {j + 1}: ");
                        string choiceText = Console.ReadLine();
                        answers[j] = new Answer(j + 1, choiceText);
                    }

                    MCQQuestion mcqQ = new MCQQuestion(header, body, mark, answers);

                    int rightId;
                    do
                    {
                        Console.Write("Enter right answer ID: ");
                    } while (!int.TryParse(Console.ReadLine(), out rightId)  rightId < 1  rightId > numChoices);

                    mcqQ.RightAnswer = answers[rightId - 1];
                    SubjectExam.Questions[i] = mcqQ;
                }
            }
        }
    }
    #endregion

    #region 5. Program Main Class
    class Program
    {
        static void Main(string[] args)
        {
            Subject sub1 = new Subject(101, "Object Oriented Programming");
            
            Console.WriteLine($"Subject: {sub1.SubjectName} (ID: {sub1.SubjectId})");
            sub1.CreateExam();

            Console.Clear();
            Console.Write("Do you want to start the exam? (y/n): ");
            char start = char.Parse(Console.ReadLine());

            if (start == 'y' || start == 'Y')
            {
                Console.Clear();
                sub1.SubjectExam.ShowExam();
            }
            else
            {
                Console.WriteLine("Exam cancelled. Good luck next time!");
            }
        }
    }
    #endregion
}