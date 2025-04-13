const inputEl = document.getElementById('number-check') as HTMLInputElement;
const messageEl = document.getElementById('number-check-message') as HTMLElement;
const submitButton = document.querySelector('form input[type="submit"]') as HTMLInputElement;

const notNumber: string = 'ERROR: Not a number';
const correctAnswer: string = 'Correct answer';
const incorrectAnswer: string = 'Incorrect answer';

inputEl.addEventListener('keyup', function () {
    const inputText: number = parseInt(inputEl.value);

    let message: string = '';
    let disable: boolean = true;

    if (isNaN(inputText)) {
        message = notNumber;
    }
    else if (inputText % 2 === 0) {
        message = correctAnswer;
        disable = false;
    }
    else {
        message = incorrectAnswer;
    }

    messageEl.innerText = message;
    submitButton.disabled = disable;
});