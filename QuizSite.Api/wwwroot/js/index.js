function goToQuiz(quizType) {
  window.location.href = "/quiz.html?category=" + quizType;
}

let buttons = document.getElementsByTagName("button");

for (let i = 0; i < buttons.length; i++) {
  const button = buttons[i];
  if (
    button.id === "programmingBtn" ||
    button.id === "natureBtn" ||
    button.id === "videogamesBtn" ||
    button.id === "mathBtn"
  ) {
    button.addEventListener("click", () => {
      goToQuiz(button.innerText.toLowerCase());
    });
  }
}

const resultBtn = document.getElementById("resultsBtn");
resultBtn.addEventListener("click", () => {
    console.log("Redirect");
    window.location.href = "/results.html";
});
