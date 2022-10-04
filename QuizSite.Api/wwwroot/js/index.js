function goToQuiz(quizType) {
    window.location.href = '/quiz.html?category=' + quizType;
}

let buttons = document.getElementsByTagName('button');
for (let i = 0; i < buttons.length; i++) {
    const button = buttons[i];   
    button.addEventListener('click', () => {
        goToQuiz(button.innerText.toLowerCase());
    })
}