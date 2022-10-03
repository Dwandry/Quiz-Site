const divMainContainer = document.getElementById("mainContainer");
const urlParams = new URLSearchParams(window.location.search);
const quizCategory = urlParams.get('category');
let questions;

function getQuizes() {
  fetch("/get-all-quizes?category=" + quizCategory)
    .then((result) => result.json())
    .then((data) => {
      questions = data;
      const questionDiv = document.createElement("div");
      questionDiv.innerText = questions[0].quizQuestion;
      divMainContainer.appendChild(questionDiv);
    });
}

document.onload = getQuizes();
