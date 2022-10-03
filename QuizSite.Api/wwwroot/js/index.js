function goToQuiz(quizType) {
    window.location.href = '/quiz.html?category=' + quizType;
}

// const programmingBtn = document.getElementById('programmingBtn');
// const natureBtn = document.getElementById('natureBtn');
// const videogamesBtn = document.getElementById('videogamesBtn');
// const mathBtn = document.getElementById('mathBtn');


let buttons = document.getElementsByTagName('button');
for (let i = 0; i < buttons.length; i++) {
    const button = buttons[i];   
    button.addEventListener('click', () => {
        goToQuiz(button.innerText.toLowerCase());
    })
}

// programmingBtn.addEventListener('click', () => {
// 	goToQuiz(programmingBtn.Id);
// });

