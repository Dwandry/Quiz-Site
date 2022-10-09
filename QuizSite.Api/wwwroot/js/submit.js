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

    const newP = document.createElement("p");
    newP.innerText = "Result Successfully Submited!";
    newP.style.position = "absolute";
    newP.style.textAlign = "center";
    newP.style.fontWeight = "800";

    const returnBtn = document.createElement("button");
    returnBtn.textContent = "Return to Main Page";
    returnBtn.addEventListener("click", () => {
        window.location.href = "/index.html";
    });
    returnBtn.style.margin = "25px";
    returnBtn.style.width = "fit-content";
    returnBtn.style.paddingLeft = '50px';
    returnBtn.style.paddingRight = '50px';

    newP.appendChild(returnBtn);
    mainContainer.replaceChildren(newP);
    mainContainer.className = "mainContainerSubmit";
    mainContainer.style.marginRight = "390px";
  });
});
