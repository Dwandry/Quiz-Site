const divMainContainer = document.getElementById("mainContainer");
const urlParams = new URLSearchParams(window.location.search);
const quizCategory = urlParams.get('category');
let questions;
let htmlQuestions = [];
let scores = 0;

function redirectTo(path) {
  window.location.href = path;
  console.log('IN REDIRECT');
}

function answerQuestion(event) {
  let button = event.target;
  if (button.name === 'true') {
    scores++;
    console.log('Scores:' + scores);
  }
  if (Number(button.value) < htmlQuestions.length) {
    divMainContainer.replaceChildren(htmlQuestions[button.value]);
  } else {
    const quizResultsDiv = document.createElement('div');
    quizResultsDiv.innerText = `Congratulations! Your score is ${scores}/${htmlQuestions.length}`;

    const returnBtn = document.createElement('button');
    returnBtn.addEventListener('click', () => redirectTo('/index.html'));
    returnBtn.textContent = 'Return to Main Page';

    const startAgainBtn = document.createElement('button');
    startAgainBtn.addEventListener('click', () => redirectTo(`/quiz.html?category=${quizCategory}`));
    startAgainBtn.textContent = 'Start Over';


    quizResultsDiv.appendChild(startAgainBtn);
    quizResultsDiv.appendChild(returnBtn);
    divMainContainer.replaceChildren(quizResultsDiv);
  }
}

function getQuizes() {
  fetch("/get-all-quizes?category=" + quizCategory)
    .then((result) => result.json())
    .then((data) => {
      questions = data;
      console.log('questions', questions);

      for (let i = 0; i < questions.length; i++) {
        const question = questions[i];
        const questionDiv = document.createElement("div");
        questionDiv.innerText = question.quizQuestion;

        const answersDiv = document.createElement("div");

        const choises = question.choises;

        for (let j = 0; j < choises.length; j++) {
          const choise = choises[j];
          let choiseBtn = document.createElement('button');
          choiseBtn.textContent = choise.answerChoise;
          choiseBtn.name = choise.isRightAnswer;
          choiseBtn.value = question.id;
          choiseBtn.addEventListener('click', answerQuestion);
          answersDiv.appendChild(choiseBtn);
        }

        questionDiv.appendChild(answersDiv);
        htmlQuestions.push(questionDiv);
      }
      console.log('htmlQuestions', htmlQuestions);
      divMainContainer.appendChild(htmlQuestions[0]);
    });
}


document.onload = getQuizes();


