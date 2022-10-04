const mainContainer = document.getElementById("mainContainer");
const submitBtn = document.getElementById("searchButton");
submitBtn.addEventListener("click", getResults);
const tableHeaders = ["Username", "Category", "Score", "Date"];

function tableCreate(data) {
  const table = document.createElement("table");
  const tableHead = table.createTHead();
  let headRow = tableHead.insertRow();

  tableHeaders.forEach((element) => {
    let th = document.createElement("th");
    let text = document.createTextNode(element);
    th.appendChild(text);
    headRow.appendChild(th);
  });
  const tableBody = table.createTBody();

  for (let element of data) {
    for (let element of data) {
      let row = table.insertRow();
      for (key in element) {
        let cell = row.insertCell();
        let text = document.createTextNode(element[key]);
        cell.appendChild(text);
      }
    }
  }

  mainContainer.replaceChildren(table);
}

function getResults() {
  const usernameFromInput = document.getElementById("username").value;
  fetch("/see-results?username=" + usernameFromInput)
    .then((result) => result.json())
    .then((data) => {
      console.log(data);
      if (data.results.length === 0) {
        const notFoundDiv = document.createElement("div");
        notFoundDiv.innerText = `No Results for User "${usernameFromInput}"`;
        mainContainer.replaceChildren(notFoundDiv);
      } else {
        tableCreate(data.results);
      }
      const returnButton = document.createElement("button");
      returnButton.textContent = "Return To Main Page";
      returnButton.addEventListener("click", () => {
        window.location.href = "/index.html";
      });
      mainContainer.appendChild(returnButton);
    });
}
