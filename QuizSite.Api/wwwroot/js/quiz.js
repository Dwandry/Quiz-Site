const divMainContainer = document.getElementById("mainContainer");
const urlParams = new URLSearchParams(window.location.search);
const quizCategory = urlParams.get("category");
let questions;
let htmlQuestions = [];
let scores = 0;

function redirectTo(path) {
  window.location.href = path;
}

function createButton(redirectUrl, buttonText) {
  const buttonToReturn = document.createElement("button");
  buttonToReturn.addEventListener("click", () => redirectTo(redirectUrl));
  buttonToReturn.textContent = buttonText;
  
  return buttonToReturn;
}

function answerQuestion(event) {
  let button = event.target;
  if (button.name === "true") {
    scores++;
    console.log("Scores:" + scores);
  }

  if (button.value < Number(htmlQuestions.length) - 1) {
    divMainContainer.replaceChildren(htmlQuestions[Number(button.value) + 1]);
  } else {
    const quizResultsDiv = document.createElement("div");
    quizResultsDiv.innerText = `Congratulations! Your score is ${scores}/${htmlQuestions.length}`;

    const returnBtn = createButton("/index.html", "Return to Main Page");

    const startAgainBtn = createButton(`/quiz.html?category=${quizCategory}`, "Start Over");

    const submitBtn = createButton(`/submit.html?category=${quizCategory}&score=${scores}`, "Submit My Result!");

    quizResultsDiv.appendChild(submitBtn);
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
      console.log("questions", questions);

      for (let i = 0; i < questions.length; i++) {
        const question = questions[i];
        const questionDiv = document.createElement("div");
        questionDiv.innerText = question.quizQuestion;

        const answersDiv = document.createElement("div");

        const choises = question.choises;

        for (let j = 0; j < choises.length; j++) {
          const choise = choises[j];
          let choiseBtn = document.createElement("button");
          choiseBtn.textContent = choise.answerChoise;
          choiseBtn.name = choise.isRightAnswer;
          choiseBtn.value = i;
          choiseBtn.addEventListener("click", answerQuestion);
          answersDiv.appendChild(choiseBtn);
        }

        questionDiv.appendChild(answersDiv);
        htmlQuestions.push(questionDiv);
      }
      console.log("htmlQuestions", htmlQuestions);
      divMainContainer.appendChild(htmlQuestions[0]);
    });
}

document.onload = getQuizes();
