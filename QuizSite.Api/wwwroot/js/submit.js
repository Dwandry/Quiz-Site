const urlParams = new URLSearchParams(window.location.search);
const quizCategory = urlParams.get("category");
const quizScore = urlParams.get("score");
const mainContainer = document.getElementById("mainDivContainer");

const submitBtn = document.getElementById("submitButton");
submitBtn.addEventListener("click", () => {
  const usernameFromInput = document.getElementById("username").value;
  let data = {
    username: usernameFromInput,
    quizCategory: quizCategory,
    score: quizScore,
  };
  fetch("/submit-result", {
    method: "PUT",
    body: JSON.stringify(data),
    headers: {
      "Content-Type": "application/json;charset=utf-8",
    },
  }).then((response) => {
    console.log("response", response.json());

    const newDiv = document.createElement("div");
    newDiv.innerText = "Result Successfully Submited!";

    const returnBtn = document.createElement("button");
    returnBtn.textContent = "Return to Main Page";
    returnBtn.addEventListener("click", () => {
        window.location.href = "/index.html";
    });
    newDiv.appendChild(returnBtn);
    mainContainer.replaceChildren(newDiv);
  });
});
